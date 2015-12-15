using System;
using System.Collections.Generic;

namespace MineFields
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start...");
            var fieldString = new List<string>();
            string input;
            while ((input = Console.ReadLine()) != "c")
            {
                fieldString.Add(input);
            }

            var field = string.Join(Environment.NewLine, fieldString);
            var builder = new MineFieldsBuilder();
            var result = builder.Build(field);
            Console.Write(result);
            Console.ReadLine();
        }
    }
}
