using System;

namespace Task_6._1.PL
{

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Logic.ShowMenu();

                Logic.SelectMenuOption(Console.ReadLine());
            }
        }
    }
}

   