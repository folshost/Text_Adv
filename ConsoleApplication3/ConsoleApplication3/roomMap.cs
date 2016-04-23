using System;
using System.IO;
using System.Collections.Generic;
namespace ConsoleApplication3
{
    internal class roomMap
    {

        //static public FileStream items = new FileStream("items.dat",FileMode.Open,FileAccess.Read);
        //static public FileStream rooms = new FileStream("rooms.dat", FileMode.Open, FileAccess.Read);

        static public room startroom = new room("You are standing at the foot of a long driveway, there is a mailbox", "Driveway");

        static public List<room> roomlist = new List<room>();

        static public List<item> itemList = new List<item>();


        static public void printItems()
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                Console.WriteLine(itemList[i].print() + '\n');
            }
        }

        static public room randroom()
        {
            Random rand2 = new Random();
            return roomlist[rand2.Next() % roomlist.Count];
        }

        static public void itemsSave()
        {
            using(StreamWriter itemSave = new StreamWriter("item_names&descriptions.txt", true))
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    itemSave.WriteLine(itemList[i].itemName);
                    itemSave.WriteLine(itemList[i].itemLoc);
                }
            }
        }

        static public void initItemsImport()
        {
            try
            {
                using(StreamReader itemsImport = File.OpenText("item_names&descriptions.txt"))
                {
                    string s1,s2,s3,S;
                    int itemLoc;
                    item pos;
                    while(((s1 = itemsImport.ReadLine()) != null) && ((s2 = itemsImport.ReadLine()) != null) && ((s3 = itemsImport.ReadLine()) != null))
                    {
                        int.TryParse(s2, out itemLoc);
                        pos = new item(s1, itemLoc, s3);
                        itemList.Add(pos);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            Random rand1 = new Random();
            for(int i = 0; i < 2; i++)
            {
                int one = rand1.Next()%itemList.Count, two = rand1.Next()%itemList.Count;
                itemList[one].nestItem = itemList[two];
                itemList.Remove(itemList[two]);
            }
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

        static public void initMapSaved()
        {
            room pos = startroom;
            roomlist.Add(startroom);
            KeyNotFoundException check = new KeyNotFoundException();            
            TypeInitializationException thing = new TypeInitializationException("Oh noes!", null);


            try
            {
                using (StreamReader descrip = File.OpenText("room_names&descriptions.txt"))
                {
                    string s, S;
                    while ((s = descrip.ReadLine()) != null && (S = descrip.ReadLine()) != null)
                    {
                        pos = new room(s, S);
                        roomlist.Add(pos);
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Trying to initialize the map resulted in failure, please restart the game when \nthis file has been replaced");
                throw e;
            }

        }


        static public void initMap() {
            room pos = startroom;
            roomlist.Add(startroom);
            Direction randdir;
            Random rand1 = new Random();
            KeyNotFoundException check = new KeyNotFoundException();
            item randItem;
            TypeInitializationException thing = new TypeInitializationException("Oh noes!", null);

            
            try
            {
                using (StreamReader descrip = File.OpenText("room_names&descriptions.txt"))
                {
                    string s, S;
                    while ((s = descrip.ReadLine()) != null && (S = descrip.ReadLine()) != null )
                    {
                        while (true)
                        {
                            pos = randroom();
                            randdir = (Direction)(rand1.Next(0, 3));
                            if (pos.adjacentRooms[randdir] == null)
                            {
                                pos.addfrom(s, S, randdir);
                                pos = pos.adjacentRooms[randdir];
                                roomlist.Add(pos);
                                for (int i = 0; i < 2; i++)
                                {
                                    while (true)
                                    {
                                        randItem = randRoomItem(rand1);
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
                }
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Trying to initialize the map resulted in failure, please restart the game when \nthis file has been replaced");
                throw e;
            }

            /*
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
                            randItem = randRoomItem(rand1);
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
            */


        }

        private static item randRoomItem(Random rand1)
        {
            return itemList[rand1.Next() % itemList.Count];
        }
    }
}