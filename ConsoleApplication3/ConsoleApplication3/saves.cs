using System.IO;
using System;
using System.Text;
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
                File.Create("Saves/saves.dat");
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

                    bool overWrite;
                    while (true)
                    {
                        Console.WriteLine("Would you like to overwrite this save file or create another file?");
                        string saveInput = inPut.getInput();
                        bool good;
                        bool.TryParse(saveInput, out good);
                        if(good == true)
                        {
                            overWrite = true;
                            break;
                        }
                    }
                    if (overWrite)
                    {
                        save.Close();
                        using (StreamReader saves = File.OpenText("Saves/saves.dat"))
                        {
                            numEntry = -1;
                            string s, S;
                            while ((s = saves.ReadLine()) != null)
                            {
                                S = s.ToUpper();
                                if (S.Contains("NAME"))
                                {
                                    numEntry++;
                                }
                                if(numEntry == playerChar.saveFileIndex)
                                {

                                }

                            }
                            saves.Close();
                        }
                    }

                        numEntry++;
                    save.WriteLine(numEntry);          
                    save.WriteLine("Name:");
                    save.WriteLine(playerChar.charname);

                }

          
                Console.WriteLine("Save Successful!");
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Save not successful :c");
                return;
            }
        }

        internal static void saveImport(int saveNumIndex)
        {
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
                    if (numIndex == saveNumIndex)
                    {
                        bigFilePath = saves.ReadLine();
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
            string[] pathArray = { newCharPath, newItemPath, newMapPath };
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    using (StreamReader saves = File.OpenText(pathArray[i]))
                    {
                        saves.Close();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
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