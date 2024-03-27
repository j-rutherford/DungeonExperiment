using CreatureLibrary;

namespace RoomLibrary
{
    public class Room
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int IdNorth { get; set; }
        public int IdEast { get; set; }
        public int IdSouth { get; set; }
        public int IdWest { get; set; }
        public Monster Monster { get; set; }

        public Room(int id, string? name, string? description, int idNorth, int idEast, int idSouth, int idWest, int monsterId)
        {
            ID = id;
            Name = name;
            Description = description;
            IdNorth = idNorth;
            IdEast = idEast;
            IdSouth = idSouth;
            IdWest = idWest;
            this.Monster = Monster.GetMonsterById(monsterId);
        }

        public static Room[] GetRooms()
        {
            return new Room[]{
                new Room(0, "ID 0", null, 1, 4, 2, 3,4),
                new Room(1, "ID 1", null, 13, 5, 0, 17,4),
                new Room(2, "ID 2", null, 0,7,16,11,4),
                new Room(3, "ID 3", null, 17,0,11,15,1),
                new Room(4, "ID 4", null, 5,6,7,0,0),
                new Room(5, "ID 5", null, 8,9,4,1,4),
                new Room(6, "ID 6", null, 9,16,10,4,4),
                new Room(7, "ID 7", null, 4,10,16,2,1),
                new Room(8, "ID 8", null, 15,14,5,13,4),
                new Room(9, "ID 9", null, 14,16,6,5,2),
                new Room(10, "ID 10", null, 6,16,16,7,3),
                new Room(11, "ID 11", null, 3,2,16,15,4),
                new Room(12, "ID 12", null, 15,13,17,15,4),
                new Room(13, "ID 13", null, 15,8,1,12,4),
                new Room(14, "ID 14", null, 15,15,9,8,3),
                new Room(15, "(Inaccessable 1)", null, 15,15,15,15,2),
                new Room(16, "(Inaccessable 2)", null, 16,16,16,16,0),
                new Room(17, "Final Boss", null, 12,1,3,15,3),
            };
        }
        public static Room GetRoomById(int id)
        {
            return GetRooms().FirstOrDefault(x => x.ID == id);
        }
        public static Room[,] GetMap()
        {


            return new Room[,]
            {
                //Row1
                { GetRoomById(15),GetRoomById(15),GetRoomById(15),GetRoomById(15),GetRoomById(15),GetRoomById(15) },
                //Row2
                { GetRoomById(15),GetRoomById(12),GetRoomById(13),GetRoomById(8),GetRoomById(14),GetRoomById(16) },
                //Row3
                { GetRoomById(15),GetRoomById(17),GetRoomById(1),GetRoomById(5),GetRoomById(9),GetRoomById(16) },
                //Row4
                { GetRoomById(15), GetRoomById(3), GetRoomById(0),GetRoomById(4),GetRoomById(6),GetRoomById(16)},
                //Row 5  
                { GetRoomById(15),GetRoomById(11),GetRoomById(2),GetRoomById(7),GetRoomById(10),GetRoomById(16)},
                //Row 6
                { GetRoomById(16),GetRoomById(16),GetRoomById(16),GetRoomById(16),GetRoomById(16),GetRoomById(16)}
            };
        }
        public static void PrintMap(int currentId = 1)
        {
            var map = GetMap();

            CenterText("World Map");
            string border = "------------------------------";
            int padding = Console.WindowWidth / 2 + border.Length / 2;
            Console.WriteLine(border.PadLeft(padding));

            for (int i = 0; i < map.GetLength(0); i++)
            {
                Console.Write("".PadLeft(Console.WindowWidth / 2 - border.Length / 2));
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    var loc = map[i, j];
                    Console.Write($"| ");
                    if (loc.ID == currentId)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (loc.ID is 15 or 16)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write($"{loc.ID:d2} ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
                Console.WriteLine(border.PadLeft(padding));
            }
        }
        public void RoomMap()
        {
            CenterText($"North: {GetRoomById(IdNorth).Name}\n\n");
            CenterText($"West: {GetRoomById(IdWest).Name}               East: {GetRoomById(IdEast).Name}\n");
            CenterText($"South: {GetRoomById(IdSouth).Name}\n\n");
            CenterText($"In this room... {this.Monster}");
        }
        public Room MoveRoom(int id)
        {
            if (id != 15 && id != 16)
            {
                return GetRoomById(id);
            }
            else
            {
                Console.WriteLine("You can't move that way!");
                return this;
            }
        }
        private static void CenterText(string text)
        {
            Console.WriteLine("{0," + (Console.WindowWidth / 2 + text.Length / 2) + " }", text);
        }
    }
}