using System;
using Maze.Domain;

namespace Maze.Explorer.ActionStrategy
{
    public class TurnLeftStrategy : IExplorerActionStrategy
    {
        public bool DoAction(MazeExplorer explorer)
        {
            int currentDirection = (int)explorer.CurrentDirection;
            int newDirection = currentDirection == 0 ? Enum.GetValues(typeof(ExplorerDirection)).Length-1 : currentDirection - 1;
            explorer.CurrentDirection = (ExplorerDirection)newDirection;

            Console.WriteLine($"You turn left. ({explorer.CurrentDirection})");
            return true;

        }
    }
}
