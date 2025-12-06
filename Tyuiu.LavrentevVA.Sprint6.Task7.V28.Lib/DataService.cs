using tyuiu.cources.programming.interfaces.Sprint6;
using System;
using System.IO;
using System.Linq;

namespace Tyuiu.LavrentevVA.Sprint6.Task7.V28.Lib
{
    public class DataService : ISprint6Task7V28
    {
        public int[,] GetMatrix(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден.", path);

            var rows = File.ReadAllLines(path)
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(line => line
                    .Split(new[] { ',', ';', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => int.Parse(s.Trim()))
                    .ToArray())
                .ToArray();

            if (rows.Length == 0) return new int[0, 0];

            int r = rows.Length, c = rows[0].Length;
            var res = new int[r, c];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                    res[i, j] = rows[i][j];
            return res;
        }

        // Process: in the 7th column (index 6) set values != 13 to 0
        public int[,] ProcessMatrix(int[,] input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            int rows = input.GetLength(0);
            int cols = input.GetLength(1);

            var result = new int[rows, cols];

            // copy
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    result[r, c] = input[r, c];

            int targetCol = 6; // 7th column (0-based)
            if (cols > targetCol)
            {
                for (int r = 0; r < rows; r++)
                {
                    if (result[r, targetCol] != 13)
                        result[r, targetCol] = 0;
                }
            }

            return result;
        }

        public void SaveToFile(string path, int[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix));
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            using (var sw = new StreamWriter(path))
            {
                for (int r = 0; r < rows; r++)
                {
                    var parts = new string[cols];
                    for (int c = 0; c < cols; c++)
                        parts[c] = matrix[r, c].ToString();

                    sw.WriteLine(string.Join(",", parts));
                }
            }
        }
    }
}
