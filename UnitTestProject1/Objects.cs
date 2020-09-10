
using System;
using static System.Math;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3D_Components.lib;


namespace UnitTests
{

    [TestClass]
    public class Objects
    {
        /*todo
         * implement shape abstract class
         * then get plane as an inherited class
         * then specular
         * 
         * right now whats tricky is converting local space to world space, have I done that yet?
         * 
        */

        //objects

    [TestMethod]
    public void IntersectScaledwRay()
        {
            Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));

            Test_Object o = new Test_Object();
            o.scale(2, 2, 2);

            List<Intersection> xs = o.Intersects(r);




            //o.

        }

        [TestMethod]
        public void Transform_default()
        {
            Test_Object t = new Test_Object();
            Matrices m = new Matrices();
            Assert.AreEqual(t.transform.body, m.body);
        
        }

        [TestMethod]
        public void Transform_Apply()
        {
            Test_Object t = new Test_Object();
            t.translate(2, 3, 4);
            Assert.AreEqual(t.transform.body, new double[,] {
                                    { 1, 0, 0, 2 },
                                   { 0, 1, 0, 3 },
                                   { 0, 0, 1, 4 },
                                   { 0, 0, 0, 1 }
            });
        }

        double xAmount = 3;
        double yAmount = 4;
        double zAmount = 5;

        [TestMethod]
        public void Translate()
        {
            
            Test_Object t = new Test_Object();
            t.translate(xAmount, yAmount, zAmount);

            Matrices m = new Matrices(new double[,] {
                                      { 1, 0, 0, xAmount},
                                      { 0, 1, 0, yAmount},
                                      { 0, 0, 1, zAmount},
                                      { 0, 0, 0, 1 }
                                    }
                                    );
            Assert.AreEqual(m.body[1,0], t.transform.body[1, 0]);
            Assert.AreEqual(m.body[2, 3], t.transform.body[2, 3]);
        }
        [TestMethod]
        public void Scale()
        {

            Test_Object t = new Test_Object();
            t.scale(xAmount, yAmount, zAmount);

            Matrices m = new Matrices(new double[,] {
                                      { xAmount, 0, 0, 0},
                                      { 0, yAmount, 0, 0},
                                      { 0, 0, zAmount, 0},
                                      { 0, 0, 0, 1 }
                                    }
                                    );
            Assert.AreEqual(m, t.transform.body);
        }

        [TestMethod]
        public void RotateX()
        {

            Test_Object t = new Test_Object();
            t.rotateX(xAmount);

            Matrices m = new Matrices(new double[,] {
                                      { xAmount, 0, 0, 0},
                                      { 0, yAmount, 0, 0},
                                      { 0, 0, zAmount, 0},
                                      { 0, 0, 0, 1 }
                                    }
                                    );
            Assert.AreEqual(m, t.transform.body);
        }



        [TestMethod]
        public void Material_Apply()
        {
            Test_Object t = new Test_Object();
            Material m = new Material();
            m.ambient = 1;
            t.mat = m;
            Assert.AreEqual(m, t.mat);

        }



        //spheres
        [TestMethod]
        public void IntersectsAt2Points()
        {

            Ray r = new Ray(new Point(0, 0, -5), new Vector(0, 0, 1));
            Sphere s = new Sphere();
            List<Intersection> xs = s.Intersects(r);

            Assert.AreEqual(xs.Count, 2);
            Assert.AreEqual(4.0, xs[0].t);
            Assert.AreEqual(6.0, xs[1].t);

        



        }


        [TestMethod]
        public void IntersectsAtTangent()
        {

            Ray r = new Ray(new Point(0, 1, -5), new Vector(0, 0, 1));
            Sphere s = new Sphere();
            List<Intersection> xs = s.Intersects(r);

            Assert.AreEqual(xs.Count, 2);
            Assert.AreEqual(5.0, xs[0].t);
            Assert.AreEqual(5.0, xs[1].t);
        }

        [TestMethod]
        public void MissesSphere()
        {

            Ray r = new Ray(new Point(0, 2, -5), new Vector(0, 0, 1));
            Sphere s = new Sphere();
            List<Intersection> xs = s.Intersects(r);
            

            Assert.AreEqual(xs.Count, 0);
        }

        [TestMethod]
        public void OriginatesInSphere()
        {

            Ray r = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));
            Sphere s = new Sphere();
            List<Intersection> xs = s.Intersects(r);

            Assert.AreEqual(xs.Count, 2);
            Assert.AreEqual(-1.0, xs[0].t);
            Assert.AreEqual(1.0, xs[1].t);
        }

        [TestMethod]
        public void BehindRay()
        {

            Ray r = new Ray(new Point(0, 0, 5), new Vector(0, 0, 1));
            Sphere s = new Sphere();
            List<Intersection> xs = s.Intersects(r);

            Assert.AreEqual(xs.Count, 2);
            Assert.AreEqual(-6.0, xs[0].t);
            Assert.AreEqual(-4.0, xs[1].t);
        }



    }
}
