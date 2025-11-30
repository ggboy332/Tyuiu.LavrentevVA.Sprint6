using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task3.V21.Lib
{
    public class DataService : ISprint6Task3V21
    {
        public int[,] Calculate(int[,] matrix)
        {
            //Дан массив 5 на 5 элементов. Выполнить сортировку по возрастанию в первом столбце. Результат вывести в DataGridView. Графический интерфейс оформить по шаблону из лекции.  26 -15   7   1  -4   14  26  22  17  27   -8  31  22  34   4  -18  16  -2  16  27    5   2  -4  16  15
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (cols < 4)
            {
                throw new ArgumentException("Матрица должна иметь 5 столбцов");
            }

            int[,] resultMatrix = (int[,])matrix.Clone();
            for(int i = 0; i < rows - 1; i++)
            {
                for(int j = 0; j < rows - i - 1; j++)
                {
                    if(resultMatrix[j, 0] > resultMatrix[j + 1, 0])
                    {
                        for(int k = 0; k < cols; k++)
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