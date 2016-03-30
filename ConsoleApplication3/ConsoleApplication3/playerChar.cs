using System;
using System.Collections.Generic;
namespace ConsoleApplication3
{
    internal class playerChar
    {
        static public room location = null;
        static public string charname;
        static public int saveFileIndex;
        static public List<item> inventory = new List<item>();

        static public void move(Direction dir)
        {
            location = location.adjacentRooms[dir];
            Console.WriteLine("You go " + dir + " to the " + location.name + "\n");
            playerChar.look();
        } 

        static public bool canGo(Direction D)
        {
            if (location == null)
            {
                Console.WriteLine("Please do not try to access player stats when the player has not been initialized");
                return false;
            }
            if (location.adjacentRooms[D] != null)
                return true;
            else return false;
        }

        static public void lookInv()
        {
            if (location == null)
            {
                Console.WriteLine("Please do not try to access player stats when the player has not been initialized");
                return;
            }
            Console.WriteLine("You have: \n");
            for (int i = 0; i < inventory.Count; i++)
                Console.WriteLine(" \t A " + inventory[i].itemName);
        }

        static public void pickOut(string itemName)
        {
            if (location == null)
            {
                Console.WriteLine("Please do not try to access player stats when the player has not been initialized");
                return;
            }
            for (int i = 0; i < location.roomItems.Count; i++)
            {
                if(location.roomItems[i].nestItem != null)
                {
                    if (itemName.Contains(location.roomItems[i].nestItem.itemName.ToUpper()))
                    {

                        inventory.Add(location.roomItems[i].nestItem);
                        Console.WriteLine("You take the " + location.roomItems[i].nestItem.itemName + " out of the " + location.roomItems[i].itemName);
                        location.roomItems[i].nestItem = null;
                        return;
                    }

                }

            }
            for (int i = 0; i < playerChar.inventory.Count; i++)
            {
                if(playerChar.inventory[i].nestItem != null)
                {
                    if (itemName.Contains(playerChar.inventory[i].nestItem.itemName.ToUpper()))
                    {
                        inventory.Add(playerChar.inventory[i].nestItem);
                        Console.WriteLine("You take the " + playerChar.inventory[i].nestItem.itemName + " out of the " + playerChar.inventory[i].itemName);
                        playerChar.inventory[i].nestItem = null;
                        return;
                    }

                }

            }
            Console.WriteLine("That item isn't in anything in either this room or your inventory\n");
        }

        static public void pickUp(string itemName)
        {
            if(location == null)
            {
                Console.WriteLine("Please do not try to access player stats when the player has not been initialized");
                return;
            }
            for (int i = 0; i< location.roomItems.Count; i++)
            {
                if(itemName.Contains(location.roomItems[i].itemName.ToUpper()))
                {
                    Console.WriteLine("You pick up the " + location.roomItems[i].itemName);
                    inventory.Add(location.roomItems[i]);
                    location.roomItems.Remove(location.roomItems[i]);
                    location.itemNum--;
                    return;
                }
                    
            }
            Console.WriteLine("That item isn't in this room \n");

        }

        static public void look()
        {
            if (location == null)
            {
                Console.WriteLine("Please do not try to access player stats when the player has not been initialized");
                return;
            }
            Console.WriteLine(location.descriptions[location.descripInd] + "\n");


            //if(location.itemNum != 0)
                //Console.WriteLine(location.roomItems[0].itemName + "  " + location.roomItems[1].itemName);
            for (int i = 0; i < location.roomItems.Count; i++)
            { 
                if (location.roomItems[i].itemLoc == 0)
                    Console.WriteLine("There is a " + location.roomItems[i].itemName + " along the wall here \n");
                else if (location.roomItems[i].itemLoc == 1)
                    Console.WriteLine("There is a " + location.roomItems[i].itemName + " on the ceiling here \n");
                else if (location.roomItems[i].itemLoc == 2)
                    Console.WriteLine("There is a " + location.roomItems[i].itemName + " set in the floor here \n");
                else if (location.roomItems[i].itemLoc == 3)
                    Console.WriteLine("There is a " + location.roomItems[i].itemName + " in the middle of the floor here \n");
            }
          
            for (int i =0;i<4;i++)
            {
                if(location.adjacentRooms[(Direction)i] != null)
                    Console.WriteLine("There is a " + location.adjacentRooms[(Direction)i].name + " to the " + (Direction)i + " here. \n" );
            }
        }
        
    }
}