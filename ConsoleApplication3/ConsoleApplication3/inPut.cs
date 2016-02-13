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

        


        public static string getInput()
        {
            string input = Console.ReadLine();
            Console.WriteLine("");
            input = input.ToUpper();
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
                //outPut.write();
                return input;
            }
           

            else return input;
        }
    }
}