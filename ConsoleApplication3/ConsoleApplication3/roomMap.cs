using System;
namespace ConsoleApplication3
{
    internal class roomMap
    {
        private room startroom = new room("You are standing at the foot of a long driveway, there is a mailbox", "driveway");

        public void initmap() {
            room pos = startroom;
            int randuse, k = 0;
            bool repeat = true;
            Direction randdir;
            Random rand1 = new Random();
            
            while (repeat == true)
            {
                randuse = rand1.Next();
                if(randuse % 10 == 0)
                {
                    while (true) {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are in a billiard room. Fun.", "Billiard Room", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 1)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are in a small chapel. There are some mini-pews here.", "Chapel", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 2)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are standing in a greenhouse. There are many plants around", "Greenhouse", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 3)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You see a beautiful garden all around you. Lotsa flowers and topiaries.", "Garden", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 4)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("The entrance to a topiary maze confronts you.", "Maze", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 5)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You're in a subway stat-wait, nope, it's a kitchen.", "Kitchen", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 6)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You stand in a magnificent dining room. There's some nice china in the corner.", "Dining Room", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 7)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You're in what looks like someone's bedroom.", "Bedroom", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 8)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("You are standing in the biggest linen closet you've ever seen.", "Linen Closet", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if (randuse % 10 == 9)
                {
                    while (true)
                    {
                        randdir = (Direction)(rand1.Next() % 4);
                        if (pos.adjacentRooms[randdir] == null)
                        {
                            pos.addfrom("Phew, you're now in a room full of garbage. Who would purposely put a room like this in their house?", "Trash Room", randdir);
                            pos = pos.adjacentRooms[randdir];
                            k++;
                            break;
                        }
                    }
                }
                if(k == 9)
                    repeat = false;
            }        
        }            
    }
}