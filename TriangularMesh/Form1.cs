namespace TriangularMesh
{
    public partial class TriangularMesh : Form
    {
        public TriangularMesh()
        {
            InitializeComponent();
            Logic.z_ControlPoints = new float[4, 4];
        }
    }
}