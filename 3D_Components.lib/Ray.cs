using System;


namespace _3D_Components.lib
{
    public class Ray
    {
        public Point orig;
        public Vector direct;
        public Ray(Point origin, Vector direction)
        {
            orig = origin;
            direct = direction;
        }

        public Point PointAtT(double t)
        {
            return (orig + direct * t).AsPoint();
            
        }


        public Ray Transform(Matrices matrix)
        {
            Ray transform = new Ray((matrix * orig).AsPoint(), (matrix * direct).AsVector());
            return transform;
        }
    }
}
