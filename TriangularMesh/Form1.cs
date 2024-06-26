using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Numerics;

namespace TriangularMesh
{
    public partial class TriangularMesh : Form
    {
        const int CONTROL_POINT_RADIUS = 6;
        const int CONTROL_POINT_CLICK_DIST = 40;
        DirectBitmap DrawArea;
        Brush DrawingBrush;
        Pen DrawingPen;
        public TriangularMesh()
        {
            InitializeComponent();
            Logic.z_ControlPoints = new double[4, 4];
            Logic.m = 30;
            Logic.n = 30;
            Logic.DispersedFactor = 0.5;
            Logic.SpecularFactor = 0.5;
            Logic.SpecularM = 50;
            Logic.Recalculate();
            DrawingBrush = Brushes.Black;
            DrawingPen = new Pen(Brushes.Black);
            DrawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = DrawArea.Bitmap;
            Logic.SurfaceColor = new Color[Canvas.Width, Canvas.Height];
            Logic.ImportedNormalMapRGBNormalized = new Vector3D[Canvas.Width, Canvas.Height];
            Parallel.For(0, Canvas.Width, (i) =>
            {
                Parallel.For(0, Canvas.Height, (j) =>
                {
                    Logic.SurfaceColor[i, j] = Color.White;
                });
            });
            Redrawing();
        }
        int x2canvx(double x)
        {
            return Convert.ToInt32((Canvas.Width - 1) * x);
        }
        int y2canvy(double y)
        {
            return Convert.ToInt32((Canvas.Height - 1) * (1 - y));
        }
        double canvx2x(int canvx)
        {
            return 1.0 * canvx / (Canvas.Width - 1);
        }
        double canvy2y(int canvy)
        {
            return 1.0 - (1.0 * canvy / (Canvas.Height - 1));
        }
        void Redrawing()
        {
            (double, double, double) barycentric(double x, double y, Triangle triangle)
            {
                TriangleVertex A = triangle.A;
                TriangleVertex B = triangle.B;
                TriangleVertex C = triangle.C;

                double denom = ((B.y - C.y) * (A.x - C.x) + (C.x - B.x) * (A.y - C.y));
                double l1 = ((B.y - C.y) * (x - C.x) + (C.x - B.x) * (y - C.y)) / denom;
                double l2 = ((C.y - A.y) * (x - C.x) + (A.x - C.x) * (y - C.y)) / denom;
                return (l1, l2, 1 - l1 - l2);
            }
            List<Point> CanvasPixelsToFill(Triangle triangle)
            {
                List<Point> result = new List<Point>();
                Point[] Vertices = {new Point(x2canvx(triangle.A.x), y2canvy(triangle.A.y)),
                    new Point(x2canvx(triangle.B.x), y2canvy(triangle.B.y)),
                    new Point(x2canvx(triangle.C.x), y2canvy(triangle.C.y))};

                int minY = Vertices.Min(p => p.Y);
                int maxY = Vertices.Max(p => p.Y);
                Array.Sort(Vertices, (a, b) => a.Y.CompareTo(b.Y));

                for (int y = minY; y <= maxY; ++y)
                {
                    List<int> intersections = new List<int>();
                    for (int i = 0; i < 3; ++i)
                    {
                        int next = (i + 1) % 3;

                        if ((Vertices[i].Y < y && Vertices[next].Y >= y) || (Vertices[next].Y < y && Vertices[i].Y >= y))
                        {
                            int x = (int)(Vertices[i].X + (double)(y - Vertices[i].Y) / (Vertices[next].Y - Vertices[i].Y) * (Vertices[next].X - Vertices[i].X));
                            intersections.Add(x);
                        }
                    }
                    intersections.Sort();
                    for (int i = 0; i < intersections.Count - 1; i += 2)
                    {
                        for (int x = intersections[i]; x <= intersections[i + 1]; x++)
                        {
                            result.Add(new Point(x, y));
                        }
                    }
                }

                return result;
            }

            //(double, double, double)[,] xyz = new (double, double, double)[Canvas.Width, Canvas.Height];

            using (Graphics g = Graphics.FromImage(DrawArea.Bitmap))
            {
                Color[,] Colors = new Color[Canvas.Width, Canvas.Height];
                Parallel.ForEach(Logic.Triangles, (triangle) =>
                {
                    List<Point> Pixels = CanvasPixelsToFill(triangle);
                    Parallel.ForEach(Pixels, (point) =>
                    {
                        double x = canvx2x(point.X);
                        double y = canvy2y(point.Y);
                        (double l1, double l2, double l3) = barycentric(x, y, triangle);
                        double z = l1 * triangle.A.z + l2 * triangle.B.z + l3 * triangle.C.z;
                        //xyz[point.X, point.Y] = (x, y, z);
                        Vector3D N = l1 * triangle.A.Normal + l2 * triangle.B.Normal + l3 * triangle.C.Normal;
                        N.Normalize();
                        if (Logic.UsingNormalMap)
                        {
                            Vector3D NTexture = Logic.ImportedNormalMapRGBNormalized[point.X, point.Y];
                            Vector3D TangentX = l1 * triangle.A.TangentX + l2 * triangle.B.TangentX + l3 * triangle.C.TangentX;
                            TangentX.Normalize();
                            Vector3D TangentY = l1 * triangle.A.TangentY + l2 * triangle.B.TangentY + l3 * triangle.C.TangentY;
                            TangentY.Normalize();

                            N = new Vector3D(TangentX.X * NTexture.X + TangentY.X * NTexture.Y + N.X * NTexture.Z,
                                TangentX.Y * NTexture.X + TangentY.Y * NTexture.Y + N.Y * NTexture.Z,
                                TangentX.Z * NTexture.X + TangentY.Z * NTexture.Y + N.Z * NTexture.Z);
                        }
                        Vector3D L = Logic.LightSource - new Vector3D(x, y, z);
                        L.Normalize();
                        double dot = Vector3D.DotProduct(N, L);
                        Vector3D R = 2 * dot * N - L;
                        R.Normalize();
                        double dot2 = Vector3D.DotProduct(Logic.ToObserver, R);

                        double Red = (Logic.LightColor.R / 255.0) * (Logic.SurfaceColor[point.X, point.Y].R / 255.0);
                        double Green = (Logic.LightColor.G / 255.0) * (Logic.SurfaceColor[point.X, point.Y].G / 255.0);
                        double Blue = (Logic.LightColor.B / 255.0) * (Logic.SurfaceColor[point.X, point.Y].B / 255.0);
                        double k = 0;
                        if (dot > 0) k += Logic.DispersedFactor * dot;
                        if (dot2 > 0) k += Logic.SpecularFactor * Math.Pow(dot2, Logic.SpecularM);
                        Red *= k;
                        Green *= k;
                        Blue *= k;
                        if (MainLightOutCheckBox.Checked) (Red, Green, Blue) = (0.0, 0.0, 0.0);

                        if(SpotlightsOnButton.Checked)
                        {
                            Vector3D RedReflectorPosition = new Vector3D(0, 0, Logic.LightSource.Z);
                            Vector3D GreenReflectorPosition = new Vector3D(1, 0, Logic.LightSource.Z);
                            Vector3D BlueReflectorPosition = new Vector3D(0.5, 1, Logic.LightSource.Z);
                            Vector3D LRed = RedReflectorPosition - new Vector3D(x, y, z);
                            Vector3D LGreen = GreenReflectorPosition - new Vector3D(x, y, z);
                            Vector3D LBlue = BlueReflectorPosition - new Vector3D(x, y, z);
                            LRed.Normalize(); LGreen.Normalize(); LBlue.Normalize();
                            Vector3D Target = new Vector3D(0.5, 0.5, 0);
                            Vector3D DRed = RedReflectorPosition - Target;
                            Vector3D DGreen = GreenReflectorPosition - Target;
                            Vector3D DBlue = BlueReflectorPosition - Target;
                            DRed.Normalize(); DGreen.Normalize(); DBlue.Normalize();
                            int CosinePower = Logic.SpotlightCosinePower;
                            double ILRed = Math.Pow(Math.Max(0, Vector3D.DotProduct(LRed, DRed)), CosinePower);
                            double ILGreen = Math.Pow(Math.Max(0, Vector3D.DotProduct(LGreen, DGreen)), CosinePower);
                            double ILBlue = Math.Pow(Math.Max(0, Vector3D.DotProduct(LBlue, DBlue)), CosinePower);

                            double RedColor = ILRed * (Logic.DispersedFactor * Math.Max(0, Vector3D.DotProduct(N, LRed))
                            + Logic.SpecularFactor * Math.Pow(dot2, Logic.SpecularM));
                            Red += RedColor;
                            double GreenColor = ILGreen * (Logic.DispersedFactor * Math.Max(0, Vector3D.DotProduct(N, LGreen))
                            + Logic.SpecularFactor * Math.Pow(dot2, Logic.SpecularM));
                            Green += GreenColor;
                            double BlueColor = ILBlue * (Logic.DispersedFactor * Math.Max(0, Vector3D.DotProduct(N, LBlue))
                            + Logic.SpecularFactor * Math.Pow(dot2, Logic.SpecularM));
                            Blue += BlueColor;
                        }

                        Red = Math.Min(255, Red * 255.0);
                        Green = Math.Min(255, Green * 255.0);
                        Blue = Math.Min(255, Blue * 255.0);

                        Colors[point.X, point.Y] = Color.FromArgb((byte)Red, (byte)Green, (byte)Blue);
                    });
                });

                //Matrix4x4 M = Matrix4x4.CreateTranslation((float)(-Canvas.Width * 0.5), (float)(-Canvas.Height * 0.5), 0) *
                //Matrix4x4.CreateFromYawPitchRoll(0, (float)(Math.PI * AlphaBar.Value / 180.0), (float)(Math.PI * BetaBar.Value / 180.0)) *
                //Matrix4x4.CreateTranslation((float)(Canvas.Width * 0.5), (float)(Canvas.Height * 0.5), 0);

                //for(int i = 0; i < Canvas.Width; ++i)
                //{
                //    for(int j = 0; j < Canvas.Height; ++j)
                //    {
                //        if(!TranslateCheckBox.Checked) DrawArea.SetPixel(i, j, Colors[i, j]);
                //        else
                //        {
                //            (int x, int y) = (x2canvx(i), y2canvy(j));
                //            Vector3 p = new Vector3(x, y, (float)xyz[i, j].Item3);
                //            p = Vector3.Transform(p, M);
                //            if (p.X < 0) p.X = 0; if (p.X >= Canvas.Width) p.X = Canvas.Width - 1;
                //            if (p.Y < 0) p.Y = 0; if (p.Y >= Canvas.Height) p.Y = Canvas.Height - 1;
                //            DrawArea.SetPixel((int)p.X, (int)p.Y, Colors[i, j]);
                //        }
                //    }
                //}

                for(int i = 0; i < Canvas.Width; ++i)
                {
                    for(int j = 0; j < Canvas.Height; ++j)
                    {
                        DrawArea.SetPixel(i, j, Colors[i, j]);
                    }
                }

                if(MeshVisibleCheckBox.Checked) foreach(var triangle in Logic.Triangles)
                {
                    Point A = new Point(x2canvx(triangle.A.x), y2canvy(triangle.A.y));
                    Point B = new Point(x2canvx(triangle.B.x), y2canvy(triangle.B.y));
                    Point C = new Point(x2canvx(triangle.C.x), y2canvy(triangle.C.y));
                    g.DrawLine(DrawingPen, A, B);
                    g.DrawLine(DrawingPen, A, C);
                    g.DrawLine(DrawingPen, B, C);
                }
                if(ControlPointsVisibleCheckBox.Checked)
                {
                    for(int i = 0; i < 4; ++i)
                    {
                        for(int j = 0; j < 4; ++j)
                        {
                            g.FillEllipse(DrawingBrush, x2canvx(Logic.xy_ControlPoints[i]) - CONTROL_POINT_RADIUS,
                                y2canvy(Logic.xy_ControlPoints[j]) - CONTROL_POINT_RADIUS,
                                2 * CONTROL_POINT_RADIUS, 2 * CONTROL_POINT_RADIUS);
                        }
                    }
                }
            }
            Canvas.Refresh();
        }
        async void Animation(int delay)
        {
            Vector3D Light = new Vector3D(0.5, 0.5, Logic.LightSource.Z);
            double theta = 0;
            int direction = 1;
            while(AnimationButton.Checked)
            {
                Logic.LightSource = Light + new Vector3D(theta / 8 * Math.Cos(4 * theta), theta / 8 * Math.Sin(4 * theta), 0);
                Redrawing();
                theta += direction * 0.02;
                if (Math.Abs(theta) > 4) direction *= -1;
                await Task.Delay(delay);
            }
        }

