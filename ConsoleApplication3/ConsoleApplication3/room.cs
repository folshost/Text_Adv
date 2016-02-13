using System.Collections.Generic;


namespace ConsoleApplication3
{
    internal class room
    {
        public static string description_0 = "It is dark. You are likely to be eaten by a grue";
        public string name;
        public int descripInd = 0;
        public int itemNum = 0;
        internal Dictionary<Direction, room> adjacentRooms = new Dictionary<Direction, room>();
        internal List<string> descriptions = new List<string>();
        internal List<item> roomItems = new List<item>();
        internal List<person> people = new List<person>();

        public room(string r, string n)
        {
            name = n;
            descriptions.Add(r);
            adjacentRooms[(Direction)0] = null;
            adjacentRooms[(Direction)1] = null;
            adjacentRooms[(Direction)2] = null;
            adjacentRooms[(Direction)3] = null;

        }

        public void roomItemAdd(item Item)
        {
            roomItems.Add(Item);
            Item.used = true;
            itemNum++;
        }

        public room() {
        }

        public void addfrom(string r, string n, Direction to)
        {
            room newroom = new room(r,n);
            newroom.name = n;
            newroom.adjacentRooms[(Direction)(((int)to + 2)%4)] = this;
            this.adjacentRooms[to] = newroom;
        }

    }
}