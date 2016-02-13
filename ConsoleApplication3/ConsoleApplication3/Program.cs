using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            roomMap.initItems();
            roomMap.initmap();
            Console.WriteLine("Woohoo! Got past initItems!");
            Console.WriteLine(roomMap.itemList.Count);
            Console.WriteLine("Yay! got past finding count!");

            Console.WriteLine("Welcome to Flight!\n");
            Console.WriteLine("Please type your preferred name!\n");
            playerChar.charname = Console.ReadLine();
            Console.WriteLine("Hello " + playerChar.charname + "!");
            Console.WriteLine("You are in the " + playerChar.location.name + " right now");
            while (true)
            {
                inPut.getInput();
            }
            //Console.ReadKey();
        }
    }
}
