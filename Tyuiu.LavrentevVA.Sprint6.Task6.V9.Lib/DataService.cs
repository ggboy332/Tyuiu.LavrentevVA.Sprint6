using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task6.V9.Lib
{
    public class DataService : ISprint6Task6V9
    {
        public string CollectTextFromFile(string path)
        {
            // Дан файл InPutFileTask6V9.txt который может находится в любом месте на диске. Загрузить файл в textBoxIn через openFileDialog. Вывести последнее слово каждой строки в результирующею строку и вывести ее в textBoxOut. Дан файл InPutFileTask6V9.txt который может находится в любом месте на диске. Загрузить файл в textBoxIn через openFileDialog. Вывести последнее слово каждой строки в результирующею строку и вывести ее в textBoxOut. Графический интерфейс пользователя оформить по образцу как в лекции

            string result = string.Empty;
            var lines = System.IO.File.ReadAllLines(path);
            foreach (var line in lines)
            {
                var words = line.Split(new char[] { ' ', '\t' }, System.StringSplitOptions.RemoveEmptyEntries);
                if (words.Length > 0)
                {
                    result += words[^1] + " ";
                }
            }
            return result.Trim();
        }
    }
}
