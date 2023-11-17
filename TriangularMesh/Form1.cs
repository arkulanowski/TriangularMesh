namespace TriangularMesh
{
    public partial class TriangularMesh : Form
    {
        const int LINE_WIDTH = 1;

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
                return canvx / (Canvas.Width - 1.0);
            }
            double canvy2y(int canvy)
            {
                return 1.0 - (canvy / (Canvas.Height - 1.0));
            }

            DrawArea = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = DrawArea;

            using (Graphics g = Graphics.FromImage(DrawArea))
            {
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