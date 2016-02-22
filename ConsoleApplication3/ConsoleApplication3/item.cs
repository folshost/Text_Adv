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

    }
}