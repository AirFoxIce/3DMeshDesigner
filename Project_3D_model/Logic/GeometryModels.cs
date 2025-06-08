using System.Collections.Generic;
using Project_3D_model.MathCore;

namespace Project_3D_model.Data
{
    public class GeometrySet
    {
        public List<List<Point3D>> PlaneA { get; set; } = new List<List<Point3D>>();
        public List<List<Point3D>> PlaneB { get; set; } = new List<List<Point3D>>();

        public int GridWidth { get; set; }
        public int GridHeight { get; set; }

        public List<List<Point3D>> KnownGuides { get; set; } = new List<List<Point3D>>();
        public List<List<Point3D>> ComputedGuides { get; set; } = new List<List<Point3D>>();

    }
}
