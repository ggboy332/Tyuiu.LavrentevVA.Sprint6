using tyuiu.cources.programming.interfaces.Sprint6;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Tyuiu.LavrentevVA.Sprint6.Task3.V21.Lib
{
    public class DataService : ISprint6Task3V21
    {
        public int[,] Calculate(int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));

            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Копируем исходную матрицу в результат (чтобы сохранить все столбцы кроме первого)
            int[,] resultMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    resultMatrix[i, j] = matrix[i, j];

            // Сортируем только первый столбец, остальные столбцы остаются на своих местах
            var firstColumn = new int[rows];
            for (int i = 0; i < rows; i++)
                firstColumn[i] = matrix[i, 0];

            Array.Sort(firstColumn);

            for (int i = 0; i < rows; i++)
                resultMatrix[i, 0] = firstColumn[i];

            return resultMatrix;
        }
    }
}