using System;
using Maze;
using Maze.Domain;
using Maze.Explorer;

namespace Excelian.Maze
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate classes until we impliment some kind of DI.
            MazeService mazeService = new MazeService();
            MazeStructure maze = new MazeStructure
            {
                Items = mazeService.ReadMapFile("ExampleMaze.txt")
            };
            MazeExplorer explorer = new MazeExplorer(maze);

            ExplorerService explorerService = new ExplorerService(); 

            Console.WriteLine("Commands");
            Console.WriteLine("ViewMaze (vm)");
            Console.WriteLine("stat");
            Console.WriteLine("autocomplete (ac)");
            Console.WriteLine("turnleft (l)");
            Console.WriteLine("turnright (r)");
            Console.WriteLine("moveforward (mf)");
            Console.WriteLine("lookforward (lf)");
            Console.WriteLine("lookaround (la)");
            while (true)
            {
                string inputText = Console.ReadLine();
                string[] inputSplit = inputText.Split(' ');
                if (inputSplit.Length == 1)

                    switch (inputText.ToLower())
                    {
                        case "viewmaze":
                        case "vm":
                            mazeService.ViewMaze(maze);
                            break;
                        case "stats":
                            mazeService.Stats(maze);
                            break;
                        case "autocomplete":
                        case "ac":
                            explorerService.AutoComplete(explorer);
                            break;
                        case "turnleft":
                        case "l":
                            explorerService.DoAction(explorer, ExplorerAction.TurnLeft);
                            break;
                        case "turnright":
                        case "r":
                            explorerService.DoAction(explorer, ExplorerAction.TurnRight);
                            break;
                        case "moveforward":
                        case "f":
                            explorerService.DoAction(explorer, ExplorerAction.MoveForward);
                            break;
                        case "lookforward":
                        case "lf":
                            explorerService.DoAction(explorer, ExplorerAction.LookForward);
                            break;
                        case "lookaround":
                        case "la":
                            explorerService.DoAction(explorer, ExplorerAction.LookAround);
                            break;
                    }

                if (inputText.ToLower().StartsWith("viewitem"))
                {

                    if (inputSplit.Length != 3)
                    {
                        Console.WriteLine("Viewitem accepts 2 paramaters");
                    }
                    else
                    {
                        int xCord;
                        int yCord;
                        if (int.TryParse(inputSplit[1], out xCord) &&
                            int.TryParse(inputSplit[2], out yCord))
                        {
                            mazeService.ViewItem(maze, xCord, yCord);
                        }
                    }
                }
            }
        }
    }
}
