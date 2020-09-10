
using System;
using static System.Math;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3D_Components.lib;


namespace UnitTests
{

    [TestClass]
    public class Camera
    {
        
        [TestMethod]
        public void CameraConstruct()
        {
            Matrices ID = new Matrices();

            _3D_Components.lib.Camera cam = new _3D_Components.lib.Camera(160, 120, Math.PI / 2);

            Assert.AreEqual(cam.hsize, 160);
            Assert.AreEqual(cam.vsize, 120);
            Assert.AreEqual(cam.FOV, Math.PI / 2);
            Assert.AreEqual(cam.transform.body, ID.body);
        }

        public void PixelSizeH()
        {
            _3D_Components.lib.Camera cam = new _3D_Components.lib.Camera(200, 125, Math.PI / 2);
            Assert.AreEqual(cam.pixel_size, 0.01);


        }

        public void PixelSizeV()
        {
            _3D_Components.lib.Camera cam = new _3D_Components.lib.Camera(125, 200, Math.PI / 2);
            Assert.AreEqual(cam.pixel_size, 0.01);


        }

    }
}
