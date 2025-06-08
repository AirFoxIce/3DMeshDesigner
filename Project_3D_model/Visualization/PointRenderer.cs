using System;
using System.Drawing;
using Project_3D_model.MathCore;

namespace Project_3D_model.Visualization
{
    public static class PointRenderer
    {
        public static Point To2D(Point3D point, Point center, float scale, float angleZ = 0f)
        {
            // Поворот вокруг оси Z
            float radZ = angleZ * (float)Math.PI / 180f;
            float x = point.X * (float)Math.Cos(radZ) - point.Y * (float)Math.Sin(radZ);
            float y = point.X * (float)Math.Sin(radZ) + point.Y * (float)Math.Cos(radZ);
            float z = point.Z;

            // Проекция
            float angle = Style.ProjectionAngleRadians;
            float x2d = -(x - y) * (float)Math.Cos(angle);
            float y2d = -(x + y) * (float)Math.Sin(angle) + z;

            // Экранные координаты
            int screenX = center.X + (int)(x2d * scale);
            int screenY = center.Y - (int)(y2d * scale);

            return new Point(screenX, screenY);
        }
    }
}
