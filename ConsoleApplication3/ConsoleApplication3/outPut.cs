using System.IO;
using System;
namespace ConsoleApplication3
{
    internal class outPut
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
                    string s;
                    while ((s = saves.ReadLine()) != null)
                    {
                        if (s.Contains("NAME"))
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




    }
}