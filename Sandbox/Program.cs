using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Sandbox
{
    public class XXXX
    {
        public void PrintHello()
        {
            Console.WriteLine("Hello");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            object path = "database.json";

            //var x = new TelephoneManager<TelephoneNote>("D:\\Danil\\university\\PIS\\Labs\\ASP_Framework\\Lab4\\Repository\\database.json");

            //var res = x.GetTelephoneNotes().GetAwaiter().GetResult();

            dynamic xxx = "tt";
            Console.WriteLine(xxx.ToString());

            while (i < 100)
            {
                xxx = new XXXX();
                Console.WriteLine(xxx.ToString().GetHashCode());
                Console.WriteLine(xxx.GetHashCode());
                Console.WriteLine(xxx.GetType());
                xxx.PrintHello();

                i++;
            }

            xxx = "5";
            Console.WriteLine(xxx.GetHashCode());
            xxx = "6";
            Console.WriteLine(xxx.GetHashCode());
            xxx = "7";
            Console.WriteLine(xxx.GetHashCode());


            Console.ReadKey();
        }

    }
}
