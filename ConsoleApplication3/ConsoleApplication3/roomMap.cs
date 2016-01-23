using System;
using System.Collections.Generic;
namespace ConsoleApplication3
{
    internal class roomMap
    {
        static public room startroom = new room("You are standing at the foot of a long driveway, there is a mailbox", "Driveway");

        static public List<room> roomlist = new List<room>();

        static public room randroom()
        {
            Random rand2 = new Random();
            return roomlist[rand2.Next() % roomlist.Count];
        }


        static public void initmap() {
            room pos = startroom;
            roomlist.Add(startroom);
            Direction randdir;
            Random rand1 = new Random();
            KeyNotFoundException check = new KeyNotFoundException();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Inside the for-loop, on iteration" + (i));
                if (i == 0)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next(0,3));
                        //Console.WriteLine(randdir);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You stand in a magnificent dining room. There's some nice china in the corner.", "Dining Room", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if(i == 1)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are in a billiard room. Fun.", "Billiard Room", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 2)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are in a small chapel. There are some mini-pews here.", "Chapel", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 3)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are standing in a greenhouse. There are many plants around", "Greenhouse", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 4)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You see a beautiful garden all around you. Lotsa flowers and topiaries.", "Garden", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 5)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("The entrance to a topiary maze confronts you.", "Maze", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 6)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You're in a subway stat-wait, nope, it's a kitchen.", "Kitchen", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 7)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You're in what looks like someone's bedroom.", "Bedroom", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 8)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are standing in the biggest linen closet you've ever seen.", "Linen Closet", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
                if (i == 9)
                {
                    while (true)
                    {
                        pos = randroom();
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("Phew, you're now in a room full of garbage. Who would purposely put a room like this in their house?", "Trash Room", randdir);
                            roomlist.Add(pos.adjacentRooms[randdir]);
                            pos = randroom();
                            break;
                        }
                    }
                }
            }        
        }            
    }
}