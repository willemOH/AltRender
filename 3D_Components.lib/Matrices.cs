using System;
using System.Collections.Generic;
using System.Text;

namespace _3D_Components.lib
{
    public class Matrices
    {

        public double[,] body = {     { 1, 0, 0, 0 },
                                      { 0, 1, 0, 0 },
                                      { 0, 0, 1, 0 },
                                      { 0, 0, 0, 1 }
                                    };

        public int size;

        public bool invertible = true;

        public Matrices()
        {
            size = 4;
        }
        public Matrices(int matrixSize)
        {
            body = new double[matrixSize, matrixSize];
            size = matrixSize;
        }
        public Matrices(double[,] b)
        {
            body = b;
            size = b.GetLength(0);

        }

        public static Matrices operator *(Matrices a, Matrices b)
        {
            int size = a.body.GetLength(0);

            Matrices M = new Matrices();

            for (int i = 0; i < size; i++) //for each row of A
            {
                for (int o = 0; o < size; o++) //for each column of B
                {
                    M.body[i, o] = 0;
                    for (int j = 0; j < size; j++) //adding up multiples for spots in matrix c
                    {
                        M.body[i, o] += a.body[i, j] * b.body[j, o];
                    }

                }
            }

            return M;
        }

        public static Tuple operator *(Matrices b, Tuple a) //tuple * matrix
        {

            double[] values = new double[4];

            for (int i = 0; i < 4; i++)
            {
                double x = a.x * b.body[i, 0];
                double y = a.y * b.body[i, 1];
                double z = a.z * b.body[i, 2];
                double w = a.w * b.body[i, 3];

                values[i] = x + y + z + w;
            }

            return new Tuple(values[0], values[1], values[2], values[3]);

        }
        public double[,] MulMatrix(double[,] matrixA, double[,] matrixB)
        {
            int rowA = matrixA.GetLength(0);
            int colA = matrixA.GetLength(1);
            int rowB = matrixB.GetLength(0);
            int colB = matrixB.GetLength(1);

            body = new double[rowA, colB];

            if (colA == rowB)
            {

                for (int i = 0; i < rowA; i++) //for each row of A
                    for (int o = 0; o < colB; o++) //for each column of B
                    {
                        for (int j = 0; j < colB; j++) //adding up multiples for spots in matrix c
                        {
                            body[i, o] += matrixA[i, j] * matrixB[j, o];
                        }
                    }

                return body;
            }

            else
                Console.WriteLine("matrices are incompatible to multiply");
            return null;

        }
        private double MulMany(double[,] matrix, params int[] nums) //multiplies numbers in a matrix given specific coordinates
        {
            int i = 0;
            double total = 1;
            while (true)
            {
                total *= matrix[nums[i], nums[i + 1]];
                i = i + 2;
                if (i + 1 > nums.Length)
                    break;
            }
            return total;
        }

        public double Determinant()
        {

            switch (size)
            {
                case 2:
                    return Deter2x2();

                case 3:
                    return Deter3x3();

                case 4:
                    return Deter4x4();

                default:
                    throw new Exception("matrix is wrong size");

            }
        }

        public double Determinant(Matrices m)
        {
            switch (size)
            {
                case 2:
                    return Deter2x2(m);

                case 3:
                    return Deter3x3(m);

                case 4:
                    return Deter4x4(m);

                default:
                    throw new Exception("matrix is wrong size");

            }
        }
        public double Deter2x2()
        {
            double ad = MulMany(body, 0, 0, 1, 1);
            double bc = MulMany(body, 0, 1, 1, 0);
            return ad - bc;
        }
        public double Deter2x2(Matrices m)
        {
            double ad = MulMany(m.body, 0, 0, 1, 1);
            double bc = MulMany(m.body, 0, 1, 1, 0);
            return ad - bc;
        }

