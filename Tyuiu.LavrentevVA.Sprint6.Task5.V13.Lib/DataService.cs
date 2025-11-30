using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task5.V13.Lib
{
    public class DataService : ISprint6Task5V13
    {
        public double[] LoadFromDataFile(string path)
        {
            //Прочитать данные из файла InPutFileTask5V13.txt. Вывести в dataGridView. Вывести все числа, меньше 10. Построить диаграмму по этим значениям. Графический интерфейс пользователя оформить по примеру из лекции. У вещественных значений округлить до трёх знаков после запятой.
            
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));
            }
            string[] lines = System.IO.File.ReadAllLines(path);
            List<double> numbers = new List<double>();
            foreach (string line in lines)
            {
                if (double.TryParse(line, out double number))
                {
                    if (number < 10)
                    {
                        numbers.Add(Math.Round(number, 3));
                    }
                }
            }
            return numbers.ToArray();
        }
    }
}
