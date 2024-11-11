namespace FtoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fahrenheit = 94;

            double celsius = (fahrenheit - 32) * (5 / 9f);

            Console.WriteLine($"Farenheir is {fahrenheit}, conver to Celsius is {celsius:n2}");
        }
    }
}
