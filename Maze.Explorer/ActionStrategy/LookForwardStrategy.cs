using System;
using System.Linq;
using Maze.Domain;

namespace Maze.Explorer.ActionStrategy
{
    public class LookForwardStrategy : IExplorerActionStrategy
    {
        public bool DoAction(MazeExplorer explorer)
        {
            int xCord = explorer.CurrentXCord;
            int yCord = explorer.CurrentYCord;
            switch (explorer.CurrentDirection)
            {
                case ExplorerDirection.North:
                    yCord--;
                    break;
                case ExplorerDirection.East:
                    xCord++;
                    break;
                case ExplorerDirection.South:
                    yCord++;
                    break;
                case ExplorerDirection.West:
                    xCord--;
                    break;
            }
            var item = explorer.CurrentMaze.Items.FirstOrDefault(i => i.XCord == xCord && i.YCord == yCord);
            
            Console.WriteLine($"Ahead of you is a {item.Type}");
            return item.Type != MazeItemType.Wall;
        }
    }
}
