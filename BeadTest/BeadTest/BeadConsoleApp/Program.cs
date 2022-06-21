using System;
using System.Collections.Generic;
using System.Linq;

namespace BeadConsoleApp
{
    class Program
    {
        // Reads input and retrieves it as an integer array
        public static int[] RetrieveInput()
        {
            return Console.ReadLine().Split(",").Select(x => int.Parse(x) ).ToArray();
        }

        // Creates a matrix based in integers array
        public static int[,] SetBeadMatrix(int[] integerArray)
        {
            int m = integerArray.Max();
            var matrix = new int[m, m];
            int i = 0;
            int arrayLength = integerArray.Length;

            while (i < m)
            {       
                if (i < arrayLength)
                {
                    int integer = integerArray[i];
                    FillRow(matrix, integer, i);
                }
                
                i++;
            }

            return matrix;
        }

        // Fills matrix (m, j) row for every j
        public static void FillRow(int[,] matrix, int integer, int i)
        {
            int n = RetrieveMatrixLength(matrix);
            for (int j = 0; j <= n; j++)
            {
                if (j >= integer)
                {
                    break;
                }

                matrix[i, j] = 1;
            }
        }

        // Transpose original matrix in order to return the conjugate integers
        public static int[,] TransposeMatrix(int[,] matrix) 
        {
            int m = RetrieveMatrixLength(matrix);
            var transpose = new int[m, m];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    transpose[j, i] = matrix[i, j];
                }
            }
            return transpose;
        }

        public static int RetrieveMatrixLength(int[,] matrix)
        {
            return matrix.GetLength(0);
        }

        public static List<int> RetrieveResult(int[,] matrix) 
        {
            List<int> result = new List<int>();
            int m = RetrieveMatrixLength(matrix);
            for (int i = 0; i < m; i++)
            {
                var row = Enumerable.Range(0, m).Select(x => matrix[i, x]).ToArray();
                int beadNumber = row.Count(x => x == 1);
                result.Add(beadNumber);
            }
            return result;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Write a list of integers in non-increasing order separated by comma, please: ");
            int[] input = RetrieveInput();
            var transposed = TransposeMatrix(SetBeadMatrix(input) );
            Console.WriteLine("\nThe conjugate collection is ");
            Console.WriteLine(String.Join(", ", RetrieveResult(transposed) ) );
        }
    }
}
