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
            
            Console.WriteLine("Welcome to Flight!\n");

            int savesnum = saves.findSaves();
            if (savesnum == 0)
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
                    {
                        newGame();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("That input was not intelligible, please use either a 'y' or 'n'");
                    }
                }    
            }
            else if(savesnum > 0)
            {
                if(savesnum == 1)
                {
                    Console.WriteLine("One save file was detected \n\nPlease select the index of the one you would like to use!\nOr, if you would like to start a new game type 'new game'");

                }
                else{
                    Console.WriteLine("There were " + savesnum + "  saves found\n\nPlease select the index of the one you would like to use!\nOr, if you would like to start a new game type 'new game'");

                }
                List<string> savesUse = saves.savesurvey();
                int saveNumIndex;
                while (true)
                {
                    for (int i = 0; i < savesUse.Count; i++)
                    {
                        Console.WriteLine("Save Index: " + i + "\nCharacter Name: " + savesUse[i] + "\nLocation: \n");
                    }
                    string saveIndex = inPut.getInput();
                    if (!(saveIndex.Contains("NEW") || saveIndex.Contains("New") || saveIndex.Contains("nEw") || saveIndex.Contains("NEw") || saveIndex.Contains("neW") || saveIndex.Contains("NeW") || saveIndex.Contains("nEW") || saveIndex.Contains("new")))
                    {
                        newGame();
                        break;
                    }

                    int.TryParse(saveIndex, out saveNumIndex);
                    if (saveNumIndex >= 0 && saveNumIndex < savesUse.Count)
                    {
                        break;

                    }
                    else
                    {
                        Console.WriteLine("That was not a valid input\nPlease put in a valid save index, or type exit");
                    }
                    
                }
            }
            
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

        static public void newGame()
        {
            roomMap.initItems();
            roomMap.initMap();
            Console.WriteLine("Please type your preferred name!\n");
            playerChar.charname = Console.ReadLine();
            Console.WriteLine("Hello " + playerChar.charname + "!");
            playerChar.location = roomMap.startroom;
            Console.WriteLine("You are in the " + playerChar.location.name + " right now");
            
        }


    }
}
