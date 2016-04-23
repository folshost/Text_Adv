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
            //roomMap.initMapSaved();
            //roomMap.initItemsImport();
            while (true)
            {

                runGame();
            }
            
            //Console.ReadKey();
        }

        static public void runGame()
        {
            startMenu();
            while (true)
            {
                string inputer = inPut.getInput();
                if (inputer.Contains("MENU"))
                {
                    while (true)
                    {
                        Console.WriteLine("Are you sure you would like to quit to the menu?\n");
                        inputer = inPut.getInput();
                        if (inputer.Contains("Y"))
                        {
                            Console.WriteLine("Would you like to save first?\n");
                            inputer = inPut.getInput();
                            if (inputer.Contains("Y"))
                            {
                                saves.save();
                                roomMap.itemList.RemoveRange(0, roomMap.itemList.Count );
                                roomMap.roomlist.RemoveRange(0, roomMap.roomlist.Count );
                                playerChar.inventory.RemoveRange(0, playerChar.inventory.Count);
                                return;
                            }
                            else
                            {
                                roomMap.itemList.RemoveRange(0, roomMap.itemList.Count );
                                roomMap.roomlist.RemoveRange(0, roomMap.roomlist.Count );
                                playerChar.inventory.RemoveRange(0, playerChar.inventory.Count);
                                return;
                            }
                        }
                        else if(inputer.Contains("N"))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("That input was unintelligible, please reply with either yes or no");
                        }
                    }
                }
                if (playerChar.inventory.Count >= 30)
                {
                    Console.WriteLine("Congratulations! \n\nYou solved The Mystery of the Bleu Dauphin! \nCollect your winnings on your way out and have a nice day! ");
                    Console.ReadKey();
                    Environment.Exit(0);
                }

            }


        }

        static public void startMenu()
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
            else if (savesnum > 0)
            {
                if (savesnum == 1)
                {
                    Console.WriteLine("One save file was detected \n\nPlease select the index of the one you would like to use!\nOr, if you would like to start a new game type 'new game'");

                }
                else {
                    Console.WriteLine("There were " + savesnum + "  saves found\n\nPlease select the index of the one you would like to use!\nOr, if you would like to start a new game type 'new game'");

                }
                List<string> savesUse = saves.savesurvey();
                bool useNewGame = false;
                if (savesUse == null)
                {
                    Console.WriteLine("The save file failed to open.\nPlease restart the game, or start a new game by typing 'new game'.");
                    string saveException = inPut.getInput();
                    saveException = saveException.ToUpper();
                    if (saveException.Contains("NEW") || saveException.Contains("N"))
                    {
                        newGame();
                        useNewGame = true;
                    }
                }

                int saveNumIndex;
                if (!useNewGame)
                {

                    while (true)
                    {

                        if (savesUse != null)
                        {
                            int j = 0;
                            //if(savesUse.Count % 3 == 0)
                            {
                                for (int i = 0; i < savesUse.Count / 3; i++)
                                {
                                    Console.WriteLine("\nSave Index: " + i + "\nCharacter Name: \n" + savesUse[3 * i] + "\n\nLocation: \n" + savesUse[3 * i + 1] + "\n\nTime Saved: \n" + savesUse[3 * i + 2] + "\n");
                                }

                            }
                            /*else
                            {
                                for (int i = 0; i < (savesUse.Count / 3); i++)
                                {
                                    Console.WriteLine("Save Index: " + i + "\nCharacter Name: " + savesUse[3 * i] + "\nLocation: \n" + savesUse[3 * i + 1] + "\nTime Saved: \n" + savesUse[3 * i + 2]);
                                }
                            }*/
                            string saveIndex = inPut.getInput();
                            if ((saveIndex.Contains("N") || saveIndex.Contains("n")))
                            {
                                newGame();
                                break;
                            }

                            int.TryParse(saveIndex, out saveNumIndex);
                            if (saveNumIndex >= 0 && saveNumIndex < savesUse.Count)
                            {
                                try
                                {
                                    saves.saveImport(saveNumIndex);

                                    break;

                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    Console.WriteLine(e.StackTrace);
                                    Console.WriteLine("File of save index " + saveNumIndex + " could not be opened");
                                }

                            }
                            else
                            {
                                Console.WriteLine("That was not a valid input\nPlease put in a valid save index, or type exit");
                            }
                        }
                        else
                        {
                            string saveIndex = inPut.getInput();
                            if ((saveIndex.Contains("NEW") || saveIndex.Contains("New") || saveIndex.Contains("nEw") || saveIndex.Contains("NEw") || saveIndex.Contains("neW") || saveIndex.Contains("NeW") || saveIndex.Contains("nEW") || saveIndex.Contains("new")))
                            {
                                newGame();
                                break;
                            }
                        }

                    }
                }
            }

        }


        static public void newGame()
        {
            roomMap.initItemsImport();
            
            roomMap.initMap();
            playerChar.saveFileIndex = -1;
            Console.WriteLine("Please type your preferred name!\n");
            playerChar.charname = Console.ReadLine();
            Console.WriteLine("Hello " + playerChar.charname + "!");
            playerChar.location = roomMap.startroom;
            Console.WriteLine("You are in the " + playerChar.location.name + " right now");
            
        }


    }
}
