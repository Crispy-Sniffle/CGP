using System;

namespace Week6
{
    public class Testing
    {
        public static void Main()
        {
            int[,] tempA = new int[,] {
                { 2, 1, 4 },
                { 0, 1, 1 }
            };
            Matrix2D a = new Matrix2D(tempA);

            int[,] tempB = new int[,] {
                { 6, 3 },
                { 5, 2 },
                { 1, 4 }
            };
            Matrix2D b = new Matrix2D(tempB);

            Console.WriteLine("Matrix A:");
            Console.WriteLine($"Columns: {a.NumberOfColumns()}, Rows: {a.NumberOfRows()}");
            Console.WriteLine(a.OutputMatrix());

            Console.WriteLine("Matrix B:");
            Console.WriteLine($"Columns: {b.NumberOfColumns()}, Rows: {b.NumberOfRows()}");
            Console.WriteLine(b.OutputMatrix());

            Console.WriteLine("A x B =");

            // Multiplying using the separate MatrixMultiplier class
            Matrix2D result = MatrixMultiplier.Multiplies(a, b);
            Console.WriteLine(result.OutputMatrix());

            Console.ReadLine(); 
        }
    }

    public class Matrix2D
    {
        public int[,] matrix;

        public Matrix2D()
        {
            matrix = new int[0, 0];
        }

        public Matrix2D(int x, int y)
        {
            matrix = new int[x, y];
        }

        public Matrix2D(int[,] toSet)
        {
            matrix = toSet;
        }

        public void SetMatrix(int[,] toSet)
        {
            if (toSet.GetLength(0) == matrix.GetLength(0) && toSet.GetLength(1) == matrix.GetLength(1))
            {
                matrix = toSet;
            }
        }

        public int NumberOfRows()
        {
            return matrix.GetLength(0);
        }

        public int NumberOfColumns()
        {
            return matrix.GetLength(1);
        }

        public string OutputMatrix()
        {
            string toOut = "";
            for (int i = 0; i < NumberOfRows(); i++)
            {
                for (int j = 0; j < NumberOfColumns(); j++)
                {
                    toOut += matrix[i, j].ToString();
                    if (j < NumberOfColumns() - 1)
                        toOut += "\t";
                }
                toOut += "\n";
            }
            return toOut;
        }
    }

    public class MatrixMultiplier
    {
        public static Matrix2D Multiplies(Matrix2D a, Matrix2D b)
        {
            int aRows = a.NumberOfRows();
            int aCols = a.NumberOfColumns();
            int bRows = b.NumberOfRows();
            int bCols = b.NumberOfColumns();

            if (aCols != bRows)
            {
                Console.WriteLine("Error: Matrix dimensions do not match. Columns of A must match Rows of B.");
                return new Matrix2D();
            }

            int[,] result = new int[aRows, bCols];

            for (int i = 0; i < aRows; i++)
            {
                for (int j = 0; j < bCols; j++)
                {
                    int dotProductSum = 0;
                    for (int k = 0; k < aCols; k++)
                    {
                        dotProductSum += a.matrix[i, k] * b.matrix[k, j];
                    }
                    result[i, j] = dotProductSum;
                }
            }

            return new Matrix2D(result);
        }
    }
}