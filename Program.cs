using System;
using System.Threading.Tasks;

namespace lab12
{
    internal class Program
    {
        const int n = 6;
        const int m = 6;
        const int l = 6;
        static double[,] A = new double[n, m];
        static double[,] B = new double[l, n];
        static double[,] C = new double[l, n];

        static void Main(string[] args)
        {
            double x = 5;
            GenerateMatrices(x);

            MultiplyMatricesParallel();
            Console.WriteLine("\nMultiplication result: ");
            Print.Matrix(C, "Matrix[C]");

            Console.ReadKey();
        }

        static void GenerateMatrices(double x)
        {
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < m; k++)
                {
                    double denominator = i + Math.Sin(Math.Pow(k, 2));
                    if (denominator == 0 || double.IsNaN(denominator))
                    {
                        denominator = 1;
                    }
                    A[i, k] = Math.Round((Math.Pow(i, 1.5) + 1.5) / denominator - Math.Pow(k, 0.3), 4);
                }
            }

            for (int k = 0; k < m; k++)
            {
                for (int j = 0; j < l; j++)
                {
                    double denominator = Math.Pow(2, j) - Math.Pow(Math.Sin(0.4 + j), 2);
                    if (denominator == 0 || double.IsNaN(denominator))
                    {
                        denominator = 1;
                    }
                    B[k, j] = Math.Round((Math.Pow(k, 3) / (j + 1)) / denominator, 4);
                }
            }

            Print.Matrix(A, "Matrix[A]");
            Print.Matrix(B, "Matrix[B]");
        }

        static void MultiplyMatricesParallel()
        {
            Parallel.For(0, n, i =>
            {
                for (int j = 0; j < l; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m; k++)
                    {
                        sum += A[i, k] * B[k, j];
                    }
                    C[i, j] = sum;
                }
            });
        }
    }
}
