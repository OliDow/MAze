using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using Maze.Domain;
using Maze.Explorer.ActionStrategy;

namespace Maze.Explorer
{
    public class ExplorerService
    {
        #region Constructor
        public ExplorerService()
        {

        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        public bool DoAction(MazeExplorer explorer, ExplorerAction action)
        {
            IExplorerActionStrategy strategy = null;
            switch (action)
            {
                case ExplorerAction.TurnLeft:
                    strategy = new TurnLeftStrategy();
                    break;
                case ExplorerAction.TurnRight:
                    strategy = new TurnRightStrategy();
                    break;
                case ExplorerAction.MoveForward:
                    strategy = new MoveForwardStrategy();
                    break;
                case ExplorerAction.LookForward:
                    strategy = new LookForwardStrategy();
                    break;
                case ExplorerAction.LookAround:
                    strategy = new LookAroundStrategy();
                    break;
            }

            if (strategy != null)
                return strategy.DoAction(explorer);

            return false;
        }


        public void AutoComplete(MazeExplorer explorer)
        {
            Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe(r =>
            {

                DoAction(explorer, ExplorerAction.TurnRight);
                if (DoAction(explorer, ExplorerAction.LookForward))
                {
                    Console.WriteLine("true");
                    DoAction(explorer, ExplorerAction.MoveForward);
                }
                else
                {
                    DoAction(explorer, ExplorerAction.TurnLeft);
                    if (!DoAction(explorer, ExplorerAction.MoveForward))
                    {
                        DoAction(explorer, ExplorerAction.TurnLeft);
                    }
                }
                DoAction(explorer, ExplorerAction.LookAround);
            });

        }
        #endregion
    }
}
