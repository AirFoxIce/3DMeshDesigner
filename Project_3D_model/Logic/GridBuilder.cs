using System;
using System.Collections.Generic;
using Project_3D_model.MathCore;

public static class GuideBuilder
{
    public static List<List<Point3D>> BuildComputedGuides(
        List<List<Point3D>> planeA,
        List<List<Point3D>> planeB,
        List<List<Point3D>> knownGuides)
    {
        int rows = planeA.Count;
        int cols = planeA[0].Count;
        int n = knownGuides[0].Count;

        var result = new List<List<Point3D>>();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                var start = planeA[i][j];
                var end = planeB[i][j];

                // Пропускаем, если уже задана в knownGuides
                bool isKnown = false;
                foreach (var guide in knownGuides)
                {
                    var knownStart = guide[0];
                    if (knownStart.X == start.X && knownStart.Y == start.Y && knownStart.Z == start.Z)
                    {
                        isKnown = true;
                        break;
                    }
                }
                if (isKnown) continue;

                var forward = BuildOneDirection(start, end, knownGuides, n);
                var backward = BuildOneDirection(end, start, ReverseGuides(knownGuides), n);
                backward.Reverse();

                var merged = MergeSequences(forward, backward);
                result.Add(merged);
            }
        }

        return result;
    }

    private static List<Point3D> BuildOneDirection(Point3D start, Point3D end, List<List<Point3D>> knownGuides, int n)
    {
        var result = new List<Point3D> { start };
        float sharpness = 3f;

        for (int k = 1; k < n - 1; k++)
        {
            var current = result[k - 1];

            var distances = new List<float>();
            var vectors = new List<Point3D>();

            foreach (var known in knownGuides)
            {
                var prev = known[k - 1];
                var next = known[k];

                float dx = current.X - prev.X;
                float dy = current.Y - prev.Y;
                float dz = current.Z - prev.Z;

                float dist = (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
                distances.Add(dist);

                vectors.Add(new Point3D(next.X - prev.X, next.Y - prev.Y, next.Z - prev.Z));
            }

            var coeffs = new List<float>();
            float totalWeight = 0;
            for (int m = 0; m < distances.Count; m++)
            {
                float weight;
                if (distances[m] > 0)
                    weight = (float)Math.Exp(-sharpness * distances[m]);
                else
                    weight = 1f;

                coeffs.Add(weight);
                totalWeight += weight;
            }

            for (int m = 0; m < coeffs.Count; m++)
                coeffs[m] /= totalWeight;

            float vx = 0, vy = 0, vz = 0;
            for (int m = 0; m < vectors.Count; m++)
            {
                vx += vectors[m].X * coeffs[m];
                vy += vectors[m].Y * coeffs[m];
                vz += vectors[m].Z * coeffs[m];
            }

            result.Add(new Point3D(current.X + vx, current.Y + vy, current.Z + vz));
        }

        result.Add(end);
        return result;
    }

    private static List<List<Point3D>> ReverseGuides(List<List<Point3D>> guides)
    {
        var reversed = new List<List<Point3D>>();
        foreach (var g in guides)
        {
            var copy = new List<Point3D>(g);
            copy.Reverse();
            reversed.Add(copy);
        }
        return reversed;
    }

    private static List<Point3D> MergeSequences(List<Point3D> forward, List<Point3D> backward)
    {
        int n = forward.Count;
        var merged = new List<Point3D> { forward[0] };

        for (int k = 1; k < n - 1; k++)
        {
            int d1 = k;
            int d2 = n - 1 - k;

            var f = forward[k];
            var b = backward[k];

            var mergedPoint = new Point3D(
                (f.X * d2 + b.X * d1) / (d1 + d2),
                (f.Y * d2 + b.Y * d1) / (d1 + d2),
                (f.Z * d2 + b.Z * d1) / (d1 + d2)
            );

            merged.Add(mergedPoint);
        }

        merged.Add(forward[n - 1]);
        return merged;
    }
}
