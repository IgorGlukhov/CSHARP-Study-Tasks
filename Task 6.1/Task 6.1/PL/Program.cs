using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using System.Globalization;

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

   