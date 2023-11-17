using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangularMesh
{
    internal class TriangleVertex
    {
        static int[] B = { 1, 3, 3, 1 };
        double x;
        double y;
        double z;
        public TriangleVertex(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public void CalculateZ()
        {
            double[] Bx = new double[4];
            double[] By = new double[4];
            Parallel.For(0, 4, (i) =>
            {
                Bx[i] = B[i] * Math.Pow(x, i) * Math.Pow(1 - x, 3 - i);
                By[i] = B[i] * Math.Pow(y, i) * Math.Pow(1 - y, 3 - i);
            });

            z = 0;
            Parallel.For(0, 4, (i) =>
            {
                Parallel.For(0, 4, (j) =>
                {
                    z += Logic.z_ControlPoints[i, j] * Bx[i] * By[j];
                });
            });
        }
    }
    internal class Triangle
    {
        TriangleVertex A;
        TriangleVertex B;
        TriangleVertex C;
    }
}
