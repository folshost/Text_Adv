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
            
            Console.WriteLine("Welcome to Flight!\n");
            if (outPut.findSaves() == 0)
            {
                Console.WriteLine("There were no save files detected. \nStart New game?");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (input.ToUpper() == "NO" || input.ToUpper() == "N")
                    {
                        Console.WriteLine("Okay, goodbye!");
                        return;
                    }
                    else if (input.ToUpper() == "YES" || input.ToUpper() == "Y")
                        break;
                }    
            }

            Console.WriteLine("Please type your preferred name!\n");
            playerChar.charname = Console.ReadLine();
            Console.WriteLine("Hello " + playerChar.charname + "!");
            Console.WriteLine("You are in the " + playerChar.location.name + " right now");
            while (true)
            {
                inPut.getInput();
                if (playerChar.inventory.Count >= 3)
                {
                    Console.WriteLine("Congratulations! \n\nYou solved The Mystery of the Bleu Dauphin! \nCollect your winnings on your way out and have a nice day! ");
                    Console.ReadKey();
                    return;
                }

            }
            //Console.ReadKey();
        }
    }
}
