using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace TriangularMesh
{
    public partial class TriangularMesh : Form
    {
        Bitmap DrawArea;
        Pen DrawingPen;
        public TriangularMesh()
        {
            InitializeComponent();
            Logic.z_ControlPoints = new float[4, 4];
            Logic.m = 5;
            Logic.n = 5;
            Logic.Recalculate();
            DrawingPen = new Pen(Brushes.Purple); 
            Redrawing();
        }
        void Redrawing()
        {
            DrawArea = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = DrawArea;
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
                return canvx / WidthCorrected;
            }
            double canvy2y(int canvy)
            {
                return 1.0 - (canvy / HeightCorrected);
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

            using (Graphics g = Graphics.FromImage(DrawArea))
            {
                Color[,] Colors = new Color[Canvas.Width, Canvas.Height];
                Vector3D V = new Vector3D(0, 0, 1);
                Parallel.For(0, Canvas.Width, (i) =>
                {
                    Parallel.For(0, Canvas.Height, (j) =>
                    {
                        double x = canvx2x(i);
                        double y = canvy2y(j);
                        int p = (int)Math.Floor(x * Logic.m);
                        int q = (int)Math.Floor(y * Logic.n);
                        int r = x > y ? 1 : 0;
                        Triangle triangle = Logic.Triangles[2 * Logic.n * p + 2 * q + r];
                        (double l1, double l2, double l3) = barycentric(x, y, triangle);
                        double z = l1 * triangle.A.z + l2 * triangle.B.z + l3 * triangle.C.z;
                        Vector3D Normal = l1 * triangle.A.Normal + l2 * triangle.B.Normal + l3 * triangle.C.Normal;
                        Vector3D L = new Vector3D(0.5 - x, 0.5 - y, 1 - z);
                        L.Normalize();
                        double dot = Vector3D.DotProduct(Normal, L);
                        Vector3D R = 2 * dot * (Normal - L);
                        int rgb = Convert.ToByte(dot + Vector3D.DotProduct(V, R));
                        Colors[i, j] = Color.FromArgb(rgb, rgb, rgb);
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
    }
}