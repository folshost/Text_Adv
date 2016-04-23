using System;

namespace ConsoleApplication3
{
    public class item
    {
        public int size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
                
        }

        public bool used = false;
        public item nestItem = null;
        public string itemName;
        public string itemDescrip;
        // itemloc says where in the room the item is
        // 0 - Along a wall
        // 1 - On the ceiling
        // 2 - In/on the floor
        // 3 - In the middle of the floor
        public int itemLoc;

        public item(string name, int loc, string description)
        {
            itemName = name;
            itemLoc = loc;
            itemDescrip = description;
        }

        public item(string name, int loc)
        {
            itemName = name;
            itemLoc  = loc;
        }

        public item(string itemThing)
        {
            int i;
            int Index1 = itemThing.IndexOf('#');
            int Index2 = itemThing.IndexOf('%');
            itemName = itemThing.Substring(Index1+1, Index2 - Index1 - 1);
            //Console.WriteLine(itemName);            
            Index1 = itemThing.IndexOf('#',Index2);
            itemDescrip = itemThing.Substring(Index2+1, Index1 - Index2 - 1);
            //Console.WriteLine(itemDescrip);
            Index2 = itemThing.IndexOf('%', Index1);
            int.TryParse(itemThing.Substring(Index1, Index2 - Index1),out itemLoc);
            //Console.WriteLine(itemLoc);
            if ( itemThing.IndexOf('#', Index2) != -1)
            {
                //Console.WriteLine("Found a nest!");
                nestItem = new item(itemThing.Substring(Index2 + 1));
            }
        }

        public string print()
        {
            string combine;
            combine = "#" + itemName + "%" + itemDescrip + "#" + itemLoc + "%";

            if (nestItem != null)
            {
                combine = combine + nestItem.print();
            }
            return combine;
        }
    }
}