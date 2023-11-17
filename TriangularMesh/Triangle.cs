using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace TriangularMesh
{
    internal class TriangleVertex
    {
        static int[] B = { 1, 3, 3, 1 };
        static int[] delB = { 1, 2, 1 };
        public double x;
        public double y;
        public double z;
        double[] Bx = new double[4];
        double[] By = new double[4];
        double[] delBx = new double[3];
        double[] delBy = new double[3];
        Vector3D Normal;
        public TriangleVertex(double x, double y)
        {
            this.x = x;
            this.y = y;
            Parallel.For(0, 4, (i) =>
            {
                Bx[i] = B[i] * Math.Pow(x, i) * Math.Pow(1 - x, 3 - i);
                By[i] = B[i] * Math.Pow(y, i) * Math.Pow(1 - y, 3 - i);
            });
        }
        public void CalculateZ()
        {
            z = 0;
            Parallel.For(0, 4, (i) =>
            {
                Parallel.For(0, 4, (j) =>
                {
                    z += Logic.z_ControlPoints[i, j] * Bx[i] * By[j];
                });
            });
        }
        public void CalculateNormal()
        {
            Parallel.For(0, 3, (i) =>
            {
                delBx[i] = delB[i] * Math.Pow(x, i) * Math.Pow(1 - x, 2 - i);
                delBy[i] = delB[i] * Math.Pow(y, i) * Math.Pow(1 - y, 2 - i);
            });

            double z_u = 0;
            double z_v = 0;
            Parallel.For(0, 3, (i) =>
            {
                Parallel.For(0, 4, (j) =>
                {
                    z_u += (Logic.z_ControlPoints[i + 1, j] - Logic.z_ControlPoints[i, j]) * delBx[i] * By[j];
                });
            });
            Parallel.For(0, 4, (i) =>
            {
                Parallel.For(0, 3, (j) =>
                {
                    z_v += (Logic.z_ControlPoints[i, j + 1] - Logic.z_ControlPoints[i, j]) * Bx[i] * delBy[j];
                });
            });

            Normal = Vector3D.CrossProduct(new Vector3D(1, 0, 3 * z_u), new Vector3D(0, 1, 3 * z_v));
        }
    }
    internal class Triangle
    {
        public TriangleVertex A;
        public TriangleVertex B;
        public TriangleVertex C;
        public Triangle(TriangleVertex a, TriangleVertex b, TriangleVertex c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}
