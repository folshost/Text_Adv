﻿using System;
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
        } 

        static public bool canGo(Direction D)
        {
            if (location.adjacentRooms[D] != null)
                return true;
            else return false;
        }

        static public void look()
        {
            Console.WriteLine(location.descriptions[location.descripInd]);
            Console.WriteLine(location.roomItems[0] + "  " + location.roomItems[1]);
            for (int i = 0; i < location.itemNum; i++)
            { 
                if (location.roomItems[i].itemLoc == 0)
                    Console.WriteLine("There is a " + location.roomItems[i].itemName + " along the wall here");
                else if (location.roomItems[i].itemLoc == 1)
                    Console.WriteLine("There is a" + location.roomItems[i].itemName + " on the ceiling here");
                else if (location.roomItems[i].itemLoc == 2)
                    Console.WriteLine("There is a" + location.roomItems[i].itemName + " set in the floor here");
                else if (location.roomItems[i].itemLoc == 3)
                    Console.WriteLine("There is a" + location.roomItems[i].itemName + " in the middle of the floor here");
            }
          
            for (int i =0;i<4;i++)
            {
                if(location.adjacentRooms[(Direction)i] != null)
                    Console.WriteLine("There is a " + location.adjacentRooms[(Direction)i].name + " to the " + (Direction)i + " here." );
            }
        }
        
    }
}