        public double Deter3x3(Matrices m)
        {
            // matrix in alpha:
            double a = m.body[0, 0],    // [a b c d]  
                   b = m.body[0, 1],    // [e f g h]
                                        // [i j k l]
                                        // [m n o p]
                   c = m.body[0, 2];

            Matrices aM = new Matrices(m.SubMatrix(0, 0));

            Matrices bM = new Matrices(m.SubMatrix(0, 1));

            Matrices cM = new Matrices(m.SubMatrix(0, 2));

            double a3 = a * this.Deter2x2(aM);
            double b3 = b * this.Deter2x2(bM);
            double c3 = c * this.Deter2x2(cM);

            return a3 - b3 + c3;

        }

        public double Deter3x3()
        {
            // matrix in alpha:
            double a = this.body[0, 0],    // [a b c d]  
                   b = this.body[0, 1],    // [e f g h]
                                           // [i j k l]
                                           // [m n o p]
                   c = this.body[0, 2];

            Matrices aM = new Matrices(this.SubMatrix(0, 0));

            Matrices bM = new Matrices(this.SubMatrix(0, 1));

            Matrices cM = new Matrices(this.SubMatrix(0, 2));

            double a3 = a * this.Deter2x2(aM);
            double b3 = b * this.Deter2x2(bM);
            double c3 = c * this.Deter2x2(cM);

            return a3 - b3 + c3;

        }


        

    
        public double Deter4x4(Matrices z)
        {
            double a = z.body[0, 0],
                   b = z.body[0, 1],
                   c = z.body[0, 2],
                   d = z.body[0, 3];

            Matrices aM = new Matrices(z.SubMatrix(0, 0));

            Matrices bM = new Matrices(z.SubMatrix(0, 1));

            Matrices cM = new Matrices(z.SubMatrix(0, 2));

            Matrices dM = new Matrices(z.SubMatrix(0, 3));

            double a4 = a * aM.Deter3x3();
            double b4 = b * this.Deter3x3(bM);
            double c4 = c * this.Deter3x3(cM);
            double d4 = d * this.Deter3x3(dM);

            return a4 - b4 + c4 - d4;
        }

        public double Deter4x4()
        {
            double a = this.body[0, 0],
                   b = this.body[0, 1],
                   c = this.body[0, 2],
                   d = this.body[0, 3];

            Matrices aM = new Matrices(this.SubMatrix(0, 0));

            Matrices bM = new Matrices(this.SubMatrix(0, 1));

            Matrices cM = new Matrices(this.SubMatrix(0, 2));

            Matrices dM = new Matrices(this.SubMatrix(0, 3));

            double a4 = a * this.Deter3x3(aM);
            double b4 = b * this.Deter3x3(bM);
            double c4 = c * this.Deter3x3(cM);
            double d4 = d * this.Deter3x3(dM);

            return a4 - b4 + c4 - d4;
        }

        public double[,] SubMatrix(int rowLoc, int colLoc)
        {
            int size = body.GetLength(0);
            Matrices sub = new Matrices(size - 1);
            int x = 0, y = 0;
            for (int i = 0; i < size; i++)
            {
                if (i != rowLoc)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j != colLoc)
                        {

                            sub.body[x, y] = body[i, j];

                            y++;
                        }

                    }
                    y = 0;
                    x++;
                }
            }

            return sub.body;
        }


        public double Cofactor(int i, int j)
        {
            double minor = Minor(i, j);
            if ((i+j)%2 == 0)
                return minor;
            else
                return minor*-1;

        }

        public double Minor(int i, int j)
        {
            Matrices m = new Matrices(SubMatrix(i, j)); //if Matrices() is declared and then the body
                                                        // is set to a submatrix THERE WILL BE PROBLEMS
           
            return m.Determinant();
        }

        public Matrices Inverse()
        {
            if (this.Determinant() == 0)
            {
                invertible = false;
                throw new Exception("cannot be inverted");
            }

            Matrices inverse = new Matrices(this.size);

            for (int row = 0; row < inverse.size; row++)

            {
                for (int col = 0; col < inverse.size; col++) //apparently this does the transpose function, why is this better?
                {
                    double c = this.Cofactor(row, col);

                    inverse.body[col, row] = c / this.Determinant();
                }

            }

            return inverse;
        }



        public void Transpose()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    this.body[i, j] = this.body[j, i];
                }
            }





        }
    }
}
