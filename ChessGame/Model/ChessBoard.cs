using System;

namespace Model
{
    public class ChessBoard
    {
        public static string[,] DrawingBoard()
        {
            string[,] Board = new string[19, 17];
            Console.Clear();

            for (int i = 1; i < 18; i++)
            {
                if (i % 2 == 0)
                {
                    Board[i, 0] = "┣-";
                    Board[i, 16] = "┫ ";
                }
                else
                {
                    Board[i, 0] = "┃ ";
                    Board[i, 16] = "┃ ";
                }
            }


            for (int j = 1; j < 16; j++)
            {
                Board[0, j] = "—";
                Board[10, j] = "--";
                Board[8, j] = "--";
                Board[18, j] = "—";
            }

            for (int k = 1; k < 16; k++)
            {
                for (int l = 1; l <= 17; l++)
                {

                    if (l == 9)
                    {
                        Board[l, k] = "  ";
                    }
                    if (l != 9 && l != 10 && l != 8)
                    {
                        switch (l % 2)
                        {
                            case 1:
                                Board[l, k] = "┃ ";
                                break;
                            case 0:
                                Board[l, k] = "╋-";
                                break;
                        }
                    }

                }

                if (k % 2 != 0)
                {
                    for (int l = 1; l <= 17; l++)
                    {
                        if (l != 8 && l != 10)
                        {
                            Board[l, k] = "  ";
                        }
                    }
                }
            }

            //the nice palace of the king
            Board[1, 8] = "╲┃╱";
            Board[3, 8] = "╱┃╲";
            Board[15, 8] = "╲┃╱";
            Board[17, 8] = "╱┃╲";

            Board[1, 6] = "┃";
            Board[3, 6] = "┃";
            Board[15, 6] = "┃";
            Board[17, 6] = "┃";

            //the river of the chess Model
            Board[9, 5] = "楚";
            Board[9, 6] = "河";
            Board[9, 10] = "汉";
            Board[9, 11] = "界";

            //the corner of the chess Model
            Board[0, 0] = "┏";
            Board[18, 0] = "┗";
            Board[0, 16] = "┓";
            Board[18, 16] = "┛";
            return Board;

        }
    }
}