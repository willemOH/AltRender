using System;
using static System.Math;
using System.Collections.Generic;


namespace _3D_Components.lib
{
    public class Sphere : Objects
    {
        VMath m = new VMath();
        Point op = new Point(0, 0, 0); //origin point

        public override List<Intersection> Intersects(Ray r) //intersections with Sphere
        {
            List<Intersection> Intersections = new List<Intersection>();

            Ray objSpaceRay = r.Transform(transform.Inverse()); //converts ray from worldspace to object space

            
            Tuple o = objSpaceRay.orig - op;
            double a = objSpaceRay.direct.Dot(objSpaceRay.direct);
            double b = o.Dot(objSpaceRay.direct) * 2;
            double c = o.Dot(o) - 1;
            double discrim = (b * b) - (4.0 * a * c);

            if (discrim < 0)

            { }
              

            else if (discrim == 0)
            {
                double t2;
                double t1 = t2 = -b / (2*a);

                Intersections.Add(new Intersection(t1, this, r));
                Intersections.Add(new Intersection(t2, this, r));
            }
            else
            {
                double t1 = (-b - Math.Sqrt(discrim)) / (2*a);
                double t2 = (-b + Math.Sqrt(discrim)) / (2*a);

                Intersections.Add(new Intersection(t1, this, r));
                Intersections.Add(new Intersection(t2, this, r));
            }

            return Intersections;

        }


        public override Vector Normal_at(Point p)
        {
            return (p - op).AsVector();
        }

    }

   
        

    


    




}


