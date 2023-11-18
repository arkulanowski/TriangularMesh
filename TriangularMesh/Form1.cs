using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace TriangularMesh
{
    public partial class TriangularMesh : Form
    {
        DirectBitmap DrawArea;
        Pen DrawingPen;
        public TriangularMesh()
        {
            InitializeComponent();
            Logic.z_ControlPoints = new double[4, 4];
            Logic.z_ControlPoints[0, 0] = -1.0; 
            Logic.z_ControlPoints[1, 0] = 1.0;
            Logic.z_ControlPoints[2, 3] = 1.0;
            Logic.m = 5;
            Logic.n = 5;
            Logic.DispersedFactor = 0.5;
            Logic.SpecularFactor = 0.5;
            Logic.SpecularM = 1;
            Logic.Recalculate();
            DrawingPen = new Pen(Brushes.Purple); 
            Redrawing();
        }
        void Redrawing()
        {
            DrawArea = new DirectBitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = DrawArea.Bitmap;
            int WidthCorrected = Canvas.Width - 1;
            int HeightCorrected = Canvas.Height - 1;

            int x2canvx(double x)
            {
                return Convert.ToInt32(WidthCorrected * x);
            }
            int y2canvy(double y)
            {
                return Convert.ToInt32(HeightCorrected * (1 - y));
            }
            double canvx2x(int canvx)
            {
                return 1.0 * canvx / WidthCorrected;
            }
            double canvy2y(int canvy)
            {
                return 1.0 - (1.0 * canvy / HeightCorrected);
            }
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
                        Vector3D N = l1 * triangle.A.Normal + l2 * triangle.B.Normal + l3 * triangle.C.Normal;
                        N.Normalize();
                        Vector3D L = Logic.LightSource - new Vector3D(x, y, z);
                        L.Normalize();
                        double dot = Vector3D.DotProduct(N, L);
                        Vector3D R = 2 * dot * (N - L);
                        R.Normalize();
                        double dot2 = Vector3D.DotProduct(Logic.ToObserver, R);

                        double Red = (Logic.LightColor.R / 255.0) * (Logic.PlaneColor.R / 255.0);
                        double Green = (Logic.LightColor.G / 255.0) * (Logic.PlaneColor.G / 255.0);
                        double Blue = (Logic.LightColor.B / 255.0) * (Logic.PlaneColor.B / 255.0);
                        double k = 0;
                        if (dot > 0) k += Logic.DispersedFactor * dot;
                        if (dot2 > 0) k += Logic.SpecularFactor * Math.Pow(dot2, Logic.SpecularM);
                        Red = Math.Min(255, (Red * k) * 255.0);
                        Green = Math.Min(255, (Green * k) * 255.0);
                        Blue = Math.Min(255, (Blue * k) * 255.0);

                        Colors[point.X, point.Y] = Color.FromArgb(Convert.ToByte(Red),
                            Convert.ToByte(Green), Convert.ToByte(Blue));
                    });
                });

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
            }
            Canvas.Refresh();
        }

        private void MeshVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Redrawing();
        }
    }
}