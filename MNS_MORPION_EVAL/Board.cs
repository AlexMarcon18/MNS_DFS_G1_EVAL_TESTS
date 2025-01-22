namespace MNS_MORPION_EVAL;


public enum Player
{
    None,
    X,
    O
}
public class Board
{
        private readonly Player[,] _grid;

        public Board()
        {
            _grid = new Player[3, 3];
        }

        public Player GetCell(int row, int col) => _grid[row, col];

        public bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3 && _grid[row, col] == Player.None;
        }

        public void PlaceSymbol(int row, int col, Player player)
        {
            if (!IsValidMove(row, col))
                throw new InvalidMoveException("Cette case n'est pas valide");
            _grid[row, col] = player;
        }

        public bool CheckWin(Player player)
        {
            // Vérification des lignes
            for (int row = 0; row < 3; row++)
            {
                if (_grid[row, 0] == player && _grid[row, 1] == player && _grid[row, 2] == player)
                    return true;
            }

            // Vérification des colonnes
            for (int col = 0; col < 3; col++)
            {
                if (_grid[0, col] == player && _grid[1, col] == player && _grid[2, col] == player)
                    return true;
            }

            // Vérification des diagonales
            if (_grid[0, 0] == player && _grid[1, 1] == player && _grid[2, 2] == player)
                return true;

            if (_grid[0, 2] == player && _grid[1, 1] == player && _grid[2, 0] == player)
                return true;

            return false;
        }

        public bool IsFull()
        {
            for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (_grid[i, j] == Player.None)
                    return false;
            return true;
        }
    }

    public class InvalidMoveException : Exception
    {
        public InvalidMoveException(string message) : base(message) { }
    }
