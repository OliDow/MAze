using System.Collections.Generic;
using System.Security.Permissions;
using Maze.Domain;
using Maze.Explorer;
using NUnit.Framework;

namespace Maze.Tests
{
    [TestFixture]
    public class ExplorerTests
    {
        #region Properties
        private MazeStructure _maze;
        private ExplorerService _explorerService;
        private MazeExplorer _explore;
        #endregion

        [SetUp]
        public void SetUp()
        {
            _explorerService = new ExplorerService();
            _maze = new MazeStructure
            {
                Items = new List<MazeItem>
                {
                    new MazeItem(1,1,"s"),
                    new MazeItem(2,1," "),
                    new MazeItem(3,1,"x")
                }
            };
             _explore = new MazeExplorer(_maze);

        }

        [Test]
        public void ExplorerSetup()
        {
            Assert.AreEqual(1, _explore.CurrentXCord);
            Assert.AreEqual(1, _explore.CurrentYCord);
        }

        [Test]
        public void ExplorerTurnLeft()
        {

            _explorerService.DoAction(_explore, ExplorerAction.TurnLeft);

            Assert.AreEqual(ExplorerDirection.West, _explore.CurrentDirection);
        }
        [Test]
        public void ExplorerTurnRight()
        {

            _explorerService.DoAction(_explore, ExplorerAction.TurnRight);

            Assert.AreEqual(ExplorerDirection.East, _explore.CurrentDirection);
        }

        [Test]
        public void ExplorerMoveForwad()
        {
            _explore.CurrentDirection = ExplorerDirection.East;
            _explorerService.DoAction(_explore, ExplorerAction.MoveForward);

            Assert.AreEqual(2, _explore.CurrentXCord);
        }

        [Test]
        public void ExplorerLookForwardSpace()
        {
            _explore.CurrentDirection = ExplorerDirection.East;
            var sucess = _explorerService.DoAction(_explore, ExplorerAction.LookForward);

            Assert.AreEqual(true, sucess);
        }

        [Test]
        public void ExplorerLookForwardFail()
        {
            _explore.CurrentDirection = ExplorerDirection.East;
            _explore.CurrentXCord = 2;
            var sucess = _explorerService.DoAction(_explore, ExplorerAction.LookForward);

            Assert.AreEqual(false, sucess);
        }
    
    }
}
