
using System;
using static System.Math;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3D_Components.lib;


namespace UnitTests
{

    [TestClass]
    public class MatrixTests
    {

        [TestMethod]
        public void Inspect4X4()
        {

            Matrices M = new Matrices(new double[,] 
                                    {
                                       { 1, 2, 3, 4 },
                                       { 5.5, 6.5, 7.5, 8.5 },
                                       { 9, 8, 7, 6 },
                                       { 0, 0, 0, 1 }
                                    }
                                    );
           

            Assert.AreEqual(M.body[0, 0], 1);
            Assert.AreEqual(M.body[1, 2], 7.5);
            Assert.AreEqual(M.body[3, 2], 0);




        }

        [TestMethod]
        public void Inspect3X3()
        {

            Matrices M = new Matrices( new double[,]
                                                { 
                                                    { -3, 5, 0},
                                                    { 1, -2, -7},
                                                    { 0, 1, 1},
                                                }
                                            );

           

            Assert.AreEqual(M.body[0, 0], -3);
            Assert.AreEqual(M.body[1, 1], -2);
            Assert.AreEqual(M.body[2, 2], 1);
        }

        [TestMethod]
        public void Inspect2X2()
        {

            Matrices M = new Matrices(new double[,] 
                                     { 
                                       { -3, 5},
                                       { 1, -2},
                                     }
                                    );
             

            Assert.AreEqual(M.body[0, 0], -3);
            Assert.AreEqual(M.body[0, 1], 5);
            Assert.AreEqual(M.body[1, 0], 1);
            Assert.AreEqual(M.body[1, 1], -2);
        }


        [TestMethod]
        public void Equality()
        {

            Matrices A = new Matrices(
                         new double[,] { { 1, 2, 3, 4 },
                                       { 5, 6, 7, 8 },
                                       { 9, 8, 7, 6 },
                                       { 0, 0, 0, 1 }
                                           }
                                     );

             
            Matrices B = new Matrices(
                         new double[,] { 
                                       { 1, 2, 3, 4 },
                                       { 5, 6, 7, 8 },
                                       { 9, 8, 7, 6 },
                                       { 0, 0, 0, 1 }
                                       }
                                      );
            

            Assert.AreEqual(A.body[0, 0], B.body[0, 0]);
            Assert.AreEqual(A.body[1, 2], B.body[1, 2]);
            Assert.AreEqual(A.body[2, 2], B.body[2, 2]);
            Assert.AreEqual(A.body[3, 3], B.body[3, 3]);
        }

        [TestMethod]
        public void Multiply()
        {
            Matrices matrixA = new Matrices(
                            new double[,] { { 1, 2, 3, 4 },
                                          { 5, 6, 7, 8 },
                                          { 9, 8, 7, 6 },
                                          { 0, 0, 0, 1 }
                                        }
                );
           

            Matrices matrixB = new Matrices(
                            new double[,] { {-2, 1, 2, 3 },
                                          { 3, 2, 1,-1 },
                                          { 4, 3, 6, 5 },
                                          { 0, 0, 0, 1 }
                                        }
                                        );
             

            Matrices matrixC = new Matrices(matrixA.MulMatrix(matrixA.body, matrixB.body));

            

            Assert.AreEqual(matrixC.body[0, 0], 16);
            Assert.AreEqual(matrixC.body[2, 2], 68);
            Assert.AreEqual(matrixC.body[3, 2], 0);


        }

        [TestMethod]
        public void TupleMul()
        {
            Matrices A = new Matrices(
                                new double[,]
                                    { {1,2,3,4},
                                      {2,4,4,2},
                                      {8,6,4,1},
                                      {0,0,0,1}
                                    }
                                        );
              
      

            _3D_Components.lib.Tuple b = new _3D_Components.lib.Tuple(1, 2, 3, 1);
            _3D_Components.lib.Tuple compare = new _3D_Components.lib.Tuple(18, 24, 33, 1);
            _3D_Components.lib.Tuple bMul = new _3D_Components.lib.Tuple(1, 2, 3, 1);

            bMul = A * b;

            Assert.AreEqual(compare.x, bMul.x);
            Assert.AreEqual(compare.y, bMul.y);
            Assert.AreEqual(compare.z, bMul.z);
            Assert.AreEqual(compare.w, bMul.w);
        }

