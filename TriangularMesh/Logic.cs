using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace TriangularMesh
{
    internal static class Logic
    {
        internal static double[] xy_ControlPoints = { 0, 1.0 / 3, 2.0 / 3, 1 };
        internal static double[,] z_ControlPoints;
        internal static TriangleVertex[,] Vertices;
        internal static Triangle[] Triangles;
        internal static int m;
        internal static int n;
        internal static double DispersedFactor;
        internal static double SpecularFactor;
        internal static int SpecularM;
        internal static Vector3D ToObserver = new Vector3D(0.5, 0.5, 1);
        internal static Vector3D LightSource = new Vector3D(0.5, 0.5, 1);
        internal static Color LightColor = Color.White;
        internal static Color[,] SurfaceColor;
        internal static (int, int) ChosenControlPoint;
        public static void Recalculate()
        {
            Vertices = new TriangleVertex[m + 1, n + 1];
            Triangles = new Triangle[2 * m * n];
            double x_StepSize = 1.0 / m;
            double y_StepSize = 1.0 / n;

            Parallel.For(0, m + 1, (i) =>
            {
                Parallel.For(0, n + 1, (j) =>
                {
                    Vertices[i, j] = new TriangleVertex(i * x_StepSize, j * y_StepSize);
                    Vertices[i, j].CalculateZ();
                    Vertices[i, j].CalculateNormal();
                });
            });

            Parallel.For(0, m, (i) =>
            {
                Parallel.For(0, n, (j) =>
                {
                    Triangles[2 * n * i + 2 * j] = new Triangle(Vertices[i, j], Vertices[i + 1, j], Vertices[i + 1, j + 1]);
                    Triangles[2 * n * i + 2 * j + 1] = new Triangle(Vertices[i, j], Vertices[i, j + 1], Vertices[i + 1, j + 1]);
                });
            });
        }
    }
}
