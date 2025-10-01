using System;

class Program
{
    static void Main(string[] args)
    {
     Console.Write("Введите размер квадратной матрицы: ");
     var size = Convert.ToInt32(Console.ReadLine());
     
     int[,] matrix = new int[size, size];
     var rand = new Random();

     for (int i = 0; i < size; i++)
         for (int j = 0; j < size; j++)
            matrix[i, j] = rand.Next(-50, 51);
     
     Console.WriteLine("Исходная матрица: ");
     PrintMatrix(matrix);
     //Сортировка по сумме
     // Перебирает строки матрицы
     for (int i = 0; i < size - 1; i++)
     {
         // Сравнивает текущую строку i с каждой последующей строкой k
         for (int k = i + 1; k < size; k++)
         {
             // Если сумма одной строки больше суммы другой
             if (RowSum(matrix, i) > RowSum(matrix, k))
             {
                 // Поменять местами
                 for (int j = 0; j < size; j++)
                 {
                     (matrix[i, j], matrix[k, j]) = (matrix[k, j], matrix[i, j]);
                 }
             }
         }
     }
     Console.WriteLine("Отсортированная матрица:");
     PrintMatrix(matrix);
     Console.ReadKey();
    }
    // Метод для поиска суммы ряда
    static int RowSum(int[,] matrix, int row)
    {
        int sum = 0;
        for (int i = 0; i < matrix.GetLength(1); i++)
            sum += matrix[row, i];
        return sum;
    }
    // Метод для вывода матрицы
    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write($"{matrix[i, j], 5}");
            Console.WriteLine();
        }
    }
}