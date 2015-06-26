using Maze.Domain;

namespace Maze.Explorer.ActionStrategy
{
    public interface IExplorerActionStrategy
    {
        bool DoAction(MazeExplorer explorer);
    }
}
