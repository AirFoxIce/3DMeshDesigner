using System.Drawing;
using Project_3D_model.MathCore;

namespace Project_3D_model.Visualization
{
    public static class AxisRenderer
    {
        // === Отрисовка координатных осей ===
        public static void DrawAxes(Graphics g, Point center, float angleZ)
        {
            float length = Style.AxisLength;

            // Точки начала и концов осей в 3D
            var origin = new Point3D(0, 0, 0);
            var xEnd = new Point3D(length, 0, 0);
            var yEnd = new Point3D(0, length, 0);
            var zEnd = new Point3D(0, 0, length);

            // Перевод в экранные координаты
            Point p0 = Project(origin, center, angleZ);
            Point px = Project(xEnd, center, angleZ);
            Point py = Project(yEnd, center, angleZ);
            Point pz = Project(zEnd, center, angleZ);

            // Линии осей
            g.DrawLine(Style.AxisPen, p0, px);
            g.DrawLine(Style.AxisPen, p0, py);
            g.DrawLine(Style.AxisPen, p0, pz);

            // Подписи
            g.DrawString("X", Style.AxisLabelFont, Style.AxisLabelBrush, px.X + 5, px.Y - 5);
            g.DrawString("Y", Style.AxisLabelFont, Style.AxisLabelBrush, py.X + 5, py.Y - 5);
            g.DrawString("Z", Style.AxisLabelFont, Style.AxisLabelBrush, pz.X + 5, pz.Y - 5);
        }

        // === Проекция точки 3D -> 2D ===
        private static Point Project(Point3D point, Point center, float angleZ)
        {
            return PointRenderer.To2D(point, center, Style.DefaultScale, angleZ);
        }
    }
}
