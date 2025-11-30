using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task3.V21.Lib
{
    public class DataService : ISprint6Task3V21
    {
        public int[,] Calculate(int[,] matrix)
        {
            int rows = matrix.GetUpperBound(0) + 1;
            int cols = matrix.Length / rows;

            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
                    {
                        count++;
                    }
                }
            }
            int[,] result = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > 0 && matrix[i, j] % 2 == 0)
                    {
                        result[i, j] = count;
                    }
                    else
                    {
                        result[i, j] = matrix[i, j];
                    }
                }
            }
            return result;



        }
    }
}