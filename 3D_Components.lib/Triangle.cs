using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class Triangle : Objects
    {
        public Point a; //getA from mesh //look in book for groups //calls intersectionswith on all objects/mesh triangles
        public Point b;
        public Point c;

        public Vector axisA;
        public Vector axisB;

        public Vector normal;

        public double t;
        public double Gamma;
        public double Beta;

        public bool triHit;

        public Triangle(Point pointA, Point pointB, Point pointC)
        {
            pointA = a;
            pointB = b;
            pointC = c;

            axisA = (a - b).AsVector();
            axisB = (a - c).AsVector();

            normal = (axisA.Cross(axisB)).AsVector();
        }
        public void CramersLaw(Vector axisA, Vector axisB, Point origin, Vector ray)
        {
            Vector AMinusO = (a - origin).AsVector();

            Matrices denominatorMatrix = new Matrices(new double[,]
                                                {
                                                    { axisA.x }, {axisB.x}, {ray.x},
                                                    { axisA.y}, {axisB.y}, {ray.y},
                                                    {axisA.z}, {axisB.z}, {ray.z}
                                                }
                                                );
            double denominator = denominatorMatrix.Deter3x3(denominatorMatrix);

            Matrices solveBeta = new Matrices(new double[,]
                                               {
                                                   { AMinusO.x }, { axisA.x }, { axisB.x }, //putting AMinusO solution in place of beta to solve for beta
                                                   { AMinusO.y }, { axisA.y }, { axisB.y },
                                                   { AMinusO.z }, { axisA.z }, { axisB.z },
                                               }
                                                );
            double BetaNumerator = solveBeta.Deter3x3(solveBeta);
            Beta = BetaNumerator / denominator;

            Matrices solveGamma = new Matrices(new double[,]
                                                {
                                                    { axisA.x }, {AMinusO.x}, {ray.x},
                                                    { axisA.y}, {AMinusO.y}, {ray.y},
                                                    {axisA.z}, {AMinusO.z}, {ray.z}
                                                }
                                                );

            double GammaNumerator = solveBeta.Deter3x3(solveGamma);
            Gamma = GammaNumerator / denominator;

            Matrices solveT = new Matrices(new double[,]
            {
                                                    { axisA.x }, {axisB.x}, {AMinusO.x},
                                                    { axisA.y}, {axisB.y}, {AMinusO.y},
                                                    {axisA.z}, {axisB.z}, {AMinusO.z}
                                                }
                                                );


            double TNumerator = solveBeta.Deter3x3(solveT);
            t = TNumerator / denominator;



        }

        public override Vector Normal_at(Point p) //parameter vestigal?
        {
            Matrices inverseMatrix = transform.Inverse(); //override in mesh triangle class to mesh.transform.inverse to transform mesh as a whole
            inverseMatrix.Transpose();
            return (inverseMatrix* normal).AsVector();
        }

        public override List<Intersection> Intersects(Ray r) 
        {
            List<Intersection> Intersections = new List<Intersection>();

            Ray objectSpace = r.Transform(transform.Inverse());


            this.CramersLaw(axisA, axisB, r.orig, r.direct);

            if (Beta >= 0 && Gamma >= 0 && Beta + Gamma <= 1)
            {
                Intersections.Add(new Intersection(t, this, r));
            }
            else
            { }

            return Intersections;

        }
    }
    
}
