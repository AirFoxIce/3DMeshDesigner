using System.Collections.Generic;
using Project_3D_model.MathCore;

namespace Project_3D_model.Data
{
    public static class GeometryExamples
    {
        public static GeometrySet GetStylishExample1()
        {
            var set = new GeometrySet();

            // Нижняя плоскость — параллелограмм
            set.PlaneA = new List<List<Point3D>>
            {
                new List<Point3D> { new Point3D(0, 0, 0), new Point3D(1, 0.5f, 0), new Point3D(2, 1, 0) },
                new List<Point3D> { new Point3D(0, 1, 0), new Point3D(1, 1.5f, 0), new Point3D(2, 2, 0) },
                new List<Point3D> { new Point3D(0, 2, 0), new Point3D(1, 2.5f, 0), new Point3D(2, 3, 0) }
            };

            // Верхняя плоскость — ломаная трапеция
            set.PlaneB = new List<List<Point3D>>
            {
                new List<Point3D> { new Point3D(0, 0, 4), new Point3D(1, 0.5f, 5), new Point3D(2, 1, 3.5f) },
                new List<Point3D> { new Point3D(0, 1, 5), new Point3D(1, 1.5f, 6), new Point3D(2, 2, 4.5f) },
                new List<Point3D> { new Point3D(0, 2, 4), new Point3D(1, 2.5f, 5), new Point3D(2, 3, 4) }
            };

            // Три известные направляющие с 5 точками, слегка изогнутые
            set.KnownGuides = new List<List<Point3D>>
            {
               new List<Point3D>
               {
                    new Point3D(1, 1.5f, 0),
                    new Point3D(0.7f, 1.5f, 1.5f),
                   new Point3D(0.5f, 1.5f, 3.0f),
                   new Point3D(0.7f, 1.5f, 4.5f),
                   new Point3D(1, 1.5f, 6)
               },

               new List<Point3D>
               {
                   new Point3D(2, 3, 0),
                   new Point3D(2.3f, 3, 1.2f),
                   new Point3D(2.6f, 3, 2.5f),
                   new Point3D(2.3f, 3, 3.5f),
                   new Point3D(2, 3, 4)
               },

               new List<Point3D>
               {
                   new Point3D(0, 0, 0),
                   new Point3D(-0.4f, 0, 1.0f),
                   new Point3D(-0.6f, 0, 2.0f),
                   new Point3D(-0.4f, 0, 3.0f),
                   new Point3D(0, 0, 4)
               }

            };

            return set;
        }

        public static GeometrySet GetStylishExample2()
        {
            var set = new GeometrySet();

            // Нижняя ломаная плоскость (4x4)
            set.PlaneA = new List<List<Point3D>>
    {
        new List<Point3D> { new Point3D(0, 0, 0), new Point3D(1, 0.3f, 0.2f), new Point3D(2, 0.6f, -0.1f), new Point3D(3, 1, 0) },
        new List<Point3D> { new Point3D(0, 1, -0.2f), new Point3D(1, 1.2f, 0.1f), new Point3D(2, 1.3f, -0.3f), new Point3D(3, 1.4f, 0.2f) },
        new List<Point3D> { new Point3D(0, 2, 0.4f), new Point3D(1, 2.3f, 0f), new Point3D(2, 2.4f, 0.3f), new Point3D(3, 2.5f, -0.2f) },
        new List<Point3D> { new Point3D(0, 3, 0), new Point3D(1, 3.2f, 0.4f), new Point3D(2, 3.3f, -0.1f), new Point3D(3, 3.5f, 0.3f) }
    };

            // Верхняя ломаная плоскость (4x4)
            set.PlaneB = new List<List<Point3D>>
    {
        new List<Point3D> { new Point3D(0, 0, 4), new Point3D(1, 0.3f, 5.2f), new Point3D(2, 0.6f, 4.1f), new Point3D(3, 1, 5) },
        new List<Point3D> { new Point3D(0, 1, 5.1f), new Point3D(1, 1.2f, 6.2f), new Point3D(2, 1.3f, 4.8f), new Point3D(3, 1.4f, 6.0f) },
        new List<Point3D> { new Point3D(0, 2, 4.5f), new Point3D(1, 2.3f, 5.4f), new Point3D(2, 2.4f, 5.0f), new Point3D(3, 2.5f, 4.7f) },
        new List<Point3D> { new Point3D(0, 3, 4), new Point3D(1, 3.2f, 5.5f), new Point3D(2, 3.3f, 5.2f), new Point3D(3, 3.5f, 4.9f) }
    };

            // 4 сильно изогнутые направляющие
            set.KnownGuides = new List<List<Point3D>>
    {
        new List<Point3D>
        {
            new Point3D(0, 0, 0),
            new Point3D(-0.3f, 0.2f, 1.5f),
            new Point3D(0.2f, 0.5f, 3f),
            new Point3D(0.1f, 0.3f, 4.5f),
            new Point3D(0, 0, 4)
        },
        new List<Point3D>
        {
            new Point3D(3, 3.5f, 0.3f),
            new Point3D(2.6f, 3.2f, 1.2f),
            new Point3D(3.2f, 3.1f, 2.8f),
            new Point3D(3.4f, 3.3f, 4),
            new Point3D(3, 3.5f, 4.9f)
        },
        new List<Point3D>
        {
            new Point3D(1, 1.2f, 0.1f),
            new Point3D(0.8f, 1.3f, 1.6f),
            new Point3D(1.3f, 1.2f, 3.1f),
            new Point3D(1.1f, 1.2f, 4.3f),
            new Point3D(1, 1.2f, 6.2f)
        },
        new List<Point3D>
        {
            new Point3D(2, 2.4f, 0.3f),
            new Point3D(2.2f, 2.6f, 1.7f),
            new Point3D(1.9f, 2.5f, 3.2f),
            new Point3D(2.1f, 2.4f, 4.6f),
            new Point3D(2, 2.4f, 5.8f)
        }
    };

            return set;
        }

