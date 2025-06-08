using System;
using System.Drawing;

namespace Project_3D_model.Visualization
{
    public static class Style
    {
        // === Геометрия проекции ===
        public const float ProjectionAngleDegrees = 15f;
        public static readonly float ProjectionAngleRadians =
            ProjectionAngleDegrees * (float)Math.PI / 180f;

        // === Масштабирование и вращение ===
        public const float DefaultScale = 50f;
        public const float MinScale = 1f;
        public const float MaxScale = 500f;
        public const float RotationSensitivity = 0.5f;
        public const int CenterOffsetY = 100;

        // === Цвет фона ===
        public static readonly Color BackgroundColor = Color.FromArgb(43, 47, 58);

        // === Положение осей ===
        public const int AxisOriginX = 100;
        public const int AxisOriginY = 50;

        // === Сетка ===
        public static readonly Pen GridPen = new Pen(Color.FromArgb(40, 200, 200, 200), 1); // серый
        public const float GridBaseSize = 10f;
        public const float GridExpansionFactor = 4f;
        public const float GridStep = 1f;

        // === Оси координат ===
        public static readonly Pen AxisPen = new Pen(Color.FromArgb(100, 241, 78, 149), 2); // бледно-розовый
        public static readonly Brush AxisLabelBrush = new SolidBrush(Color.FromArgb(100, 241, 78, 149));
        public static readonly Font AxisLabelFont = new Font("Segoe UI", 9, FontStyle.Regular);
        public const float AxisLength = 1.4f;

        // === Плоскости ===
        public static readonly Pen PlaneBPen = new Pen(Color.Red, 2);
        public static readonly Pen PlaneAPen = new Pen(Color.Green, 2);
        public static readonly Brush PlanePointBrush = new SolidBrush(Color.FromArgb(0, 255, 159));
        public const int PlanePointRadius = 8;

        // === Направляющие ===
        public static readonly Pen KnownGuidePen = new Pen(Color.Yellow, 1);   // жёлтый
        public static readonly Pen ComputedGuidePen = new Pen(Color.Blue, 1);    // фиолетовый

        public static readonly Brush KnownGuideBrush = new SolidBrush(Color.FromArgb(255, 234, 0));
        public static readonly Brush ComputedGuideBrush = new SolidBrush(Color.FromArgb(170, 0, 255));
        public const int GuidePointRadius = 8;
    }
}
