namespace Maze.Domain
{
    public enum MazeItemType { Start, Finish, Space, Wall }

    public enum ExplorerDirection { North, East, South, West }
    public enum ExplorerAction
    {
        MoveForward,
        TurnLeft,
        TurnRight,
        LookForward,
        LookAround
    }
}