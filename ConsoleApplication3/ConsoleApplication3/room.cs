using System.Collections.Generic;


namespace ConsoleApplication3
{
    internal class room
    {
        public string name;
        public string description;
        public Dictionary<Direction, room> adjacentRooms;
        public room(string r, string n)
        {
            name = n;
            description = r;
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