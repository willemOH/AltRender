using System;
using System.Collections.Generic;
using _3D_Components.lib;

namespace AltRender
{
    class Program //dont use single variable names!!!!! can delete this when you do that
    {
        static void Main(string[] args)
        {
            //all this was commented out so I could do some linear algebra homework
            /*
            Camera cam = new Camera(160, 120);
            //Color testColor = new Color(0, .5, .7);
            World testWorld = new World();

            //Sphere sphere1 = new Sphere();
            //sphere1.translate(.5, 0, 0);
            // testWorld.AddObject(sphere1);

            Sphere sphere2 = new Sphere();
            sphere2.translate(50, .5, .5);
            testWorld.AddObject(sphere2);

            //Plane wall = new Plane();
            //wall.mat.baseColor = new Color(1, 0, 0);
            //wall.rotateX(Math.PI / 2);
            //testWorld.AddObject(wall);

            Canvas testCanvas = new Canvas(100, 100);

            Point lightPoint = new Point(0, 5, 0);
            Point lightPoint2 = new Point(5, 5, 0);
            testWorld.AddLight(new PointLight(lightPoint, C_col.white));
            testWorld.AddLight(new PointLight(lightPoint2, C_col.red));

            


            
            Render render = new Render(testCanvas, testWorld);

        
        
            
           */
            /*
             float moveXValue = 4;
             float moveYValue = 1;
             for (int i = 1; i <= 8; i++)
             {

                 Matrices a = new Matrices(3);
                 a.body = new double[,] {{ 1, 0, -(moveXValue) },
                                         { 0, 1, 0 },
                                         { 0, 0, 1 } };
                 Matrices b = new Matrices(3);
                 b.body = new double[,] {{ 1, 0, 0 },
                                         { 0, 1, -(moveYValue) },
                                         { 0, 0, 1 } };
                 Matrices c = new Matrices(3);
                 b.body = new double[,] {{ 1/Math.Sqrt(2), -(1/Math.Sqrt(2)), 0 },
                                         { 1/Math.Sqrt(2), 1/Math.Sqrt(2), 0 },
                                         { 0, 0, 1 } };
                 Matrices d = new Matrices(3);
                 b.body = new double[,] {{ 1, 0, 0 },
                                         { 0, 1, (moveYValue) },
                                         { 0, 0, 1 } };
                 Matrices e = new Matrices(3);
                 b.body = new double[,] {{ 1, 0, moveXValue-(.5*i) },
                                         { 0, 1, 0 },
                                         { 0, 0, 1 } };

                 Matrices total = a * b;

                 Console.Write(total.body[0, 0] + " ");
                 Console.Write(total.body[0, 1] + " ");
                 Console.WriteLine(total.body[0, 2]);
                 Console.Write(total.body[1, 0] + " ");
                 Console.Write(total.body[1, 1] + " ");
                 Console.WriteLine(total.body[1, 2]);
                 Console.Write(total.body[2, 0] + " ");
                 Console.Write(total.body[2, 1] + " ");
                 Console.Write(total.body[2, 2]);

                 if(i<5)
                 moveYValue =-.25f;
                 if(i>5)
                 moveYValue = +.25f;

             }
             */
            Matrices composed = new Matrices(3);
            composed.body = new double[,] {{ 1, 0, 4 },
                                        { 0, 1, 0 },
                                        { 0, 0, 1 } }; ;

            for (int i = 5; i <= 12; i++)
            {

                Matrices a = composed;


                Matrices b = new Matrices(3);
                b.body = new double[,] {{ 1/Math.Sqrt(2), -(1/Math.Sqrt(2)), 0 },
                                        { 1/Math.Sqrt(2), 1/Math.Sqrt(2), 0 },
                                        { 0, 0, 1 } };
                Matrices c = new Matrices(3);
                c.body = new double[,] {{ 1, 0, 0 },
                                        { 0, 1, 1 },
                                        { 0, 0, 1 } };


                Matrices multiply = b * c;

                Matrices total = a * multiply;
                composed = total;

                Console.WriteLine(i);
                Console.Write(total.body[0, 0] + " ");
                Console.Write(total.body[0, 1] + " ");
                Console.WriteLine(total.body[0, 2]);
                Console.Write(total.body[1, 0] + " ");
                Console.Write(total.body[1, 1] + " ");
                Console.WriteLine(total.body[1, 2]);
                Console.Write(total.body[2, 0] + " ");
                Console.Write(total.body[2, 1] + " ");
                Console.Write(total.body[2, 2]);
                Console.WriteLine();
                Console.WriteLine();



            }


            }
        }
}