        private void MeshVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Redrawing();
        }

        private void ControlPointsVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Redrawing();
        }

        private void x_IntervalCountBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.m = x_IntervalCountBar.Value;
            Logic.Recalculate();
            Redrawing();
        }

        private void y_IntervalCountBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.n = y_IntervalCountBar.Value;
            Logic.Recalculate();
            Redrawing();
        }

        private void LightColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Logic.LightColor = colorDialog.Color;
                Redrawing();
            }
        }

        private void SurfaceColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Parallel.For(0, Canvas.Width, (i) =>
                {
                    Parallel.For(0, Canvas.Height, (j) =>
                    {
                        Logic.SurfaceColor[i, j] = colorDialog.Color;
                    });
                });
                Redrawing();
            }
        }

        private void DispersedTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.DispersedFactor = 1.0 * DispersedTrackBar.Value / 100;
            Redrawing();
        }

        private void SpecularTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.SpecularFactor = 1.0 * SpecularTrackBar.Value / 100;
            Redrawing();
        }

        private void SpecularMTrackBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.SpecularM = SpecularMTrackBar.Value;
            Redrawing();
        }

        private void Canvas_MouseClick(object sender, MouseEventArgs e)
        {
            if(!ControlPointsVisibleCheckBox.Checked)
            {
                z_ControlPointBar.Enabled = false;
                return;
            }

            (double xpos, double ypos) = (canvx2x(e.X), canvy2y(e.Y));
            (int i, int j) = ((int)Math.Floor(3 * xpos + 0.5), (int)Math.Floor(3 * ypos + 0.5));
            (double xnear, double ynear) = (Logic.xy_ControlPoints[i], Logic.xy_ControlPoints[j]);

            if (CONTROL_POINT_CLICK_DIST < (x2canvx(xnear) - e.X) * (x2canvx(xnear) - e.X) +
                (y2canvy(ynear) - e.Y) * (y2canvy(ynear) - e.Y))
            {
                z_ControlPointBar.Enabled = false;
                return;
            }

            Logic.ChosenControlPoint = (i, j);
            z_ControlPointBar.Value = Convert.ToInt32(100 * Logic.z_ControlPoints[i, j]);
            z_ControlPointBar.Enabled = true;
        }

        private void z_ControlPointBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.z_ControlPoints[Logic.ChosenControlPoint.Item1, Logic.ChosenControlPoint.Item2]
                = 1.0 * z_ControlPointBar.Value / 100;
            Logic.Recalculate();
            Redrawing();
        }

        private void LightSourceXBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.LightSource.X = 1.0 * LightSourceXBar.Value / 100;
            Redrawing();
        }

        private void LightSourceYBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.LightSource.Y = 1.0 * LightSourceYBar.Value / 100;
            Redrawing();
        }

        private void LightSourceZBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.LightSource.Z = 1.0 * LightSourceZBar.Value / 100;
            Redrawing();
        }

        private void AnimationButton_CheckedChanged(object sender, EventArgs e)
        {
            if(!AnimationButton.Checked)
            {
                Logic.LightSource = new Vector3D(1.0 * LightSourceXBar.Value / 100,
                    1.0 * LightSourceYBar.Value / 100, 1.0 * LightSourceZBar.Value / 100);
                Redrawing();
                LightSourceXBar.Enabled = true;
                LightSourceYBar.Enabled = true;
                LightSourceZBar.Enabled = true;
                return;
            }

            LightSourceXBar.Enabled = false;
            LightSourceYBar.Enabled = false;
            LightSourceZBar.Enabled = false;
            Animation(17);
        }

        private void SurfaceImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap Check = new Bitmap(Dialog.FileName);
                }
                catch
                {
                    return;
                }

                Bitmap OriginalImage = new Bitmap(Dialog.FileName);
                Bitmap resizedImage = new Bitmap(Canvas.Width, Canvas.Height);

                using (Graphics g = Graphics.FromImage(resizedImage))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(OriginalImage, 0, 0, Canvas.Width, Canvas.Height);
                }

                for (int i = 0; i < resizedImage.Width; i++)
                {
                    for (int j = 0; j < resizedImage.Height; j++)
                    {
                        Logic.SurfaceColor[i, j] = resizedImage.GetPixel(i, j);
                    }
                }
                Redrawing();
            }
        }

        void ImportNormalMap(string path)
        {
            Bitmap OriginalMap = new Bitmap(path);
            Bitmap resizedMap = new Bitmap(Canvas.Width, Canvas.Height);
            Color[,] ImportedNormalMap = new Color[Canvas.Width, Canvas.Height];

            using (Graphics g = Graphics.FromImage(resizedMap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(OriginalMap, 0, 0, Canvas.Width, Canvas.Height);
            }

            for (int i = 0; i < resizedMap.Width; i++)
            {
                for (int j = 0; j < resizedMap.Height; j++)
                {
                    ImportedNormalMap[i, j] = resizedMap.GetPixel(i, j);
                }
            }

            double RGBNormalizer(int val)
            {
                return (val - 127.5) / 127.5;
            }

            Parallel.For(0, Canvas.Width, (i) =>
            {
                Parallel.For(0, Canvas.Height, (j) =>
                {
                    Logic.ImportedNormalMapRGBNormalized[i, j] = new Vector3D(RGBNormalizer(ImportedNormalMap[i, j].R),
                        RGBNormalizer(ImportedNormalMap[i, j].G),
                        RGBNormalizer(ImportedNormalMap[i, j].B));
                    Logic.ImportedNormalMapRGBNormalized[i, j].Normalize();
                });
            });

            Logic.UsingNormalMap = true;
            Redrawing();
        }

        private void NormalMapButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap Check = new Bitmap(Dialog.FileName);
                }
                catch
                {
                    return;
                }
            }

            ImportNormalMap(Dialog.FileName);
        }

        private void ClearNormalMapButton_Click(object sender, EventArgs e)
        {
            Logic.UsingNormalMap = false;
            Redrawing();
        }

        private void ImportFoxMapButton_Click(object sender, EventArgs e)
        {
            ImportNormalMap("Image/foxmap.png");
        }

        private void SpotlightsOnButton_Click(object sender, EventArgs e)
        {
            Redrawing();
        }

        private void MainLightOutCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Redrawing();
        }

        private void SpotlightCosineBar_ValueChanged(object sender, EventArgs e)
        {
            Logic.SpotlightCosinePower = SpotlightCosineBar.Value;
            Redrawing();
        }

        private void TranslateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Redrawing();
        }

        private void AlphaBar_ValueChanged(object sender, EventArgs e)
        {
            if (TranslateCheckBox.Checked) Redrawing();
        }

        private void BetaBar_ValueChanged(object sender, EventArgs e)
        {
            if (TranslateCheckBox.Checked) Redrawing();
        }
    }
}