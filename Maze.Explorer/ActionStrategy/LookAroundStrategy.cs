using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Maze.Domain;

namespace Maze.Explorer.ActionStrategy
{
    public class LookAroundStrategy : IExplorerActionStrategy
    {
        public bool  DoAction(MazeExplorer explorer)
        {
            var itemsAround = explorer.CurrentMaze.Items.Where(i =>
                i.XCord >= explorer.CurrentXCord - 1 &&
                i.XCord <= explorer.CurrentXCord + 1 &&
                i.YCord >= explorer.CurrentYCord - 1 &&
                i.YCord <= explorer.CurrentYCord + 1).ToList();

            int count = 0;
            string line = "";
            itemsAround.ForEach(i =>
            {
                if (count == 3)
                {
                    Console.WriteLine(line);
                    count = 0;
                    line = "";
                }
                line += MazeItemToText(i.Type);
                count++;
            });
            Console.WriteLine(line);
            return true;
        }

        // todo Duplicate from maze service
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
    }
}
