using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class Intersection
    {
        public double t;
        public Objects obj;
        public Ray ray;


        public Intersection(double T, Objects Obj, Ray R)
        {
            t = T;
            obj = Obj;
            ray = R;
        }
    }

    public struct HitRecord
    {
        public Point hitPoint;
        public Vector normalVec;
        public Vector eyeVec;
        public Vector lightVec;

        public bool inside;

        public Point overPoint;
        public Point underPoint;
    }
}
