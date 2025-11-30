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
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Преобразуем матрицу в список массивов (строк)
            var rowsList = new List<int[]>();
            for (int i = 0; i < rows; i++)
            {
                int[] row = new int[cols];
                for (int j = 0; j < cols; j++)
                {
                    row[j] = matrix[i, j];
                }
                rowsList.Add(row);
            }

            // Сортируем по первому элементу каждой строки
            var sortedRows = rowsList.OrderBy(row => row[0]).ToList();

            // Преобразуем обратно в матрицу
            int[,] resultMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    resultMatrix[i, j] = sortedRows[i][j];
                }
            }

            return resultMatrix;
        }
    }
}