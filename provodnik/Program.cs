using System.IO;
using static System.Net.WebRequestMethods;

namespace provodnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            drives();
        }
        public static string drives(ConsoleKeyInfo key, int position)
        {
            string path;
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo i in drives)
            {
                if (i.IsReady)
                {
                    Console.WriteLine($"  {i.Name} Свободно {i.TotalFreeSpace / 1000000000} Гб из {i.TotalSize / 1000000000} Гб ");
                    if (key.Key == ConsoleKey.Enter)
                    {
                        string[] write = Directory.GetDirectories(i.Name);
                        foreach (string papki in write)
                        {
                            float size = papki.Length;
                            Console.WriteLine("  " + papki + "    " + size);
                        }
                        path = Directory.GetCurrentDirectory();
                    }
                }
            }
            cursor();
            return path;
        }

        public static int cursor(string path)
        {
            ConsoleKeyInfo key;
            int position = 0;
            do
            {

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    position--;

                }

            } while (key.Key != ConsoleKey.Enter);
            Console.Clear();
            Console.SetCursorPosition(0, position);
            Console.Write("->");

            if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine("  ");
                Console.WriteLine("  ");
                Console.WriteLine("  ");
                Console.WriteLine("  ");
                Console.WriteLine("  ");
                Console.WriteLine("  ");
            }

            else if (key.Key == ConsoleKey.F1)
            {
                Console.WriteLine("введите название папки, которую хотите создать...");
                string folder = Console.ReadLine();
                Directory.CreateDirectory(folder);
            }

            if (key.Key == ConsoleKey.F2)
            {
                Console.WriteLine("введите название файла, который хотите создать...");
                string file = Console.ReadLine();
                string path_file = Path.GetDirectoryName(file);
                File.Create(file);
            }

            return position;
        }
    }
}