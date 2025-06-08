using System;
using System.Collections.Generic;
using System.Drawing;
using Project_3D_model.MathCore;

namespace Project_3D_model.Visualization
{
    public static class PlaneRenderer
    {
        // === Основной метод отрисовки плоскости ===
        public static void DrawPlane(
            Graphics g,
            List<List<Point3D>> plane,
            Point center,
            float scale,
            float angleZ,
            Pen pen,
            Brush pointBrush,
            int pointRadius)
        {
            var rows = plane;

            DrawPoints(g, rows, center, scale, angleZ, pointBrush, pointRadius);
            DrawHorizontalLines(g, rows, center, scale, angleZ, pen);
            DrawVerticalLines(g, rows, center, scale, angleZ, pen);
            DrawSingleColumnLines(g, rows, center, scale, angleZ, pen);
        }

        // === Отрисовка точек ===
        private static void DrawPoints(Graphics g, List<List<Point3D>> rows, Point center, float scale, float angleZ, Brush brush, int radius)
        {
            foreach (var row in rows)
            {
                foreach (var point in row)
                {
                    Point screen = PointRenderer.To2D(point, center, scale, angleZ);
                    g.FillEllipse(brush, screen.X - radius / 2, screen.Y - radius / 2, radius, radius);
                }
            }
        }

        // === Горизонтальные линии между точками одной строки ===
        private static void DrawHorizontalLines(Graphics g, List<List<Point3D>> rows, Point center, float scale, float angleZ, Pen pen)
        {
            foreach (var row in rows)
            {
                for (int i = 0; i < row.Count - 1; i++)
                {
                    Point a = PointRenderer.To2D(row[i], center, scale, angleZ);
                    Point b = PointRenderer.To2D(row[i + 1], center, scale, angleZ);
                    g.DrawLine(pen, a, b);
                }
            }
        }

        // === Вертикальные линии между строками ===
        private static void DrawVerticalLines(Graphics g, List<List<Point3D>> rows, Point center, float scale, float angleZ, Pen pen)
        {
            int columnCount = rows[0].Count;

            for (int x = 0; x < columnCount; x++)
            {
                for (int y = 0; y < rows.Count - 1; y++)
                {
                    if (x < rows[y].Count && x < rows[y + 1].Count)
                    {
                        Point a = PointRenderer.To2D(rows[y][x], center, scale, angleZ);
                        Point b = PointRenderer.To2D(rows[y + 1][x], center, scale, angleZ);
                        g.DrawLine(pen, a, b);
                    }
                }
            }
        }

        // === Последовательные линии, если каждая строка содержит только одну точку ===
        private static void DrawSingleColumnLines(Graphics g, List<List<Point3D>> rows, Point center, float scale, float angleZ, Pen pen)
        {
            if (rows.TrueForAll(r => r.Count == 1) && rows.Count > 1)
            {
                for (int i = 0; i < rows.Count - 1; i++)
                {
                    Point a = PointRenderer.To2D(rows[i][0], center, scale, angleZ);
                    Point b = PointRenderer.To2D(rows[i + 1][0], center, scale, angleZ);
                    g.DrawLine(pen, a, b);
                }
            }
        }
    }
}
