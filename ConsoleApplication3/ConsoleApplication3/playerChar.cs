using System;
using System.Collections.Generic;
namespace ConsoleApplication3
{
    internal class playerChar
    {
        static public room location = roomMap.startroom;
        static public string charname;
        static public List<item> inventory = new List<item>();

        static public void move(Direction dir)
        {
            location = location.adjacentRooms[dir];
            Console.WriteLine("You go " + dir + " to the " + location.name + "\n");
        } 

        static public bool canGo(Direction D)
        {
            if (location.adjacentRooms[D] != null)
                return true;
            else return false;
        }

        static public void lookInv()
        {
            Console.WriteLine("You have: \n");
            for (int i = 0; i < inventory.Count; i++)
                Console.WriteLine(" \t A " + inventory[i].itemName);
        }

        static public void pickUp(string itemName)
        {
            for(int i = 0; i< location.roomItems.Count; i++)
            {
                if(itemName.Contains(location.roomItems[i].itemName.ToUpper()))
                {
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
            Console.WriteLine(location.descriptions[location.descripInd] + "\n");


            //if(location.itemNum != 0)
                //Console.WriteLine(location.roomItems[0].itemName + "  " + location.roomItems[1].itemName);
            for (int i = 0; i < location.itemNum; i++)
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