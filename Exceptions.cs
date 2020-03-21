using System;

namespace HW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(4,4);
            int[,] arr = new int[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            int[] ar = new int[] { 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4 };
            Matrix matrix2 = new Matrix(arr);
            Matrix matrix3 = new Matrix(3, 4, ar, "row");
            Matrix matrix4 = new Matrix(3, 4, ar, "column");
            try
            {
                Matrix matrix5 = matrix1 + matrix2;
            }
            catch(MatrixesAreNotEqualException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Matrix matrix6 = matrix1 - matrix2;
            }
            catch (MatrixesAreNotEqualException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Matrix matrix7 = matrix1 * matrix2;
            }
            catch (ImpossibleMultiplyException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    public class MatrixesAreNotEqualException : FormatException
    {
        public MatrixesAreNotEqualException():base("Size of matrixes must be equal") { }
    }

    public class ImpossibleMultiplyException : FormatException
    {
        public ImpossibleMultiplyException() : base("Number of first matrixes' columns must equal number of second matrixes' rows") { }
    }

    

    class Matrix
    {
        public int RowNumber { get; set; }
        public int ColNumber { get; set; }
        private int[,] array;
        public int this[int row, int col]
        {
            get
            {
                return array[row, col];
            }
            set
            {
                array[row, col] = value;
            }
        }

        public Matrix(int row, int col, int num=0)
        {
            RowNumber = row;
            ColNumber = col;
            array = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    array[i, j] = num;
                }
            }
        }
       
        public Matrix(int row, int col, int[] array, string direction)
        {
            RowNumber = row;
            ColNumber = col;
            this.array = new int[row, col];
            switch (direction)
            {
                case "row":
                    int k = 0;
                    for(int i=0; i < row; i++)
                    {
                        for(int j=0; j<col; j++)
                        {
                            this.array[i, j] = array[k];
                            k++;
                        }
                    }
                    break;
                case "column":
                    int l = 0;
                    for (int i = 0; i < col; i++)
                    {
                        for (int j = 0; j < row; j++)
                        {
                            this.array[j, i] = array[l];
                            l++;
                        }
                    }
                    break;
            }
        }
        public Matrix(int[,] array)
        {
            RowNumber = array.GetUpperBound(0) + 1;
            ColNumber = array.GetUpperBound(1)+1;
            this.array = new int[RowNumber, ColNumber];
            for (int i = 0; i < RowNumber; i++)
            {
                for (int j = 0; j < ColNumber; j++)
                {
                    this.array[i, j] = array[i,j];  
                }
            }
        }

        private static bool AreMatrixSizeEquals(Matrix m1, Matrix m2)
        {
            if (m1.RowNumber != m2.RowNumber || m1.ColNumber!= m2.ColNumber)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static bool IsMatrixSquare(Matrix m1)
        {
            if (m1.RowNumber == m1.ColNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CanMatrixesBeMultiplied(Matrix m1, Matrix m2)
        {
            if (m1.ColNumber == m2.RowNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      
        public static Matrix operator+(Matrix m1, Matrix m2)
        {
            if (AreMatrixSizeEquals(m1, m2))
            {
                int row = m1.RowNumber;
                int col = m1.ColNumber;
                Matrix m3 = new Matrix(row, col);

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        m3[i, j] = m1[i, j] + m2[i, j];
                    }
                }
                return m3;
            }
            else
            {
                throw new MatrixesAreNotEqualException();
            }
            
        }

        public static Matrix operator-(Matrix m1, Matrix m2)
        {
            if (AreMatrixSizeEquals(m1, m2))
            {
                int row = m1.RowNumber;
                int col = m1.ColNumber;
                Matrix m3 = new Matrix(row, col);

                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        m3[i, j] = m1[i, j] - m2[i, j];
                    }
                }
                return m3;
            }
            else
            {
                throw new MatrixesAreNotEqualException();
            }
        }

        public static Matrix operator++(Matrix m)
        {
            for (int i = 0; i < m.RowNumber; i++)
            {
                for (int j = 0; j < m.ColNumber; j++)
                {
                    m.array[i, j] = ++m[i, j];
                }
            }
            return m;
        }

        public static Matrix operator --(Matrix m)
        {
            int row = m.RowNumber;
            int col = m.ColNumber;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    m.array[i, j] = --m[i, j];
                }
            }
            return m;
        }


        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if(CanMatrixesBeMultiplied(m1, m2))
            {
                Matrix m3 = new Matrix(m1.RowNumber, m2.ColNumber);

                int Sum = 0;
                for (int z = 0; z < m1.RowNumber; z++)
                {
                    for (int q = 0; q < m2.ColNumber; q++)
                    {
                        for (int i = 0; i < m1.ColNumber; i++)
                        {
                            for (int j = 0; j < m2.RowNumber; j++)
                            {
                                Sum += m1[z, i] * m2[j, q];
                                break;
                            }
                        }
                        m3[z, q] = Sum;
                        Sum = 0;
                    }
                }
                return m3;
            }
            else
            {
                throw new ImpossibleMultiplyException();
            }         
        }
    }
}
