using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task3.V21.Lib
{
    public class DataService : ISprint6Task3V21
    {
        public int[,] Calculate(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] resultMatrix = (int[,])matrix.Clone();

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < rows - i - 1; j++)
                {
                    if (resultMatrix[j, 0] > resultMatrix[j + 1, 0])
                    {
                        // Меняем местами целые строки
                        for (int k = 0; k < cols; k++)
                        {
                            int temp = resultMatrix[j, k];
                            resultMatrix[j, k] = resultMatrix[j + 1, k];
                            resultMatrix[j + 1, k] = temp;
                        }
                    }
                }
            }

            return resultMatrix;
        }
    }
}