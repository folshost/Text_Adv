using System;
using System.Collections.Generic;
namespace ConsoleApplication3
{
    internal class roomMap
    {
        static public room startroom = new room("You are standing at the foot of a long driveway, there is a mailbox", "Driveway");

        static public List<room> roomlist = new List<room>();

        static public List<item> itemList = new List<item>();

        static public room randroom()
        {
            Random rand2 = new Random();
            return roomlist[rand2.Next() % roomlist.Count];
        }

        static public void initItems()
        {
            item robotToy = new item("toy robot", 3);
            

            item chinaCabinet = new item("China cabinet", 0);
            chinaCabinet.nestItem = robotToy;
            itemList.Add(chinaCabinet);
                           
            item dinoTopia = new item("dinosaur topiary", 3);
            itemList.Add(dinoTopia);

            item  miniPew = new item("mini pew", 3);
            itemList.Add(miniPew);

            item flowerbed = new item("flowerbed", 3);
            itemList.Add(flowerbed);

            item diningTable = new item("dining room table", 3);
            itemList.Add(diningTable);

            item chandelier = new item("crystal chandelier", 1);
            itemList.Add(chandelier);

            item billiardTable = new item("billiard table", 3);
            itemList.Add(billiardTable);

            item pulpit = new item("pulpit", 3);
            itemList.Add(pulpit);

            item plants = new item("plants", 3);
            itemList.Add(plants);

            item flowers = new item("flowers", 3);
            itemList.Add(flowers);

            item bench = new item("bench", 3);
            itemList.Add(bench);

            item mazeMap = new item("map for the maze",3);


            item fountainCherub = new item("fountain cherub tipping a vase", 3);
            itemList.Add(fountainCherub);

            item knife = new item("butcher knife", 2);
            itemList.Add(knife);

            item drainPlug = new item("drain plug", 3);
            itemList.Add(drainPlug);

            item bedpostKnob = new item("bedpost knob", 0);
            itemList.Add(bedpostKnob);

            item lamp = new item("bedside lamp", 3);
            itemList.Add(lamp);

            item towel = new item("bath towel", 0);
            itemList.Add(towel);

            item trashBag = new item("roll of trashbags", 0);
            trashBag.nestItem = mazeMap;
            itemList.Add(trashBag);

            item trapDoor = new item("trap door", 2);
            itemList.Add(trapDoor);

            item bible = new item("NIV Bible", 0);
            itemList.Add(bible);


            
                
            
        }



        static public void initmap() {
            room pos = startroom;
            roomlist.Add(startroom);
            Direction randdir;
            Random rand1 = new Random();
            KeyNotFoundException check = new KeyNotFoundException();
            item randItem;

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next(0,3));
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You stand in a magnificent dining room.", "Dining Room", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for(int i =0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if(randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You are in a billiard room. Fun.", "Billiard Room", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You are in a small chapel.", "Chapel", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You are standing in a greenhouse.", "Greenhouse", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You see a beautiful garden all around you.", "Garden", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("The entrance to a topiary maze confronts you.", "Maze", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You're in a subway stat-wait, nope, it's a kitchen.", "Kitchen", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You're in what looks like someone's bedroom.", "Bedroom", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("You are standing in the biggest linen closet you've ever seen.", "Linen Closet", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }

            while (true)
            {
                pos = randroom();
                randdir = (Direction)(rand1.Next() % 4);
                if (pos.adjacentRooms[randdir] == null)
                {
                    pos.addfrom("Phew, you're now in a room full of garbage. Who would purposely put a room like this in their house?", "Trash Room", randdir);
                    pos = pos.adjacentRooms[randdir];
                    roomlist.Add(pos);
                    for (int i = 0; i < 2; i++)
                    {
                        while (true)
                        {
                            randItem = randRoomItem();
                            if (randItem.used == false)
                            {
                                pos.roomItemAdd(randItem);
                                break;
                            }
                        }
                    }
                    pos = randroom();
                    break;
                }
            }
                
                    
        }

        private static item randRoomItem()
        {
            Random rand3 = new Random();
            return itemList[rand3.Next() % itemList.Count];
        }
    }
}