using System;
using System.Linq;
using Maze.Domain;

namespace Maze.Explorer.ActionStrategy
{
    public class TurnRightStrategy : IExplorerActionStrategy
    {
        public bool DoAction(MazeExplorer explorer)
        {
            int currentDirection = (int)explorer.CurrentDirection;
            int newDirection = (currentDirection == Enum.GetValues(typeof(ExplorerDirection)).Length) ? 0 : currentDirection + 1;

            explorer.CurrentDirection = (ExplorerDirection)newDirection;
            Console.WriteLine($"You turn right. ({explorer.CurrentDirection})");
            return true;
        }
    }
}
