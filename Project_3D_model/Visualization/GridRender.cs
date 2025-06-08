using System;
using System.Collections.Generic;
using System.Drawing;
using Project_3D_model.MathCore;

namespace Project_3D_model.Visualization
{
    public static class GridRenderer
    {
        public static void DrawGrid(Graphics g, Point center, float scale, float angleZ, List<List<Point3D>> allPoints)
        {
            float maxX = 0f;
            float maxY = 0f;

            // Смотрим, насколько далеко уходят точки модели по X и Y
            foreach (var row in allPoints)
            {
                foreach (var p in row)
                {
                    maxX = Math.Max(maxX, Math.Abs(p.X));
                    maxY = Math.Max(maxY, Math.Abs(p.Y));
                }
            }

            // Решаем, какой радиус сетки использовать
            float size = (maxX > Style.GridBaseSize || maxY > Style.GridBaseSize)
                ? Style.GridBaseSize * Style.GridExpansionFactor
                : Style.GridBaseSize;

            float z = 0f;

            // Горизонтальные линии (по Y)
            for (float y = -size; y <= size; y += Style.GridStep)
            {
                var a = new Point3D(-size, y, z);
                var b = new Point3D(size, y, z);
                g.DrawLine(Style.GridPen, Project(a, center, scale, angleZ), Project(b, center, scale, angleZ));
            }

            // Вертикальные линии (по X)
            for (float x = -size; x <= size; x += Style.GridStep)
            {
                var a = new Point3D(x, -size, z);
                var b = new Point3D(x, size, z);
                g.DrawLine(Style.GridPen, Project(a, center, scale, angleZ), Project(b, center, scale, angleZ));
            }
        }

        private static Point Project(Point3D point, Point center, float scale, float angleZ)
        {
            return PointRenderer.To2D(point, center, scale, angleZ);
        }
    }
}
