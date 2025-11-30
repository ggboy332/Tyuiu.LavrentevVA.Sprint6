using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task7.V28.Lib
{
    public class DataService : ISprint6Task7V28
    {
        public int[,] GetMatrix(string path)
        {
            // Дан файл InPutFileTask7V28.csv в котором хранится матрица целочисленных значений. Загрузить файл через openFileDialog в объект dataGridViewIn. Изменить в седьмой строке числа не равные 13 на 0. Результат вывести в объект dataGridViewOut. Сохранить результат в файл OutPutFileTask7.csv через saveFileDialog. Графический интерфейс пользователя оформить по образцу как в лекции

            var lines = System.IO.File.ReadAllLines(path);
            int rowCount = lines.Length;
            int colCount = lines[0].Split(new char[] { ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries).Length;
            int[,] matrix = new int[rowCount, colCount];
            for (int i = 0; i < rowCount; i++)
            {
                var values = lines[i].Split(new char[] { ',', ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = int.Parse(values[j]);
                }
            }
            for (int j = 0; j < colCount; j++)
            {
                if (matrix[6, j] != 13)
                {
                    matrix[6, j] = 0;
                }
            }
            return matrix;

        }
    }
}
