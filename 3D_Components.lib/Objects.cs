using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public abstract class Objects
    {

        public Matrices transform = new Matrices();


        public Material mat = new Material();

        public abstract Vector Normal_at(Point p);
        public abstract List<Intersection> Intersects(Ray r);

        public void translate(double x = 0, double y = 0, double z = 0)
        {
            double[,] body = {     { 1, 0, 0, x },
                                   { 0, 1, 0, y },
                                   { 0, 0, 1, z },
                                   { 0, 0, 0, 1 }
                                    };

            Matrices translate = new Matrices(body);
            transform = translate * transform;

        }

        public void scale(double x = 0, double y = 0, double z = 0)
        {
            double[,] body = {     { x, 0, 0, 0 },
                                   { 0, y, 0, 0 },
                                   { 0, 0, z, 0 },
                                   { 0, 0, 0, 1 }
                                    };

            Matrices scale = new Matrices(body);
            transform = scale * transform;
        }

        public void rotateX(double rot)
        {
            double[,] rotXmatrix = {
                                    {1, 0, 0, 0 },
                                    {0, Math.Cos(rot), -Math.Sin(rot), 0},
                                    {0, Math.Sin(rot), Math.Cos(rot), 0},
                                    {0,0,0,1 }

                };
        }

        public void rotateY(double rot)
        {
            double[,] rotYmatrix = {
                                    {Math.Cos(rot), 0, Math.Sin(rot), 0 },
                                    {0, 1, 0, 0},
                                    {-Math.Sin(rot), 0, Math.Cos(rot), 0},
                                    {0, 0, 0, 1 }

                };
        }

        public void rotateZ(double rot)
        {
            double[,] rotZmatrix = {
                                    {Math.Cos(rot), Math.Sin(rot), 0, 0 },
                                    {Math.Sin(rot), Math.Cos(rot), 0, 0},
                                    {0, 0, 1, 0},
                                    {0, 0, 0, 1 }

                };
        }





        //public Vector;

        //sphere has transfrom associated with it

    }

    public class Test_Object : Objects
    {
        public override Vector Normal_at(Point p)
        {
            return new Vector(0, 1, 0); //not actually true
        }
        public override List<Intersection> Intersects(Ray r)
        {
            Ray local_ray = r.Transform(this.transform.Inverse());

            return this.Intersects(local_ray);
        }

    }

    public class Plane : Objects
    {
        public override Vector Normal_at(Point p)
        {
            Matrices inverseMatrix = transform.Inverse();
            inverseMatrix.Transpose();
            return (inverseMatrix* new Vector(0, 1, 0)).AsVector();
        
        }

        public override List<Intersection> Intersects(Ray r)
        {
            List<Intersection> Intersections = new List<Intersection>();

            Ray objectSpaceRay = r.Transform(transform.Inverse());

            if (Math.Abs(r.direct.y) < VMath.epsilon)
            {
            }

            else if(Math.Abs(r.direct.y) > VMath.epsilon)
            {
                double t = (-r.orig.y) / (r.direct.y); //intersection formula
                Intersection intersect = new Intersection(t, this, r);

                Intersections.Add(intersect);
                
            }

            return Intersections;
        }
    }
}
