using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task2.V4.Lib
{
    public class DataService : ISprint6Task2V4
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            // Написать программу, которая выводит таблицу значений функции: F(x) = (5x + 2.5)/(sin(x) + 2) + 2x + 2 (произвести табулирование) f(x) на заданном диапазоне [-5; 5] с шагом 1. Произвести проверку деления на ноль. При делении на ноль вернуть значение 0. Значения занести в DataGridView Значения округлить до двух знаков после запятой. Графический интерфейс оформить по шаблону из лекции.
            if (stopValue < startValue)
            {
                throw new ArgumentException("Stop value must be greater than or equal to start value.");
            }
            int size = stopValue - startValue + 1;
            double[] results = new double[size];
            for (int i = 0; i < size; i++)
            {
                int x = startValue + i;
                double denominator = Math.Sin(x) + 2;
                if (denominator == 0)
                {
                    results[i] = 0;
                }
                else
                {
                    double fx = (5 * x + 2.5) / denominator + 2 * x + 2;
                    results[i] = Math.Round(fx, 2);
                }
            }
            return results;
        }
    }
}
