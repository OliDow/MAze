using System.Collections.Generic;
using System.Linq;

namespace Maze.Domain
{
    public class MazeExplorer
    {
        public MazeExplorer(MazeStructure currentMaze)
        {
            CurrentMaze = currentMaze;
            MazeItem start = currentMaze.Items.FirstOrDefault(i => i.Type == MazeItemType.Start);
            if (start != null)
            {
                CurrentXCord = start.XCord;
                CurrentYCord = start.YCord;
            }
        }

        public MazeStructure CurrentMaze { get; set; }
        public int CurrentXCord { get; set; }
        public int CurrentYCord { get; set; }
        public ExplorerDirection CurrentDirection { get; set; }

        public List<ExplorerAction> ActionHistory = new List<ExplorerAction>();
    }
}
