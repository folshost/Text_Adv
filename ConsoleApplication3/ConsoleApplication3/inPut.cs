using System;

namespace ConsoleApplication3
{
    internal class inPut
    {

        public static void help()
        {
            Console.WriteLine("To move, simply type the word 'go,' then press enter, and then \n type the direction you wish to go in, in either the form \n 'D' or 'Direction' ");
        }

        public static string simpleInput()
        {
            string input = Console.ReadLine();
            input = input.ToUpper();
            if (input == "HELP")
            {
                inPut.help();
                return "";
            }
            else return input;
        }

        public static bool isHere(string itemName)
        {
            for (int i = 0; i < playerChar.location.roomItems.Count; i++)
            {
                if (playerChar.location.roomItems[i].itemName == itemName)
                    return true;
            }
            for (int i = 0; i < playerChar.inventory.Count; i++)
            {
                if (playerChar.inventory[i].itemName == itemName)
                    return true;
            }
            return false;
        }




        public static string getInput()
        {
            string input = Console.ReadLine();
            Console.WriteLine("");
            input = input.ToUpper();
            if(input.Contains("AT") && input.Contains("LOOK"))
            {
                bool worked = false;
                for (int i = 0; i < roomMap.itemList.Count; i++)
                {
                    
                    if (input.Contains(roomMap.itemList[i].itemName.ToUpper()) && isHere(roomMap.itemList[i].itemName))
                    {
                        Console.WriteLine(roomMap.itemList[i].itemDescrip);
                        worked = true;
                    }
                }
                if(!worked)
                    Console.WriteLine("That item is either not here or not in your inventory");
                //return input;
            }
            if (input.Contains("IN") && input.Contains("LOOK"))
            {
                bool worked = false;
                for (int i = 0; i < roomMap.itemList.Count; i++)
                {

                    if (input.Contains(roomMap.itemList[i].itemName.ToUpper()) && isHere(roomMap.itemList[i].itemName))
                    {
                        if (roomMap.itemList[i].nestItem == null)
                        {
                            Console.WriteLine("There is nothing in the " + roomMap.itemList[i].itemName);
                            worked = true;
                            break;
                        }
                        Console.WriteLine("There is a " + roomMap.itemList[i].nestItem.itemName + " in the " + roomMap.itemList[i].itemName);
                        worked = true;
                    }
                }
                if (!worked)
                    Console.WriteLine("That item is either not here or not in your inventory");
                return input;
            }
            if (input == "LOOK")
            {
                playerChar.look();
                return input;
            }
            else if (input == "HELP")
            {
                help();
                return input;
            }
            else if (input.Contains("GO"))
            {
                if (input.Contains("E") && playerChar.canGo((Direction)1))
                    playerChar.move((Direction)1);
                else if (input.Contains("N") && playerChar.canGo((Direction)0))
                    playerChar.move((Direction)0);
                else if (input.Contains("S") && playerChar.canGo((Direction)2))
                    playerChar.move((Direction)2);
                else if (input.Contains("W") && playerChar.canGo((Direction)3))
                    playerChar.move((Direction)3);
                return input;


                /*
                Console.WriteLine("Where would you like to go?\n");
                int repeat = 0;
                while (true)
                {
                    string input2 = simpleInput();
                    input2 = input2.ToUpper();
                    if ( input2 == "EAST" || input2 == "E")
                    {
                        Console.WriteLine(playerChar.canGo((Direction)1));
                        if ((playerChar.canGo((Direction)1)))
                        {
                            playerChar.move((Direction)1);
                            break;
                        }
                        else Console.WriteLine("There is nothing in that direction");

                    }
                    else if(input2 == "NORTH" || input2 == "N")
                    {
                        if ((playerChar.canGo((Direction)0)))
                        {
                            playerChar.move((Direction)0);
                            break;
                        }
                        else Console.WriteLine("There is nothing in that direction");
                    }
                    else if(input2 == "SOUTH" || input2 == "S")
                    {
                        if ((playerChar.canGo((Direction)2)))
                        {
                            playerChar.move((Direction)2);
                            break;
                        }
                        else Console.WriteLine("There is nothing in that direction");
                    }
                    else if(input2 == "WEST" || input2 == "W")
                    {
                        if ((playerChar.canGo((Direction)3)))
                        {
                            playerChar.move((Direction)3);
                            break;
                        }
                        else Console.WriteLine("There is nothing in that direction");
                    }
                    repeat++;
                    if (repeat >= 3)
                        Console.WriteLine("If you don't know how to proceed, type help"); 
                }
                return input; */
            }
            else if ((input.Contains("TAKE") || input.Contains("GET")) && (input.Contains("FROM") || input.Contains("OUT OF")))
            {
                playerChar.pickOut(input);
                return input;
            }
            else if(input.Contains("TAKE") || input.Contains("GET"))
            {
                playerChar.pickUp(input);
                return input;
            }
            else if(input.Contains("INVENTORY") || input.Contains("INV"))
            {
                playerChar.lookInv();
                return input;
            }
            else if (input.Contains("SAVE"))
            {
                saves.save();
                return input;
            }
            else if(input.Contains("EXIT"))
            {
                Environment.Exit(0);
                return input;
            }
           

            else return input;
        }
    }
}