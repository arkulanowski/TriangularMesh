namespace TriangularMesh
{
    public partial class TriangularMesh : Form
    {
        public TriangularMesh()
        {
            Logic.z_ControlPoints = new float[4, 4];
            Logic.m = 1;
            Logic.n = 1;
            InitializeComponent();
        }
    }
}