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
        } 

        static public bool canGo(Direction D)
        {
            if (location.adjacentRooms[D] != null)
                return true;
            else return false;
        }

        static public void look()
        {
            Console.WriteLine(location.description+ '\n');
            for(int i =0;i<4;i++)
            {
                if(location.adjacentRooms[(Direction)i] != null)
                    Console.WriteLine("There is a " + location.adjacentRooms[(Direction)i].name + " to the " + (Direction)i + " here." );
            }
        }
        
    }
}