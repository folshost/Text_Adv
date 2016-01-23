using System.Collections.Generic;


namespace ConsoleApplication3
{
    internal class room
    {
        public static string description0 = "It is dark. You are likely to be eaten by a grue";
        public string name;
        public string description;
        internal Dictionary<Direction, room> adjacentRooms = new Dictionary<Direction, room>();



        public room(string r, string n)
        {
            name = n;
            description = r;
            adjacentRooms[(Direction)0] = null;
            adjacentRooms[(Direction)1] = null;
            adjacentRooms[(Direction)2] = null;
            adjacentRooms[(Direction)3] = null;

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