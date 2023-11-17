﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangularMesh
{
    internal static class Logic
    {
        internal static float[,] z_ControlPoints;
        internal static TriangleVertex[,] Vertices;
        internal static Triangle[,,] Triangles;
        internal static int m;
        internal static int n;
        public static void Recalculate()
        {
            Vertices = new TriangleVertex[m + 1, n + 1];
            Triangles = new Triangle[m, n, 2];
            double x_StepSize = 1.0 / m;
            double y_StepSize = 1.0 / n;

            Parallel.For(0, m + 1, (i) =>
            {
                Parallel.For(0, n + 1, (j) =>
                {
                    Vertices[i, j] = new TriangleVertex(i * x_StepSize, j * y_StepSize);
                    Vertices[i, j].CalculateZ();
                });
            });

            Parallel.For(0, m + 1, (i) =>
            {
                Parallel.For(0, n + 1, (j) =>
                {
                    Triangles[i, j, 0] = new Triangle(Vertices[i, j], Vertices[i + 1, j], Vertices[i + 1, j + 1]);
                    Triangles[i, j, 1] = new Triangle(Vertices[i, j], Vertices[i, j + 1], Vertices[i + 1, j + 1]);
                });
            });
        }
    }
}