using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Maze.Domain;
using static System.String;

namespace Maze
{
    public class MazeService
    {
        public IEnumerable<MazeItem> ReadMapFile(string filename)
        {
            List<MazeItem> items = new List<MazeItem>();
            //todo Add error handling if filename does not exist
            using (StreamReader sr = File.OpenText(filename))
            {
                string line;
                int y = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    int x = 0;
                    items.AddRange(line.Select(l =>
                    {
                        x++;
                        return new MazeItem(x, y, l.ToString());
                    }));
                    y++;
                }
            }

            return items;
        }

        public void ViewMaze(MazeStructure maze)
        {
            string line = Empty;
            maze.Items.ToList().ForEach(i =>
            {
                if (i.XCord == 1)
                {
                    Console.WriteLine(line);
                    line = Empty;
                }
                line += MazeItemToText(i.Type);
            });
            // Print the last line
            Console.WriteLine(line);
        }

        public MazeItem GetMazeItem(MazeStructure maze, int xCord, int yCord)
        {
            return maze.Items.FirstOrDefault(i => i.XCord == xCord && i.YCord == yCord);
        }

        public void Stats(MazeStructure maze)
        {
            int spaceCount = maze.Items.Count(i => i.Type == MazeItemType.Space);
            int wallCount = maze.Items.Count(i => i.Type == MazeItemType.Wall);
            Console.WriteLine("Maze Stats");
            Console.WriteLine($"Spaces: {spaceCount}");
            Console.WriteLine($"Walls: {wallCount}");
        }

        private string MazeItemToText(MazeItemType type)
        {
            switch (type)
            {
                case MazeItemType.Finish:
                    return "F";
                case MazeItemType.Space:
                    return " ";
                case MazeItemType.Start:
                    return "S";
                default:
                    return "X";
            }
        }


        public void ViewItem(MazeStructure maze, int xCord, int yCord)
        {
            var item = GetMazeItem(maze, xCord, yCord);
            if (item == null)
            {
                Console.WriteLine("That location does not exist in the maze");
            }
            else
            {
                Console.WriteLine($"Location {xCord}:{yCord} is {item.Type}");
            }


        }
    }

}
