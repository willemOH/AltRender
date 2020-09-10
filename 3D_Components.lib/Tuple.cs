using System;


namespace _3D_Components.lib
{

    public class Tuple
    {
        //public double[] tuple = new double[3];
        public double x, y, z, w;


        public Tuple(double x_coord, double y_coord, double z_coord, double w_value)
        {
            //double[] tuple_ini = new double[] { x_coord, y_coord, z_coord, w_value };

            x = x_coord;
            y = y_coord;
            z = z_coord;
            w = w_value;
        }

        public Point AsPoint()
        {
            return new Point(x, y, z);
        }

        public Vector AsVector()
        {
            return new Vector(x, y, z);
        }

        public Color AsColor()
        {
            return new Color(x, y, z);
        }
        public static Tuple operator +(Tuple a, Tuple b)
        {
            return new Tuple((a.x + b.x), (a.y + b.y), (a.z + b.z), a.w);
        }

        public static Tuple operator -(Tuple a, Tuple b)
        {
            return new Tuple((a.x - b.x), (a.y - b.y), (a.z - b.z), a.w);
        }

        public static Tuple operator -(Tuple a)
        {
            return new Tuple(-a.x , -a.y, -a.z, -a.w);
        }

        public static Tuple operator *(Tuple a, double b)
        {
            return new Tuple(a.x * b, a.y * b, a.z * b, a.w * b);
        }
       
        public static Tuple operator /(Tuple a, double b)
        {
            return new Tuple(a.x / b, a.y / b, a.z / b, a.w / b);
        }

        public double Mag() //magnitude
        {
            return Math.Sqrt((x * x) + (y * y) + (z * z));
        }

        public double Dot(Tuple b) // dot product
        {
            return (this.x * b.x + this.y * b.y + this.z * b.z);
        }

        public Tuple Cross(Tuple b) //cross product
        {
            return new Tuple(this.y * b.z - this.z * b.y, this.z * b.x - this.x * b.z, this.x * b.y - this.y * b.x, 0.0);
        }


        public Vector ReflectedVectorOver(Vector otherVector) //reflected over the otherVector
        {
            
            Vector inputVector = new Vector(x, y, z);
            return ((otherVector * 2 * otherVector.Dot(inputVector))-inputVector).AsVector();
        }

        public void Translate(double x,double y,double z)
        {
            Matrices translate = new Matrices();
            translate.body[0, 3] = x;    //begin shaping ID matrix into transform matrix
            translate.body[1, 3] = y;
            translate.body[2, 3] = z;

            
             this.x = (translate * this).x; //more efficient way?
             this.y = (translate * this).y;
             this.z = (translate * this).z;

        }

        public void Scale(double x,double y,double z)
        {
            Matrices scale = new Matrices();
            scale.body[0, 3] = x;
            scale.body[1, 3] = y;
            scale.body[2, 3] = z;

            
             this.x = (scale * this).x; //more efficient way?
             this.y = (scale * this).y;
             this.z = (scale * this).z;

        } 

    }



    

   

    




}

    



