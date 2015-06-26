using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Maze.Domain;
using NUnit.Framework;

namespace Maze.Tests
{
    [TestFixture]
    public class MazeServiceTests
    {
        private string _filePath;
        private MazeService _mazeService;

        [SetUp]
        public void Setup()
        {
            _mazeService = new MazeService();

            string dir = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            _filePath = Path.Combine(dir, "ExampleMaze.txt");
        }

        [Test]
        public void CanReadMapFile()
        {
            var value = _mazeService.ReadMapFile(_filePath);

            Assert.Greater(value.Count(), 0);
        }

        [Test]
        public void GetMazeItem()
        {
            MazeStructure maze = new MazeStructure
            {
                Items = new List<MazeItem>
                {
                    new MazeItem(1,1,"s")
                }
            };
            
            var item =_mazeService.GetMazeItem(maze, 1, 1);

            Assert.AreEqual(MazeItemType.Start, item.Type);
        }
    }
}
