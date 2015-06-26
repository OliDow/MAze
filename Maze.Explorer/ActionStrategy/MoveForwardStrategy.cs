using System;
using System.Linq;
using Maze.Domain;


namespace Maze.Explorer.ActionStrategy
{
    public class MoveForwardStrategy : IExplorerActionStrategy
    {
        public bool DoAction(MazeExplorer explorer)
        {
            int xCord = explorer.CurrentXCord;
            int yCord = explorer.CurrentYCord;

            switch (explorer.CurrentDirection)
            {
                case ExplorerDirection.North:
                    yCord =yCord-1;
                    break;
                case ExplorerDirection.East:
                    xCord = xCord+1;
                    break;
                case ExplorerDirection.South:
                    yCord = yCord+1;
                    break;
                case ExplorerDirection.West:
                    xCord =xCord-1;
                    break;  
            }

            MazeItem newItem = explorer.CurrentMaze.Items.FirstOrDefault(i => i.XCord == xCord && i.YCord == yCord);

            // This should never happen if the map is designed correctly.
            if (newItem == null)
            {
                Console.WriteLine("New coordinate doesn't exist");
                return false;
            }

            
            switch (newItem.Type)
            {
                case MazeItemType.Space:
                    explorer.ActionHistory.Add(ExplorerAction.MoveForward);
                    explorer.CurrentXCord = xCord;
                    explorer.CurrentYCord = yCord;
                    Console.WriteLine($"You move a step forward in the maze ({explorer.CurrentXCord}:{explorer.CurrentYCord})");
                    return true;
                case MazeItemType.Wall:
                    Console.WriteLine("You can't walk through walls!");
                    return false;
                case MazeItemType.Finish:
                    explorer.ActionHistory.Add(ExplorerAction.MoveForward);
                    Console.WriteLine("You made it to the finish!");
                    return true;
            }

            return false;
        }
    }
}
