using System.IO;
using System;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace ConsoleApplication3
{
    internal class saves
    {
        //static public Textreader saves = new StreamReader("saves.dat");

        static public int findSaves()
        {
            int num_saves = 0;
            TypeInitializationException thing = new TypeInitializationException("Oh noes!", null);

            try
            {
                using (StreamReader saves = File.OpenText("Saves/saves.dat"))
                {
                    string s,S;
                    while ((s = saves.ReadLine()) != null)
                    {
                        S = s.ToUpper();
                        if (S.Contains("NAME"))
                            num_saves++;
                    }
                }
                return num_saves;

            }
            catch (Exception e)
            {
                return 0;
            }

        }


        static public List<string> savesurvey()
        {
            TypeInitializationException thing = new TypeInitializationException("Oh noes!", null);

            List<string> stringsurvey = new List<string>();

            try
            {
                using (StreamReader saves = File.OpenText("Saves/saves.dat"))
                {
                    string s, S;
                    while ((s = saves.ReadLine()) != null)
                    {
                        S = s.ToUpper();
                        if (S.Contains("NAME"))
                        {
                            stringsurvey.Add(saves.ReadLine());
                            stringsurvey.Add(saves.ReadLine());
                            stringsurvey.Add(saves.ReadLine());
                        }
                            
                            
                    }
                }
                return stringsurvey;

            }
            catch (Exception e)
            {
                Console.WriteLine("File 'Saves/saves.dat' could not be opened.");
                return null;
            }


        }

        static public string savestring = "saves.dat";

        static public void save()
        {
            if (playerChar.location == null)
            {
                Console.WriteLine("Please do not try to access player stats when the player has not been initialized");
                return;
            }
            bool priorExist = true;
            int numEntry = 0;
            if (!Directory.Exists("Saves"))
            {

                Directory.CreateDirectory("Saves");
                if (!Directory.Exists("Saves"))
                    Console.WriteLine("Successfully created directory 'Saves'");

            }
            if (!File.Exists("Saves/saves.dat"))
            {

                priorExist = false;
            }

            if (priorExist == true)
            {
                using (StreamReader saves = File.OpenText("Saves/saves.dat"))
                {
                    string s, S;
                    while ((s = saves.ReadLine()) != null)
                    {
                        S = s.ToUpper();
                        if (S.Contains("NAME"))
                        {
                            numEntry++;
                        }


                    }
                    saves.Close();
                }
            }

            try
            {

                using ( StreamWriter save = new StreamWriter("Saves/saves.dat",true))
                {

                    bool overWrite = false;
                    
                    if(playerChar.saveFileIndex != -1)
                    {
                        while (true)
                        {
                            Console.WriteLine("Would you like to overwrite this save file or create another file?");
                            string saveInput = inPut.getInput();
                            saveInput = saveInput.ToUpper();
                            if(saveInput.Contains("Y"))
                            {
                                Console.WriteLine("Are you sure?");
                                saveInput = inPut.getInput();
                                saveInput = saveInput.ToUpper();
                                if (saveInput.Contains("Y"))
                                {
                                    overWrite = true;
                                    break;
                                }
                            }
                            else if (saveInput.Contains("N"))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("That input was unintelligible, please respond with either a yes or no");
                            }
                        }
                    }
                    if (overWrite)
                    {
                        if (File.Exists("Saves/saves_temp.dat"))
                        {
                            Console.WriteLine("Inside File.Exists check, before delete");
                            File.Delete("Saves/saves_temp.dat");
                        }
                        save.Close();
                        using(StreamReader readTemp = File.OpenText("Saves/saves.dat"))
                        {
                           using(StreamWriter writeTemp = new StreamWriter("Saves/saves_temp.dat", false))
                            {
                                numEntry = -1;
                                string s, S;
                                bool worked = false;
                                Console.WriteLine("Here's player saveIndex: " + playerChar.saveFileIndex);
                                while ((s = readTemp.ReadLine()) != null)
                                {
                                    
                                    Console.WriteLine("Here's a thing!" + s);
                                    S = s.ToUpper();
                                    if (S.Contains("NAME"))
                                    {
                                        Console.WriteLine("Numentry: " + numEntry);
                                        numEntry++;
                                    }
                                    if(numEntry != playerChar.saveFileIndex || (worked == true))
                                    {
                                        Console.WriteLine("Writing non-used line: "+s);
                                        writeTemp.WriteLine(s);
                                    }
                                    else
                                    {
                                        writeTemp.WriteLine("Name:");
                                        writeTemp.WriteLine(playerChar.charname);
                                        writeTemp.WriteLine(playerChar.location.name);
                                        writeTemp.WriteLine(DateTime.Now.ToString());
                                        readTemp.ReadLine();
                                        readTemp.ReadLine();
                                        readTemp.ReadLine();
                                        worked = true;
                                    }

                                }
                                if (worked)
                                {
                                    try {

                                    string biggerPath = Path.Combine("Saves", playerChar.charname + playerChar.saveFileIndex.ToString());
                                    
                                    string charPath = Path.Combine(biggerPath, "char.dat");

                                    using (StreamWriter saveWriteChar = new StreamWriter(charPath))
                                    {
                                        saveWriteChar.WriteLine(playerChar.location.name);
                                        saveWriteChar.WriteLine("Inventory: ");
                                        for (int i = 0; i < playerChar.inventory.Count; i++)
                                        {

                                            if (playerChar.inventory[i].nestItem != null)
                                            {
                                                saveWriteChar.WriteLine(playerChar.inventory[i].itemName + " NEST " + playerChar.inventory[i].nestItem.itemName);

                                            }
                                            else
                                            {
                                                saveWriteChar.WriteLine(playerChar.inventory[i].itemName);
                                            }

                                        }
                                        saveWriteChar.Close();
                                    }
                                    string mapPath = Path.Combine(biggerPath, "map.dat");

                                    using (StreamWriter saveWriteMap = new StreamWriter(mapPath))
                                    {
                                        saveWriteMap.WriteLine("Rooms: ");
                                        for (int i = 0; i < roomMap.roomlist.Count; i++)
                                        {

                                            saveWriteMap.WriteLine(roomMap.roomlist[i].name);

                                            foreach (KeyValuePair<Direction, room> d in roomMap.roomlist[i].adjacentRooms)
                                            {
                                                if (roomMap.roomlist[i].adjacentRooms[d.Key] != null)
                                                    saveWriteMap.WriteLine(d.Key + "\t" + roomMap.roomlist[i].adjacentRooms[d.Key].name);
                                            }
                                            saveWriteMap.WriteLine(roomMap.roomlist[i].roomItems.Count);
                                            saveWriteMap.WriteLine("END");
                                        }
                                        saveWriteMap.Close();
                                    }
                                    string itemPath = Path.Combine(biggerPath, "item.dat");

                                    using (StreamWriter saveWriteItem = new StreamWriter(itemPath))
                                    {
                                        saveWriteItem.WriteLine("Items: ");
                                        for (int i = 0; i < roomMap.roomlist.Count; i++)
                                        {
                                            if (roomMap.roomlist[i].roomItems.Count != 0)
                                            {
                                                saveWriteItem.WriteLine(roomMap.roomlist[i].name);
                                                for (int j = 0; j < roomMap.roomlist[i].roomItems.Count; j++)
                                                {
                                                    if (roomMap.roomlist[i].roomItems[j].nestItem != null)
                                                    {
                                                        saveWriteItem.WriteLine(roomMap.roomlist[i].roomItems[j].itemName + " NEST " + roomMap.roomlist[i].roomItems[j].nestItem.itemName);

                                                    }
                                                    else
                                                    {
                                                        saveWriteItem.WriteLine(roomMap.roomlist[i].roomItems[j].itemName);

                                                    }

                                                }
                                                saveWriteItem.WriteLine("END");
                                            }
                                        }
                                        saveWriteItem.Close();
                                    }
                                    Console.WriteLine("Save Successful!");
                                }

                            


                        
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                Console.WriteLine("Save not successful :c");
                return;
            }
            Console.WriteLine("File overwrite was successful!");
                                    readTemp.Close();
                                    writeTemp.Close();
                                    File.Delete("Saves/saves.dat");
                                    File.Move("Saves/saves_temp.dat", "Saves/saves.dat");
                                    
                                }
                                else
                                {
                                    Console.WriteLine("File overwrite was unsuccessful");
                                    readTemp.Close();
                                    writeTemp.Close();
                                    File.Delete("Saves/saves_temp.dat");
                                }
                                


                            }
                        }
                    }
                    else
                    {
                        //numEntry++;
                        save.WriteLine(numEntry);          
                        save.WriteLine("Name:");
                        save.WriteLine(playerChar.charname);
                        save.WriteLine(playerChar.location.name);
                        save.WriteLine(DateTime.Now.ToString());
                        string biggerPath = Path.Combine("Saves", playerChar.charname + numEntry.ToString());
                        Directory.CreateDirectory(biggerPath);
                        string charPath = Path.Combine(biggerPath, "char.dat");
                        
                        using (StreamWriter saveWriteChar = new StreamWriter(charPath))
                        {
                            saveWriteChar.WriteLine(playerChar.location.name);
                            saveWriteChar.WriteLine("Inventory: ");
                            for (int i = 0; i < playerChar.inventory.Count; i++)
                            {
                                
                                if(playerChar.inventory[i].nestItem != null)
                                {
                                    saveWriteChar.WriteLine(playerChar.inventory[i].itemName + " NEST " + playerChar.inventory[i].nestItem.itemName);
                                    
                                }
                                else
                                {
                                    saveWriteChar.WriteLine(playerChar.inventory[i].itemName);
                                }

                            }
                            saveWriteChar.Close();
                        }
                        string mapPath = Path.Combine(biggerPath, "map.dat");

                        using (StreamWriter saveWriteMap = new StreamWriter(mapPath))
                        {
                            saveWriteMap.WriteLine("Rooms: ");
                            for (int i = 0; i < roomMap.roomlist.Count; i++)
                            {
                                
                                saveWriteMap.WriteLine(roomMap.roomlist[i].name);
                                
                                foreach (KeyValuePair<Direction,room> d in roomMap.roomlist[i].adjacentRooms)
                                {
                                    if(roomMap.roomlist[i].adjacentRooms[d.Key] != null)
                                        saveWriteMap.WriteLine(d.Key + "\t" + roomMap.roomlist[i].adjacentRooms[d.Key].name);
                                }
                                saveWriteMap.WriteLine(roomMap.roomlist[i].roomItems.Count);
                                saveWriteMap.WriteLine("END");
                            }
                            saveWriteMap.Close();
                        }
                        string itemPath = Path.Combine(biggerPath, "item.dat");

                        using (StreamWriter saveWriteItem = new StreamWriter(itemPath))
                        {
                            saveWriteItem.WriteLine("Items: ");
                            for (int i = 0; i < roomMap.roomlist.Count; i++)
                            {
                                if(roomMap.roomlist[i].roomItems.Count != 0)
                                {
                                    saveWriteItem.WriteLine(roomMap.roomlist[i].name);
                                    for (int j = 0; j < roomMap.roomlist[i].roomItems.Count; j++)
                                    {
                                        if(roomMap.roomlist[i].roomItems[j].nestItem != null)
                                        {
                                            saveWriteItem.WriteLine(roomMap.roomlist[i].roomItems[j].itemName + " NEST " + roomMap.roomlist[i].roomItems[j].nestItem.itemName);

                                        }
                                        else
                                        {
                                            saveWriteItem.WriteLine(roomMap.roomlist[i].roomItems[j].itemName);

                                        }

                                    }
                                    saveWriteItem.WriteLine("END");
                                }
                            }
                            saveWriteItem.Close();
                        }
                    }

                }

          
                Console.WriteLine("Save Successful!");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(e.Message);
                Console.WriteLine("Save not successful :c");
                return;
            }
        }

        internal static void mapImport(string newMapPath)
        {

            using (StreamReader mapImport = File.OpenText(newMapPath))
            {
                roomMap.initMapSaved();
                mapImport.ReadLine();
                string s, S;
                int itemNumeral;
                while ((s = mapImport.ReadLine()) != null)
                {
                    for (int i = 0; i < roomMap.roomlist.Count; i++)
                    {
                        if (s.Contains(roomMap.roomlist[i].name))
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                S = mapImport.ReadLine();
                                if (S.Contains("END"))
                                    break;
                                if (S.Contains("NORTH"))
                                {
                                    for (int k = 0; k < roomMap.roomlist.Count; k++)
                                    {
                                        if (S.Contains(roomMap.roomlist[k].name))
                                        {
                                            roomMap.roomlist[i].adjacentRooms[(Direction)0] = roomMap.roomlist[k];
                                            break;
                                        }
                                    }
                                }
                                else if (S.Contains("EAST"))
                                {
                                    for (int k = 0; k < roomMap.roomlist.Count; k++)
                                    {
                                        if (S.Contains(roomMap.roomlist[k].name))
                                        {
                                            roomMap.roomlist[i].adjacentRooms[(Direction)1] = roomMap.roomlist[k];
                                            break;
                                        }
                                    }
                                }
                                else if (S.Contains("SOUTH"))
                                {
                                    for (int k = 0; k < roomMap.roomlist.Count; k++)
                                    {
                                        if (S.Contains(roomMap.roomlist[k].name))
                                        {
                                            roomMap.roomlist[i].adjacentRooms[(Direction)2] = roomMap.roomlist[k];
                                            break;
                                        }
                                    }
                                }
                                else if (S.Contains("WEST"))
                                {
                                    for (int k = 0; k < roomMap.roomlist.Count; k++)
                                    {
                                        if (S.Contains(roomMap.roomlist[k].name))
                                        {
                                            roomMap.roomlist[i].adjacentRooms[(Direction)3] = roomMap.roomlist[k];
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (int.TryParse(S, out itemNumeral))
                                        roomMap.roomlist[i].itemNum = itemNumeral;
                                }
                            }

                        }
                    }
                    Console.WriteLine("Done with map import!");
                }
                mapImport.Close();

            }


        }


        internal static void itemImport(string newItemPath)
        {

            using (StreamReader itemImport = File.OpenText(newItemPath))
            {
                roomMap.initItemsImport();
                Console.WriteLine("Got past init items import!");

                string s, S, nestor;

                itemImport.ReadLine();
                while ((s = itemImport.ReadLine()) != null)
                {
                    for (int i = 0; i < roomMap.roomlist.Count; i++)
                    {
                        if (s.Contains(roomMap.roomlist[i].name))
                        {
                            Console.WriteLine(roomMap.roomlist[i].name);
                            for (int j = 0; j < (roomMap.roomlist[i].itemNum + 1); j++)
                            {
                                S = itemImport.ReadLine();
                                if (S.Contains("END"))
                                    break;

                                if (S.Contains("NEST"))
                                {
                                    Console.WriteLine("Got to a nest!");
                                    int firstIndex = S.IndexOf("NEST");
                                    int firstSpaceIndex = S.IndexOf(' ');

                                    string nest_parent = S.Substring(0, firstIndex);
                                    Console.WriteLine(nest_parent);
                                    for (int l = 0; l < (roomMap.itemList.Count); l++)
                                    {
                                        if (nest_parent.Contains(roomMap.itemList[l].itemName))
                                        {

                                            Console.WriteLine(roomMap.itemList[l].itemName);
                                            int roomIndexForNestItem = roomMap.roomlist[i].roomItems.Count;
                                            roomMap.roomlist[i].roomItems.Add(roomMap.itemList[l]);
                                                


                                            string nest_check = S.Substring(firstIndex, S.Length - firstIndex);

                                            for (int m = 0; m < (roomMap.itemList.Count); m++)
                                            {
                                                if (nest_check.Contains(roomMap.itemList[m].itemName))
                                                {

                                                    Console.WriteLine(roomMap.itemList[m].itemName);
                                                    roomMap.roomlist[i].roomItems[roomIndexForNestItem].nestItem = roomMap.itemList[m];
                                                    break;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    for (int l = 0; l < roomMap.itemList.Count; l++)
                                    {
                                        if (S.Contains(roomMap.itemList[l].itemName))
                                        {
                                            roomMap.roomlist[i].roomItems.Add(roomMap.itemList[l]);
                                            break;
                                        }
                                    }
                                    
                                }
                                
                                    
                                


                            }
                            break;
                        }
                        Console.WriteLine("Done with checking some stuff!");
                    }
                }
                Console.WriteLine("Done with items import!");
            }

        }

        internal static void charImport(string newCharPath)
        {

            using (StreamReader charImport = File.OpenText(newCharPath))
            {
                //Console.WriteLine("Inside charImport");
                string charImporterHelp = charImport.ReadLine();
                for (int i = 0; i < roomMap.roomlist.Count; i++)
                {
                    if (charImporterHelp.Contains(roomMap.roomlist[i].name))
                        playerChar.location = roomMap.roomlist[i];
                }
                //charImporterHelp = charImport.ReadLine();
                string s, S, nestor;

                charImport.ReadLine();

                while ((s = charImport.ReadLine()) != null)
                {

                    //Console.WriteLine(s);
                    if (s.Contains("NEST"))
                    {

                        //Console.WriteLine("It has a nested object");
                        int firstIndex = s.IndexOf("NEST");
                        int firstSpaceIndex = s.IndexOf(' ');

                        string nest_parent = s.Substring(0, firstSpaceIndex);

                        for (int k = 0; k < (roomMap.itemList.Count); k++)
                        {
                            if (nest_parent.Contains(roomMap.itemList[k].itemName))
                            {

                                //Console.WriteLine(roomMap.itemList[k].itemName);
                                int inventoryIndexForNestItem = playerChar.inventory.Count;
                                playerChar.inventory.Add(roomMap.itemList[k]);


                                string nest_check = s.Substring(firstIndex, s.Length - firstIndex);

                                for (int j = 0; j < (roomMap.itemList.Count); j++)
                                {
                                    if (nest_check.Contains(roomMap.itemList[j].itemName))
                                    {

                                        //Console.WriteLine(roomMap.itemList[k].itemName);
                                        playerChar.inventory[inventoryIndexForNestItem].nestItem = roomMap.itemList[j];
                                    }
                                }
                            }
                        }


                    }
                    else
                    {
                        for (int j = 0; j < (roomMap.itemList.Count); j++)
                        {

                            if (s.Contains("END"))
                                break;


                            if (s.Contains(roomMap.itemList[j].itemName))
                            {
                                playerChar.inventory.Add(roomMap.itemList[j]);
                                Console.WriteLine(roomMap.itemList[j].itemName);


                                if (s.Contains("NEST"))
                                {
                                    break;

                                }
                            }

                            //Console.WriteLine("Inside for-loop j: " + j);
                            //Console.WriteLine("Here's itemlist.count" + roomMap.itemList.Count);

                        }

                    }


                }
            }

        }

        internal static void saveImport(int saveNumIndex)
        {
            string saveNum = saveNumIndex.ToString();
            int numIndex = -1;
            string bigFilePath = "Path not found";
            using (StreamReader saves = File.OpenText("Saves/saves.dat"))
            {
                string s, S;

                while ((s = saves.ReadLine()) != null)
                {
                    S = s.ToUpper();
                    if (S.Contains("NAME"))
                    {
                        numIndex++;
                    }
                    if ( numIndex == saveNumIndex)
                    {
                        S = saves.ReadLine();
                        playerChar.charname = S;
                        bigFilePath = S + saveNum;

                        Console.WriteLine(bigFilePath);
                        break;
                    }

                }
                saves.Close();
                if (bigFilePath == "Path not found")
                {
                    Console.WriteLine(bigFilePath);
                    return;
                }
            }
            string newCharPath = Path.Combine("Saves", bigFilePath, "char.dat");
            string newItemPath = Path.Combine("Saves", bigFilePath, "item.dat");
            string newMapPath  = Path.Combine("Saves", bigFilePath, "map.dat");
            //string[] pathArray = { newCharPath, newItemPath, newMapPath };
            
            try
            {
                mapImport(newMapPath);

                Console.WriteLine(newItemPath);

                itemImport(newItemPath);
                charImport(newCharPath);
                                
                Console.WriteLine( "Done with char import!");
                playerChar.saveFileIndex = saveNumIndex;
            }
            catch (Exception)
            {                
                throw;
            }
        }

        

        static public void writer(string mystring)
        {
            File.AppendAllText(savestring, mystring);
        }

        static public byte[] getBytes(string mystring)
        {
            byte[] stuff = new UTF8Encoding(true).GetBytes(mystring);
            return stuff;
        }

    }
}