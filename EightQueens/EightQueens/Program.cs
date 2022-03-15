
int counter = 0;

int queens = 0;

do
{
    Console.Write("Queens: ");

    if (int.TryParse(Console.ReadLine(), out int q))
        queens = q;

} while (queens < 1);

CountPatterns(queens);

Console.WriteLine(counter);

bool IsOkToPlace(int[][] board, int x, int y)
{
    for (int col = 0; col < board.Length; col++)
    {
        if (board[x][col] == 1)
        { 
            return false;
        }
    }

    for (int row = x, col = y; row >= 0 && col >= 0; row--, col--)
    {
        if (board[row][col] == 1)
            return false;
    }
    
    for (int row = x, col = y; row < board.Length && col >= 0; row++, col--)
    {
        if (board[row][col] == 1)
            return false;
    }

    return true;
}

bool FindAPattern(int[][] board, int col)
{
    if (col == board.Length)
    {
        counter++;
        return true;
    }

    bool foundSolution = false;

    for (int row = 0; row < board.Length; row++)
    {
        if (IsOkToPlace(board, row, col))
        {
            board[row][col] = 1;

            foundSolution = foundSolution || FindAPattern(board, col + 1);

            board[row][col] = 0;
        }
    }

    return false;
}

void CountPatterns(int queens)
{ 
    int[][]board = new int[queens][];   
    for (int row = 0; row < queens; row++)
        board[row] = new int[queens];


    for (int row = 0; row < queens; row++)
    {
        board[row][0] = 1;

        FindAPattern(board, 1);

        board[row][0] = 0;
    }

}