using System;

namespace LcdKata
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Execute();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadLine();
        }

        private static void Execute()
        {
            Console.WriteLine("Enter a number.");
            var number = Console.ReadLine();
            var lcd = new Lcd();
            Console.WriteLine("LCD number:");
            Console.WriteLine(lcd.Generate(number));
        }
    }
}
