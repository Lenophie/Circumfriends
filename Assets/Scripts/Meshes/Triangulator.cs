using System.Collections.Generic;
using UnityEngine;

namespace Meshes {
    /**
     * Generates the triangles of a mesh given its vertices
     * Courtesy of http://wiki.unity3d.com/index.php/Triangulator
     */
    public class Triangulator
    {
        private readonly List<Vector2> mPoints;

        public Triangulator (IEnumerable<Vector2> points) {
            mPoints = new List<Vector2>(points);
        }

        public int[] Triangulate() {
            List<int> indices = new List<int>();

            int n = mPoints.Count;
            if (n < 3)
                return indices.ToArray();

            int[] V = new int[n];
            if (Area() > 0) {
                for (int v = 0; v < n; v++)
                    V[v] = v;
            }
            else {
                for (int v = 0; v < n; v++)
                    V[v] = (n - 1) - v;
            }

            int nv = n;
            int count = 2 * nv;
            for (int v = nv - 1; nv > 2; ) {
                if ((count--) <= 0)
                    return indices.ToArray();

                int u = v;
                if (nv <= u)
                    u = 0;
                v = u + 1;
                if (nv <= v)
                    v = 0;
                int w = v + 1;
                if (nv <= w)
                    w = 0;

                if (Snip(u, v, w, nv, V)) {
                    int s, t;
                    int a = V[u];
                    int b = V[v];
                    int c = V[w];
                    indices.Add(a);
                    indices.Add(b);
                    indices.Add(c);
                    for (s = v, t = v + 1; t < nv; s++, t++)
                        V[s] = V[t];
                    nv--;
                    count = 2 * nv;
                }
            }

            indices.Reverse();
            return indices.ToArray();
        }

        private float Area () {
            int n = mPoints.Count;
            float a = 0.0f;
            for (int p = n - 1, q = 0; q < n; p = q++) {
                Vector2 pval = mPoints[p];
                Vector2 qval = mPoints[q];
                a += pval.x * qval.y - qval.x * pval.y;
            }
            return (a * 0.5f);
        }

        private bool Snip (int u, int v, int w, int n, IReadOnlyList<int> V) {
            int p;
            Vector2 a = mPoints[V[u]];
            Vector2 b = mPoints[V[v]];
            Vector2 c = mPoints[V[w]];
            if (Mathf.Epsilon > (((b.x - a.x) * (c.y - a.y)) - ((b.y - a.y) * (c.x - a.x))))
                return false;
            for (p = 0; p < n; p++) {
                if ((p == u) || (p == v) || (p == w))
                    continue;
                Vector2 P = mPoints[V[p]];
                if (InsideTriangle(a, b, c, P))
                    return false;
            }
            return true;
        }

        private static bool InsideTriangle (Vector2 a, Vector2 b, Vector2 c, Vector2 p) {
            float ax = c.x - b.x; float ay = c.y - b.y;
            float bx = a.x - c.x; float by = a.y - c.y;
            float cx = b.x - a.x; float cy = b.y - a.y;
            float apx = p.x - a.x; float apy = p.y - a.y;
            float bpx = p.x - b.x; float bpy = p.y - b.y;
            float cpx = p.x - c.x; float cpy = p.y - c.y;

            float aCROSSbp = ax * bpy - ay * bpx;
            float cCROSSap = cx * apy - cy * apx;
            float bCROSScp = bx * cpy - @by * cpx;

            return ((aCROSSbp >= 0.0f) && (bCROSScp >= 0.0f) && (cCROSSap >= 0.0f));
        }
    }
}