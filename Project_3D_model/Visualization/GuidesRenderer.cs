using System.Collections.Generic;
using System.Drawing;
using Project_3D_model.MathCore;

namespace Project_3D_model.Visualization
{
    public static class GuidesRenderer
    {
        // === Отрисовка направляющих линий ===
        public static void DrawGuides(Graphics g, List<List<Point3D>> guides, Point center, float scale, float angleZ, Pen pen)
        {
            foreach (var guide in guides)
            {
                for (int i = 0; i < guide.Count - 1; i++)
                {
                    Point p1 = Project(guide[i], center, scale, angleZ);
                    Point p2 = Project(guide[i + 1], center, scale, angleZ);
                    g.DrawLine(pen, p1, p2);
                }
            }
        }

        // === Отрисовка точек направляющих ===
        public static void DrawGuidePoints(Graphics g, List<List<Point3D>> guides, Point center, float scale, float angleZ, Brush brush, int radius)
        {
            foreach (var guide in guides)
            {
                foreach (var point in guide)
                {
                    Point p = Project(point, center, scale, angleZ);
                    g.FillEllipse(
                        brush,
                        p.X - radius / 2,
                        p.Y - radius / 2,
                        radius,
                        radius
                    );
                }
            }
        }

        // === Перевод 3D-точки в экранные координаты ===
        private static Point Project(Point3D point, Point center, float scale, float angleZ)
        {
            return PointRenderer.To2D(point, center, scale, angleZ);
        }
    }
}
