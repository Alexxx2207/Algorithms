using System;

namespace GaussElimination
{
    class Program
    {
        static void showMatrix(double[][] matrix, double[] answers)
        {
            Console.WriteLine();
            for (int row = 0; row < matrix.Length; row++) 
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(" " + matrix[row][col] + " ");
                }
                Console.Write("\t " + answers[row] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        static double[] GaussianElimination(double[][] matrix, double[] rightFromEquals)
        {
            double[] result = new double[matrix.Length];

            int length = matrix.Length;

            //Echelon Form
            for (int i = 0; i < length-1; i++)
            {
                int max = i;

                for (int row = i+1; row < length; row++)
                {
                    if (Math.Abs(matrix[max][i]) < Math.Abs(matrix[row][i]))
                    {
                        max = row;
                    }
                }

                var tempRow = matrix[max];
                matrix[max] = matrix[i];
                matrix[i] = tempRow;
                
                var tempRowForEquals = rightFromEquals[max];
                rightFromEquals[max] = rightFromEquals[i];
                rightFromEquals[i] = tempRowForEquals;

                showMatrix(matrix, rightFromEquals);

                for (int row = i + 1; row < length; row++)
                {
                    double ratio = matrix[row][i] / matrix[i][i];

                    for (int col = i; col < length; col++)
                    {
                        matrix[row][col] = matrix[row][col] - ratio * matrix[i][col];
                    }
                    rightFromEquals[row] -= ratio * rightFromEquals[i];

                    showMatrix(matrix, rightFromEquals);

                }
            }


            for (int i = length-1; i >= 0; i--)
            {
                double sum = 0;
                for (int col = length-1; col > i; col--)
                {
                    sum += result[col] * matrix[i][col];
                }
                result[i] = (rightFromEquals[i] - sum) / matrix[i][i];
            }


            return result;
        }

        static void Main(string[] args)
        {
            //EXAMPLE 
            // x + y - z = -2
            // 2x - y + z = 5
            // -x + 2y + 2z = 1
            // result: x = 1, y = -1, z = 2

            double[][] matrix = 
            {
                new double[] { 1,1,-1},
                new double[] {2,-1,1},
                new double[] { -1,2,2 }
            };

            double[] rightFromEquals = { -2,5,1 };

            double[] result = GaussianElimination(matrix, rightFromEquals);

            char[] resultVariables = { 'x', 'y', 'z' };
            
            for (int i = 0; i < resultVariables.Length; i++)
            {
                Console.WriteLine($"{resultVariables[i]} = {result[i]}"); 
            }
        }
    }
}
