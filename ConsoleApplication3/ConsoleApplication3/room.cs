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

        public room(string mapConstr)
        {
            int i;
            int Index1 = mapConstr.IndexOf('#');
            int Index2 = mapConstr.IndexOf('%');
            name = mapConstr.Substring(Index1 + 1, Index2 - Index1 - 1);
            Index1 = mapConstr.IndexOf('#', Index2);
            int.TryParse(mapConstr.Substring(Index2 + 1, Index1 - Index2 - 1), out descripInd);
            Index2 = mapConstr.IndexOf('%', Index1);
            int.TryParse(mapConstr.Substring(Index1, Index2 - Index1), out itemNum);
            Index1 = mapConstr.IndexOf('#', Index2);
            i = mapConstr.IndexOf('&', Index2);

            while(Index1 < i )
            {                
                Index2 = mapConstr.IndexOf('%', Index1);
                descriptions.Add(mapConstr.Substring(Index1 + 1, Index2 - Index1 - 1));
                Index1 = mapConstr.IndexOf('#', Index2);                
            }
            Index2 = mapConstr.IndexOf('%', i);
            do
            {

            } while ((Index1+1) != mapConstr.Length);
        }


        public void add(string r, string n)
        {
            room newroom = new room(r, n);
            newroom.name = n;
        }

        public void addfrom(string r, string n, Direction to)
        {
            room newroom = new room(r,n);
            newroom.name = n;
            newroom.adjacentRooms[(Direction)(((int)to + 2)%4)] = this;
            this.adjacentRooms[to] = newroom;
        }

        public string print()
        {
            string returner, temp = "";
            returner = "#" + name + "%" + descripInd + "#" + itemNum + "%";
            for(int i = 0; i < descriptions.Count; i++)
            {
                temp += "#" + descriptions[i] + "%";
            }
            returner += temp;
            temp = "";
            for (int i = 0; i < 4; i++)
            {
                if(adjacentRooms[(Direction)i] != null)
                    temp += "&" + adjacentRooms[(Direction)i].name + "%" + i + "#";
            }
            //This last bit can't work, if I'm gonna use a constructor, anyway, cause 
            //then I'd need to include the entire object in the line. Although,
            //to be fair, that might actually be easier. But in either case I'd
            //have to search through the room list to see if they had already
            // been instantiated. I guess I could look at this as a graph
            //algorithm problem though, interestingly. I guess I could use a dfs to
            //output it in a sort of topologically sorted order. Nah, cause I need to
            //associate them backwards. But I guess I could do that at construction
            // I'd just need to carry it out on leaves first
            returner += temp;
            return returner;

        }
    }
}