        public static GeometrySet GetStylishExample3()
        {
            var set = new GeometrySet();

            // Нижняя плоскость (ровная)
            set.PlaneA = new List<List<Point3D>>
    {
        new List<Point3D> { new Point3D(0, 0, 0), new Point3D(5, 0, 0), new Point3D(10, 0, 0) },
        new List<Point3D> { new Point3D(0, 5, 0), new Point3D(5, 5, 0), new Point3D(10, 5, 0) },
        new List<Point3D> { new Point3D(0, 10, 0), new Point3D(5, 10, 0), new Point3D(10, 10, 0) }
    };

            // Верхняя плоскость (приподнята по Z под углом)
            set.PlaneB = new List<List<Point3D>>
    {
        new List<Point3D> { new Point3D(0, 0, 5), new Point3D(5, 0, 6), new Point3D(10, 0, 7) },
        new List<Point3D> { new Point3D(0, 5, 6), new Point3D(5, 5, 7), new Point3D(10, 5, 8) },
        new List<Point3D> { new Point3D(0, 10, 7), new Point3D(5, 10, 8), new Point3D(10, 10, 9) }
    };

            // Две сильно изогнутые направляющие
            set.KnownGuides = new List<List<Point3D>>
    {
        new List<Point3D>
        {
            new Point3D(0, 0, 0),
            new Point3D(-1, 0.5f, 1),
            new Point3D(1, 1.2f, 2),
            new Point3D(-0.5f, 2.1f, 3),
            new Point3D(0.5f, 3.5f, 4),
            new Point3D(-0.7f, 4.5f, 5),
            new Point3D(0.8f, 5.5f, 6),
            new Point3D(-0.2f, 7f, 7),
            new Point3D(0.3f, 8.5f, 8),
            new Point3D(0, 10, 9)
        },
        new List<Point3D>
        {
            new Point3D(10, 10, 0),
            new Point3D(10.8f, 9.5f, 1),
            new Point3D(9.5f, 8.8f, 2),
            new Point3D(10.2f, 7.5f, 3),
            new Point3D(9.3f, 6.3f, 4),
            new Point3D(10.5f, 5.0f, 5),
            new Point3D(9.8f, 3.7f, 6),
            new Point3D(10.1f, 2.3f, 7),
            new Point3D(9.6f, 1.0f, 8),
            new Point3D(10, 0, 9)
        }
    };

            return set;
        }

        public static GeometrySet GetStylishExample4()
        {
            var set = new GeometrySet();

            // Нижняя плоскость (ровная)
            set.PlaneA = new List<List<Point3D>>
    {
        new List<Point3D> { new Point3D(0, 0, 0), new Point3D(5, 0, 0), new Point3D(10, 0, 0) },
        new List<Point3D> { new Point3D(0, 5, 0), new Point3D(5, 5, 0), new Point3D(10, 5, 0) },
        new List<Point3D> { new Point3D(0, 10, 0), new Point3D(5, 10, 0), new Point3D(10, 10, 0) }
    };

            // Верхняя плоскость (ровная, под углом по Z)
            set.PlaneB = new List<List<Point3D>>
    {
        new List<Point3D> { new Point3D(0, 0, 10), new Point3D(5, 0, 11), new Point3D(10, 0, 12) },
        new List<Point3D> { new Point3D(0, 5, 11), new Point3D(5, 5, 12), new Point3D(10, 5, 13) },
        new List<Point3D> { new Point3D(0, 10, 12), new Point3D(5, 10, 13), new Point3D(10, 10, 14) }
    };

            // Две сильно хаотичные направляющие (по диагонали)
            set.KnownGuides = new List<List<Point3D>>
    {
        new List<Point3D> // от (0,0,0) до (0,0,10)
        {
            new Point3D(0, 0, 0),
            new Point3D(-1, 0.3f, 2),
            new Point3D(1.5f, -0.5f, 3.5f),
            new Point3D(-0.7f, 1.2f, 5),
            new Point3D(0.8f, 0.8f, 6),
            new Point3D(-0.9f, -0.6f, 7.2f),
            new Point3D(1.2f, 1.5f, 8),
            new Point3D(0.5f, 0.4f, 8.9f),
            new Point3D(-0.4f, 0.1f, 9.6f),
            new Point3D(0, 0, 10)
        },

        new List<Point3D> // от (10,10,0) до (10,10,14)
        {
            new Point3D(10, 10, 0),
            new Point3D(11.2f, 9.5f, 2),
            new Point3D(9.5f, 11.2f, 3.5f),
            new Point3D(10.5f, 10.1f, 5),
            new Point3D(8.9f, 9.3f, 6.3f),
            new Point3D(10.8f, 10.6f, 7.7f),
            new Point3D(9.6f, 8.8f, 9),
            new Point3D(10.4f, 10.3f, 11),
            new Point3D(9.7f, 10.5f, 12.5f),
            new Point3D(10, 10, 14)
        }
    };

            return set;
        }

    }
}
