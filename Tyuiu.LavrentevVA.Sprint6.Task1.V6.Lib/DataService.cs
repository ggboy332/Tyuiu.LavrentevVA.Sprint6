using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task1.V6.Lib
{
    public class DataService : ISprint6Task1V6
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            // Написать программу, которая выводит таблицу значений функции: F(x) = (sin(x) - 2x)/ (3x - 1) +sin(x) - 3x + 2 (произвести табулирование) f(x) на заданном диапазоне[-5; 5] с шагом 1.Произвести проверку деления на ноль. При делении на ноль вернуть значение 0. Результат вывести в Textbox Значения округлить до двух знаков после запятой. 
            List<double> results = new();
            for (int x = startValue; x <= stopValue; x++)
            {
                double result;
                double denominator = 3 * x - 1;
                if (denominator == 0)
                {
                    result = 0;
                }
                else
                {
                    result = (Math.Sin(x) - 2 * x) / denominator + Math.Sin(x) - 3 * x + 2;
                }
                results.Add(Math.Round(result, 2));
            }
            return results.ToArray();

        }
    }
}
