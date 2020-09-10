using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class World
    {
        public List<Objects> objs = new List<Objects>();
        public List<Light> lights = new List<Light>();
        
        public void AddObject(Objects s)
        {
            objs.Add(s);
        }

        public void AddLight(Light l)
        {
            lights.Add(l);
        }


        public List<Intersection> IntersectionsWith(Ray r)
        {
            List<Intersection> allIntersections = new List<Intersection>();

            foreach(Objects obj in objs)
            {
                allIntersections.AddRange(obj.Intersects(r));
            }

            IntersectionComparer ic = new IntersectionComparer();

            allIntersections.Sort(ic);

            return allIntersections;
        }
    }

    public class IntersectionComparer : IComparer<Intersection>
    {
        public int Compare(Intersection a, Intersection b)
        {
            return a.t.CompareTo(b.t);
        }
    }
}
