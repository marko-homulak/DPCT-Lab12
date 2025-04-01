using System;

namespace lab12
{
    public static class Print
    {
        public static void Matrix(double[,] matrix, string label = "Matrix[,]")
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Console.Write($"{label}:\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string formattedValue = matrix[i, j].ToString("F6");
                    int padding = matrix[i, j] < 0 ? 3 : 3;
                    Console.Write($"{formattedValue.PadLeft(10 + padding)}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
