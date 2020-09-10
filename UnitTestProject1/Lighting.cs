
using System;
using static System.Math;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3D_Components.lib;


namespace UnitTests
{

    [TestClass]
    public class Lighting
    {
        
        [TestMethod]
        public void PointLight()
        {
            Color intensity = new Color(1, 1, 1);
            Point position = new Point(0, 0, 0);
            Light light = new PointLight(position, intensity);

            light.pos = position;
            light.intensity = 1;
            light.col = intensity.AsColor();

        }

       [TestMethod]
       public void Material()
        {
            Material m = new Material();
            Assert.AreEqual(m.baseColor, new Color(1, 1, 1));
            Assert.AreEqual(m.ambient, 0.1);
            Assert.AreEqual(m.diffuse, .9);
            Assert.AreEqual(m.specular, .9);
            Assert.AreEqual(m.shininess, 200.0);

        }

        [TestMethod]
        public void DefaultMaterial()
        {
            Sphere s = new Sphere();

            Material m = s.mat;

            Assert.AreEqual(s.mat, new _3D_Components.lib.Material());
           
        }

        [TestMethod]
        public void MaterialOnSphere()
        {
            Sphere s = new Sphere();

            Material m = new _3D_Components.lib.Material();
            m.ambient = 1;

            s.mat = m;

            Assert.AreEqual(s.mat, m);

        }

        Material m = new Material();
        Point position = new Point(0, 0, 0);

        [TestMethod]

        public void eyeBetweenLightAndSurface()
        {
            Vector eyev = new Vector(0, 0, -1);
            Vector normalv = new Vector(0, 0, -1);
            Light light = new PointLight(new Point(0, 0, -10), new Color(1, 1, 1));

            HitRecord hit = new HitRecord();
            hit.eyeVec = eyev;
            hit.normalVec = normalv;
            hit.hitPoint = position;
            

            World world = new World();
            world.AddLight(light);
            world.AddObject(new Sphere());

            Color result = m.ColorAtPoint(hit, world); 

            Assert.AreEqual(new Color(1.9, 1.9, 1.9), result);

        }

    }
}
