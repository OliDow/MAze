namespace Maze.Domain
{
    public class MazeItem
    {
        public MazeItem(int xCord, int yCord, string type)
        {
            XCord = xCord;
            YCord = yCord;

            switch (type.ToLower())
            {
                case "s":
                    Type = MazeItemType.Start;
                    break;
                case "f":
                    Type = MazeItemType.Finish;
                    break;
                case "x":
                    Type = MazeItemType.Wall;
                    break;
                default:
                    Type = MazeItemType.Space;
                    break;
            }
        }

        public int XCord { get; set; }
        public int YCord { get; set; }
        public MazeItemType Type { get; set; }
    }
}
