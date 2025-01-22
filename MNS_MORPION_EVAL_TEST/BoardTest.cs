using MNS_MORPION_EVAL;

namespace MNS_MORPION_EVAL_TEST;

    [TestClass]
    public class BoardTest
    {
        private Board _board;

        [TestInitialize]
        public void Setup()
        {
            _board = new Board();
        }

        //[TestMethod]
        //public void NewBoard_ShouldBeEmpty()
        //{
        //    for (int i = 0; i < 3; i++)
        //    for (int j = 0; j < 3; j++)
        //        Assert.AreEqual(Player.None, _board.GetCell(i, j));
        //}
        // pas de code dans un test
        
        [TestMethod]
        public void NewBoard_TopLeftCell_ShouldBeEmpty()
        {
            Assert.AreEqual(Player.None, _board.GetCell(0, 0));
        }

        [TestMethod]
        public void NewBoard_CenterCell_ShouldBeEmpty()
        {
            Assert.AreEqual(Player.None, _board.GetCell(1, 1));
        }

        [TestMethod]
        public void NewBoard_BottomRightCell_ShouldBeEmpty()
        {
            Assert.AreEqual(Player.None, _board.GetCell(2, 2));
        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(0, 2)]
        [DataRow(1, 0)]
        [DataRow(1, 1)]
        [DataRow(1, 2)]
        [DataRow(2, 0)]
        [DataRow(2, 1)]
        [DataRow(2, 2)]
        public void NewBoard_AllCells_ShouldBeEmpty(int row, int col)
        {
            Assert.AreEqual(Player.None, _board.GetCell(row, col));
        }

        [TestMethod]
        public void IsValidMove_EmptyCell_ShouldReturnTrue()
        {
            Assert.IsTrue(_board.IsValidMove(0, 0));
        }

        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(3, 0)]
        [DataRow(0, 3)]
        public void IsValidMove_OutOfBounds_ShouldReturnFalse(int row, int col)
        {
            Assert.IsFalse(_board.IsValidMove(row, col));
        }
    }