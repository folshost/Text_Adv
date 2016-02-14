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
                using (StreamReader saves = File.OpenText("saves.dat"))
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
                using (StreamReader saves = File.OpenText("saves.dat"))
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
                throw e;
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
            using ( StreamWriter save = new StreamWriter("saves.dat",true))
            {
                save.WriteLine("Name:");
                save.WriteLine(playerChar.charname);

            }

          
            Console.WriteLine("Save Successful!");
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