        [TestMethod]

        public void MulbyID()
        {
            Matrices A = new Matrices(
                                    new double[,]
                                    { {0,1,2,4},
                                      {1,2,4,8},
                                      {2,4,8,16},
                                      {0,0,0,1}
                                    }
                );

            Matrices B = new Matrices(A.MulMatrix(A.body, A.body));
           

           


            Assert.AreEqual(A.body[0, 0], B.body[0, 0]);
            Assert.AreEqual(A.body[2, 2], B.body[2, 2]);
            Assert.AreEqual(A.body[3, 1], B.body[3, 1]);
            Assert.AreEqual(A.body[3, 3], B.body[3, 3]);
        }

        [TestMethod]

        public void subMatrix()
        {
            Matrices m = new Matrices(
                new double[,]  {
                                       {1, 5,  0},
                                       {-3, 2, 7},
                                       {0, 6, -3}
                               }
                );
           

            Matrices sub = new Matrices(m.SubMatrix(0, 2));
            

            Assert.AreEqual(m.body[2, 0], sub.body[1, 0]);
            Assert.AreEqual(m.body[1, 0], sub.body[0, 0]);
            Assert.AreEqual(m.body[2, 1], sub.body[1, 1]);
            Assert.AreEqual(m.body[1, 1], sub.body[0, 1]);


        }

        [TestMethod]

        public void subMatrix4x4()
        {
            Matrices m = new Matrices(
                new double[,]  {
                                       {1, 5,  0, 4},
                                       {-3, 2, 7, 5},
                                       {0, 6, -3, 6},
                                       {3, 5, 3, 7 }
                               }
                );


            Matrices sub = new Matrices(m.SubMatrix(0, 3));


          
            Assert.AreEqual(m.body[1, 0], sub.body[0, 0]);
            Assert.AreEqual(m.body[2, 1], sub.body[1, 1]);
            Assert.AreEqual(m.body[1, 2], sub.body[0, 2]);
            Assert.AreEqual(7, sub.body[0, 2]);
            Assert.AreEqual(3, sub.body[2, 2]);


        }

        [TestMethod]

        public void Determinant2x2()
        {
            Matrices m = new Matrices(
                      new double[,]  {
                                       {1,5},
                                       {-3,2}
                                      }
                );
           
            Assert.AreEqual(17, m.Deter2x2(m));
        }

        [TestMethod]

        public void Determinant3x3()
        {

            Matrices m = new Matrices(new double[,]
                            {
                              {1, 2, 6},
                              {-5,8,-4},
                              {2,6, 4}
                             }
                             );
          

            Assert.AreEqual(-196, m.Deter3x3(m));
        }

        [TestMethod]
        public void Determinant4x4()
        {
            double[,] test = {
                                       {-2, -8, 3, 5},
                                       {-3, 1, 7, 3},
                                       {1,2,-9, 6 },
                                       {0, 0, 0, 1}
                                      };

            Matrices m = new Matrices(test);
            

            Assert.AreEqual(185, m.Deter4x4(m));
        }

        [TestMethod]
        public void Determinant4x4SelfRef()
        {
            double[,] test = {
                                       {-2, -8, 3, 5},
                                       {-3, 1, 7, 3},
                                       {1,2,-9, 6 },
                                       {0, 0, 0, 1}
                                      };

            Matrices m = new Matrices(test);


            Assert.AreEqual(185, m.Deter4x4());
        }

