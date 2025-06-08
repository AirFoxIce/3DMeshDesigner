using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Project_3D_model.Visualization;
using Project_3D_model.MathCore;
using Project_3D_model.Data;

namespace Project_3D_model
{
    public partial class Form3DModel : Form
    {
        // === Параметры визуализации ===
        private Point center;             // Центр модели на канвасе
        private float scale = Style.DefaultScale;  // Масштаб модели
        private float angleZ = 0f;        // Вращение вокруг оси Z

        // === Управление мышью ===
        private bool isDragging = false;
        private bool isRotating = false;
        private Point lastMousePos;

        // === Глобальные данные ===
        private GeometrySet example = GeometryExamples.GetStylishExample1();

        public Form3DModel()
        {
            InitializeComponent();

            // Стартовая позиция центра модели
            center = new Point(canvas.Width / 2, canvas.Height / 2 + Style.CenterOffsetY);
            canvas.Image = new Bitmap(canvas.Width, canvas.Height);

            // Подписка на события
            canvas.MouseDown += canvas_MouseDown;
            canvas.MouseMove += canvas_MouseMove;
            canvas.MouseUp += canvas_MouseUp;
            canvas.MouseWheel += canvas_MouseWheel;
            canvas.MouseEnter += (s, e) => canvas.Focus();

            RedrawScene();
        }

        // === Сброс положения камеры ===
        private void buttonResetView_Click(object sender, EventArgs e)
        {
            center = new Point(canvas.Width / 2, canvas.Height / 2 + Style.CenterOffsetY);
            scale = Style.DefaultScale;
            angleZ = 0f;
            RedrawScene();
        }

        // === Кнопка расчёта направляющих ===
        private void buttonCompute_Click(object sender, EventArgs e)
        {
            example.ComputedGuides = GuideBuilder.BuildComputedGuides(
                example.PlaneA,
                example.PlaneB,
                example.KnownGuides
            );
            RedrawScene();
        }


        // === Основной метод отрисовки ===
        private void RedrawScene()
        {
            var bmp = new Bitmap(canvas.Width, canvas.Height);
            var g = Graphics.FromImage(bmp);
            g.Clear(Style.BackgroundColor);

            // Собираем точки для сетки
            var allPoints = new List<List<Point3D>>();
            allPoints.AddRange(example.PlaneA);
            allPoints.AddRange(example.PlaneB);

            // Сетка
            GridRenderer.DrawGrid(g, center, scale, angleZ, allPoints);

            // Оси
            Point fixedOrigin = new Point(Style.AxisOriginX, canvas.Height - Style.AxisOriginY);
            AxisRenderer.DrawAxes(g, fixedOrigin, angleZ);

            // Нижняя плоскость
            PlaneRenderer.DrawPlane(
                g, example.PlaneA, center, scale, angleZ,
                Style.PlaneAPen, Style.PlanePointBrush, Style.PlanePointRadius
            );

            // Верхняя плоскость
            PlaneRenderer.DrawPlane(
                g, example.PlaneB, center, scale, angleZ,
                Style.PlaneBPen, Style.PlanePointBrush, Style.PlanePointRadius
            );

            // Направляющие
            GuidesRenderer.DrawGuides(g, example.KnownGuides, center, scale, angleZ, Style.KnownGuidePen);
            GuidesRenderer.DrawGuidePoints(g, example.KnownGuides, center, scale, angleZ, Style.KnownGuideBrush, Style.GuidePointRadius);

            GuidesRenderer.DrawGuides(g, example.ComputedGuides, center, scale, angleZ, Style.ComputedGuidePen);
            GuidesRenderer.DrawGuidePoints(g, example.ComputedGuides, center, scale, angleZ, Style.ComputedGuideBrush, Style.GuidePointRadius);

            canvas.Image = bmp;
        }



        // === Обработка мыши ===
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastMousePos = e.Location;
            }
            else if (e.Button == MouseButtons.Right)
            {
                isRotating = true;
                lastMousePos = e.Location;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int dx = e.X - lastMousePos.X;
                int dy = e.Y - lastMousePos.Y;

                center.X += dx;
                center.Y += dy;
                lastMousePos = e.Location;

                RedrawScene();
            }
            else if (isRotating)
            {
                int dx = e.X - lastMousePos.X;
                angleZ += dx * Style.RotationSensitivity;
                lastMousePos = e.Location;

                RedrawScene();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) isDragging = false;
            if (e.Button == MouseButtons.Right) isRotating = false;
        }

        private void canvas_MouseWheel(object sender, MouseEventArgs e)
        {
            float delta = e.Delta > 0 ? 1.1f : 0.9f;
            float oldScale = scale;
            scale *= delta;

            scale = Math.Max(Style.MinScale, Math.Min(Style.MaxScale, scale));

            // Зум к курсору
            center.X = (int)(e.X - (e.X - center.X) * (scale / oldScale));
            center.Y = (int)(e.Y - (e.Y - center.Y) * (scale / oldScale));

            RedrawScene();
        }
    }
}
