using MNS_MORPION_EVAL;

namespace MNS_MORPION_EVAL_TEST;

[TestClass]
public class GameTest
{
    private Game _game;

    [TestInitialize]
    public void Setup()
    {
        _game = new Game();
    }

    [TestMethod]
    public void NewGame_ShouldStartWithPlayerX()
    {
        Assert.AreEqual(Player.X, _game.CurrentPlayer);
    }

    [TestMethod]
    public void NewGame_StatusShouldBeInProgress()
    {
        Assert.AreEqual(GameStatus.InProgress, _game.Status);
    }

    [TestMethod]
    public void MakeMove_ValidMove_ShouldReturnTrue()
    {
        bool result = _game.MakeMove(0, 0);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void MakeMove_InvalidMove_ShouldReturnFalse()
    {
        _game.MakeMove(0, 0);
        bool result = _game.MakeMove(0, 0);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void MakeMove_ShouldSwitchPlayers()
    {
        _game.MakeMove(0, 0);
        Assert.AreEqual(Player.O, _game.CurrentPlayer);
    }

    [TestMethod]
    public void Game_HorizontalWin_ShouldEndGame()
    {
        // X joue
        _game.MakeMove(0, 0);
        // O joue
        _game.MakeMove(1, 0);
        // X joue
        _game.MakeMove(0, 1);
        // O joue
        _game.MakeMove(1, 1);
        // X joue et gagne
        _game.MakeMove(0, 2);

        Assert.AreEqual(GameStatus.XWins, _game.Status);
    }

    [TestMethod]
    public void Game_Draw_ShouldEndInDraw()
    {
        // Remplir la grille sans gagnant
        _game.MakeMove(0, 0); // X
        _game.MakeMove(0, 1); // O
        _game.MakeMove(0, 2); // X
        _game.MakeMove(1, 1); // O
        _game.MakeMove(1, 0); // X
        _game.MakeMove(2, 0); // O
        _game.MakeMove(1, 2); // X
        _game.MakeMove(2, 2); // O
        _game.MakeMove(2, 1); // X

        Assert.AreEqual(GameStatus.Draw, _game.Status);
    }

}