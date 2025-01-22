namespace MNS_MORPION_EVAL;

public enum GameStatus
{
    InProgress,
    XWins,
    OWins,
    Draw
}

public class Game
{
    public Board Board { get; private set; }
    public Player CurrentPlayer { get; private set; }
    public GameStatus Status { get; private set; }

    public Game()
    {
        Board = new Board();
        CurrentPlayer = Player.X;
        Status = GameStatus.InProgress;
    }

    public bool MakeMove(int row, int col)
    {
        if (Status != GameStatus.InProgress)
            return false;

        try
        {
            Board.PlaceSymbol(row, col, CurrentPlayer);
        }
        catch (InvalidMoveException)
        {
            return false;
        }

        if (Board.CheckWin(CurrentPlayer))
        {
            Status = CurrentPlayer == Player.X ? GameStatus.XWins : GameStatus.OWins;
            return true;
        }

        if (Board.IsFull())
        {
            Status = GameStatus.Draw;
            return true;
        }

        CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        return true;
    }
}
