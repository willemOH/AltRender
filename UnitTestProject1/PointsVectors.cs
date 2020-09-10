using System;
using static System.Math;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3D_Components.lib;



namespace UnitTests
{
    
    [TestClass]
    public class PointsVectors
    {

        [TestMethod]
        public void isPoint()
        {
            double x = 4.3, y = -4.2, z = 3.1, w = 1.0;
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);

            Assert.AreEqual(1.0, w);
        }

        [TestMethod]
        public void isVector()
        {
            double x = 4.3, y = -4.2, z = 3.1, w = 0.0;
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);

            Assert.AreEqual(0.0, w);
        }

        [TestMethod]
        public void Point()
        {
            double x = 4.3, y = -4, z = 3;

            //Point p = new Point(x, y, z);
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, 1.0);

            Assert.AreEqual(a.w, a.w);
            Assert.AreEqual(a.x, a.x);
            Assert.AreEqual(a.y, a.y);
            Assert.AreEqual(a.z, a.z);
        }

        [TestMethod]
        public void Vector()
        {
            double x = 4.3, y = -4.2, z = 3.1;
            // Vector v = new Vector(x, y, z);
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, 0.0);

            Assert.AreEqual(a.w, a.w);
            Assert.AreEqual(a.x, a.x);
            Assert.AreEqual(a.y, a.y);
            Assert.AreEqual(a.z, a.z);
           

        }

        [TestMethod]
        public void Add()
        {
            double x = 3, y = -2, z = 5, w = 1;
            double x2 = -2, y2 = 3, z2 = 1, w2 = 0;
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);
            _3D_Components.lib.Tuple b = new _3D_Components.lib.Tuple(x2, y2, z2, w2);
            a += b;

            Assert.AreEqual(a.x, 1);
            Assert.AreEqual(a.y, 1);
            Assert.AreEqual(a.z, 6);
            Assert.AreEqual(a.w, 1 );

        }

        [TestMethod]
        public void Subtract()
        {
            double x = 3, y = 2, z = 1, w = 0;
            double x2 = 5, y2 = 6, z2 = 7, w2 = 0;

            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);
            _3D_Components.lib.Tuple b = new _3D_Components.lib.Tuple(x2, y2, z2, w2);
            a -= b;

            Assert.AreEqual(a.x, -2);
            Assert.AreEqual(a.y, -4);
            Assert.AreEqual(a.z, -6);
            Assert.AreEqual(a.w, 0);

        }

        [TestMethod]
        public void Negate()
        {
            double x = 1, y = -2, z = 3, w = -4;

            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);

            a = -a;

            Assert.AreEqual(a.x, -1);
            Assert.AreEqual(a.y, 2);
            Assert.AreEqual(a.z, -3);
            Assert.AreEqual(a.w, 4);

        }

        [TestMethod]
        public void MulFraction()
        {
            double x = 1, y = -2, z = 3, w = -4;
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);

                a *= 0.5;
                Assert.AreEqual(a.x, 0.5);
                Assert.AreEqual(a.y, -1);
                Assert.AreEqual(a.z, 1.5);
                Assert.AreEqual(a.w, -2);    
        }

        [TestMethod]
        public void MulScalar()
        {
            double x = 1, y = -2, z = 3, w = -4;
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);

            a *= 3.5;
            Assert.AreEqual(a.x, 3.5);
            Assert.AreEqual(a.y, -7);
            Assert.AreEqual(a.z, 10.5);
            Assert.AreEqual(a.w, -14);
        }

        [TestMethod]
        public void Divide()
        {
            double x = 1, y = -2, z = 3, w = -4;
            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(x, y, z, w);

            a /= 2;
            Assert.AreEqual(a.x, 0.5);
            Assert.AreEqual(a.y, -1);
            Assert.AreEqual(a.z, 1.5);
            Assert.AreEqual(a.w, -2);

        }




        [TestMethod]
        public void MagnitudeEqualsOne()
        {
            double xm = 0.0, ym =0.0, zm =0.0;

            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    xm = 0.0;
                    ym = 1.0;
                    zm = 0.0;
                }
                if (i == 1)
                {
                    xm = 0.0;
                    ym = 1.0;
                    zm = 0.0;
                }

                if (i == 2)
                {
                    xm = 0.0;
                    ym = 0.0;
                    zm = 1.0;
                }

                _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(xm, ym, zm, 0.0);
                Assert.AreEqual(a.Mag(), 1.0);
            }
        }

        [TestMethod]

        public void Ray()
        {
            Point origin = new Point(1, 2, 3);
            Vector direction = new Vector(4, 5, 6);
            Ray a = new Ray(origin, direction);
        
            Assert.AreEqual(a.orig, origin);
            Assert.AreEqual(a.direct, direction);

            

        }

        [TestMethod]

        public void Ray2()
        {
            VMath m = new VMath();
            Point origin2 = new Point(2, 3, 4);
            Vector direction2 = new Vector(1, 0, 0);
            Ray b = new Ray(origin2, direction2);

            Point test1 = new Point(3, 3, 4);
            Point test2 = new Point(1, 3, 4);
            Point test3 = new Point(4.5, 3, 4);
            Point epsilon = new Point(0.00001, 0.00001, 0.00001);
            _3D_Components.lib.Tuple errorTest = m.Pos(b, 1.0) - test1;
            Point input1 = m.Pos(b, 0.0);


            //Assert.AreEqual(input1, origin2);

            Assert.IsTrue(Math.Abs(errorTest.x) < epsilon.x);
            Assert.IsTrue(Math.Abs(errorTest.y) < epsilon.y);
            Assert.IsTrue(Math.Abs(errorTest.z) < epsilon.z);

            //Assert.AreEqual(m.Pos(b, -1.0), test2);
            //Assert.AreEqual(m.Pos(b, 2.5), test3);
        }
        /*
        [TestMethod]
        public void MagnitudeEqualsInverse()
        {

            _3D_Components.lib.Tuple a = new _3D_Components.lib.Tuple(1.0, 2.0, 3.0, 0.0);
.
            Assert.AreEqual(a.Mag(), Math.Sqrt(14));

            a = -a;

            Assert.AreEqual(a.Mag(), Math.Sqrt(14));

        }
        */

        

    }
}
