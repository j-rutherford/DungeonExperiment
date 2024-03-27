using RoomLibrary;
using CreatureLibrary;

namespace Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //var map = Room.GetMap();

            Room currentRoom = Room.GetRoomById(0);
            Move(currentRoom);

            Console.WriteLine(currentRoom); 


        }
        static void Move(Room currentRoom)
        {
                        do
            {
                Room.PrintMap(currentRoom.ID);
                currentRoom.RoomMap();
                Console.WriteLine(currentRoom.Description);
                //Console.WriteLine(currentRoom.Monster);
                Console.WriteLine("Pick a direction. Press Tab to escape.");
                int direction = 0;
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        direction = currentRoom.IdNorth;
                        break;
                    case ConsoleKey.RightArrow:
                        direction = currentRoom.IdEast;
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = currentRoom.IdWest;
                        break;
                    case ConsoleKey.DownArrow:
                        direction = currentRoom.IdSouth;
                        break;
                    case ConsoleKey.Tab:
                        return;
                    default:
                        direction = currentRoom.ID;
                        break;
                }//end switch
                Console.Clear();
                currentRoom = currentRoom.MoveRoom(direction);
            } while (true);
        }
    }
}