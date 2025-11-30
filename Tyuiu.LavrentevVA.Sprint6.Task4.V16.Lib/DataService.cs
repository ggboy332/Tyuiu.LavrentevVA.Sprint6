using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task4.V16.Lib
{
    public class DataService : ISprint6Task4V16
    {
        public double[] GetMassFunction(int startValue, int stopValue)
        {
            // Написать программу, которая выводит таблицу значений функции: F(x) = cos(x)/(x-0.4) + sin(x) * 8x + 2 (произвести табулирование) f(x) на заданном диапазоне [-5; 5] с шагом 1. Произвести проверку деления на ноль. При делении на ноль вернуть значение 0. Округлить до двух знаков после запятой. Результат вывести в textBox, построить график функции и сохранить в файл OutPutFileTask4V16.txt по нажатию кнопки. Графический интерфейс пользователя оформить по примеру из лекции.
            
            double mass = 0;
            if (stopValue < startValue)
            {
                throw new ArgumentException("Stop value must be greater than or equal to start value.");
            }
            int size = stopValue - startValue + 1;
            double[] results = new double[size];
            for (int i = 0; i < size; i++)
            {
                int x = startValue + i;
                double denominator = x - 0.4;
                if (denominator == 0)
                {
                    results[i] = 0;
                }
                else
                {
                    double fx = Math.Cos(x) / denominator + Math.Sin(x) * 8 * x + 2;
                    results[i] = Math.Round(fx, 2);
                }
            }
            return results;


        }
    }
}