        [TestMethod]
        public void Determinant4x4Detect()
        {
            double[,] test = {
                                       {-2, -8, 3, 5},
                                       {-3, 1, 7, 3},
                                       {1,2,-9, 6 },
                                       {0, 0, 0, 1}
                                      };

            Matrices m = new Matrices(test);


            Assert.AreEqual(185, m.Determinant());
            Assert.AreEqual(185, m.Deter4x4());
        }



        [TestMethod]
        public void Cofactor()
        {
            Matrices A = new Matrices(new double[,] { { 3, 5, 0 },
                                                      { 2,-1,-7 },
                                                      { 6,-1, 5 }
                                                    });

            Assert.AreEqual(-12, A.Minor(0, 0));
            Assert.AreEqual(-12, A.Cofactor(0, 0));
            Assert.AreEqual(25, A.Minor(1, 0));
            Assert.AreEqual(-25, A.Cofactor(1, 0));


        }

        [TestMethod]
    
        public void Minor()
        {
            Matrices a = new Matrices(new double[,]{ { 3, 5, 0},
                                                    { 2,-1,-7},
                                                    { 6,-1, 5}
                                                    });

            Matrices b = new Matrices(a.SubMatrix(1, 0));

            Assert.AreEqual(25, b.Deter2x2());
            Assert.AreEqual(25, a.Minor(1, 0));
        }


        [TestMethod]

        public void invertCan()
        {
            Matrices m = new Matrices(new double[,] { { 6, 4, 4, 4 },
                                                      { 5, 5, 7, 6 },
                                                      { 4,-9, 3,-7 },
                                                      { 9, 1, 7,-6 }
                                                    });
            Assert.AreEqual(-2120, m.Determinant());
            Assert.AreEqual(true, m.invertible);
        }

        [TestMethod]
        public void invertCannot()
        {
            Matrices m = new Matrices(new double[,] { {-4, 2,-2,-3 },
                                                      { 9, 6, 2, 6 },
                                                      { 0,-5, 1,-5 },
                                                      { 0, 0, 0, 0 }
                                                    });
            Assert.AreEqual(0, m.Determinant());
       
        }

        [TestMethod]
        public void invert()
        {
            Matrices A = new Matrices(new double[,] { {-5, 2, 6,-8 },
                                                      { 1,-5, 1, 8 },
                                                      { 7, 7,-6,-7 },
                                                      { 1,-3, 7, 4 }
                                                    });

         
            Matrices B = A.Inverse();


           
            Assert.AreEqual(532, A.Determinant());
            Assert.AreEqual(-160, A.Cofactor(2, 3));
            Assert.AreEqual(-160.0 / 532, B.body[3, 2]);
            Assert.AreEqual(105, A.Cofactor(3, 2));
            Assert.AreEqual(105.0 / 532, B.body[2, 3]);
            Assert.IsTrue(Abs(.24060 - B.body[0, 2]) < 0.001);
            Assert.IsTrue(Abs(.19737 - B.body[2, 3]) < 0.001);


        }

        [TestMethod]

        public void moreinvert()
        {
            Matrices M = new Matrices(new double[,] {{ 8,-5, 9, 2 },
                                                     { 7, 5, 6, 1 },
                                                     {-6, 0, 9, 6 },
                                                     {-3, 0,-9,-4 }
                                                    });
            Matrices invert_M = M.Inverse();
          

            Assert.IsTrue(Abs(-0.15385 - invert_M.body[0, 0]) < .001);
            Assert.IsTrue(Abs(-0.15385 - invert_M.body[0, 1]) < .001);
            Assert.IsTrue(Abs(0.92308 - invert_M.body[2, 3]) < .001);
            Assert.IsTrue(Abs(-1.92308 - invert_M.body[3, 3]) < .001);
        }
        public void Translation()
        {
            Matrices m = new Matrices();

        }

       


        /*
        [TestMethod]
        
        public void Translation()
        {
            Matrices m = new Matrices();

        }
        */


    }
}
