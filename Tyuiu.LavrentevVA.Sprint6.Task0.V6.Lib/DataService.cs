using tyuiu.cources.programming.interfaces.Sprint6;
namespace Tyuiu.LavrentevVA.Sprint6.Task0.V6.Lib
{
    public class DataService : ISprint6Task0V6
    {
        public double Calculate(int x)
        {
            // Дано выражение вычислdfить его значение при x = 3, результат вывести в TextBox. Округлить до трёх знаков после запятой. y(x) = x / sqrt(x^2 + x)
            double y = x / Math.Sqrt(x * x + x);
            return Math.Round(y, 3);

        }
    }
}
