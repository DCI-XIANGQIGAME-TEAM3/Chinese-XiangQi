using System;
using Model;
namespace View
{
    class UserInterface
    {
        public void Start(int start)            //print the start statement
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("      Welcome to our XiangQi Game!     ");
            if (start % 2 == 0)
            {
                Console.WriteLine("          It's RED turn now!         ");
                Console.WriteLine("     Select your piece（X&Y) to move!    ");
            }
            else
            {
                Console.WriteLine("          It's BLACK turn now!         ");
                Console.WriteLine("     Select your piece (X&Y) to move!      ");
            }
        }


        public int Move(bool turn, int player, int OriginalX, int OriginalY, int CurrentX, int CurrentY)          //print the statement of movement
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (turn == false)
            {
                Console.Write(" This is the wrong path, please set it again! ");
            }
            else
            {
                Console.Write(" Your piece move from (" + OriginalX + "," + OriginalY + ") to (" + CurrentX + "," + CurrentY + ") successfully!");
                player++;
            }
            Console.ReadLine();
            return player;
        }


        public void Check(int checkpiece, string[,] Board, int OriginalX, int OriginalY)        //tell the user the condition of the movement of the piece
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.BackgroundColor = ConsoleColor.Black;

            if (checkpiece == 2)
            {
                Console.WriteLine("   You now select the piece: " + Board[OriginalX * 2, OriginalY * 2] + "(" + OriginalX + "," + OriginalY + ").");
                Console.WriteLine(" Please set your position of moving(X & Y):");
            }
            //选择了空棋子
            else if (checkpiece == 0)
            {
                Console.WriteLine("   Sorry, there is no piece. Please try again.            ");
            }
            //1选错棋子（选择了对方的棋子）
            else
            {
                Console.WriteLine("   You cannot choose this position.          ");
            }
            Console.ReadLine();
        }


        public void Wrong()             //print the statement if the user choose the wrong piece
        {
            Console.Write("  You cannot select this  position! Please select again! ");
            Console.ReadLine();
        }


        public void Win(int player)     //print the statement of WIN in the base
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            if ((player + 1) % 2 == (int)Chess.Player.red)
            {
                Console.Write("           The  RED SIDE IS WIN!!!                  ");
            }
            else
            {
                Console.Write("           The  BLACK SIDE IS WIN!!!                ");
            }
            Console.ReadKey(true);
        }


        //Matrix含有棋盘和棋子的整个图像，此时还未包含坐标轴
        public void Displaying(Chess[,] Matrix, Chess[,] road)              //打印棋盘坐标
        {
            ProgramModel Mod = new ProgramModel();
            string[,] Board = Mod.Piece(Matrix);
            //the first row of the chess  board
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" X\\Y ");
            //j row 
            //display the index of x
            for (int j = 0; j <= 17; j++)
            {
                if (j == 0)
                {
                    Console.Write(j + "   ");
                }
                else if (j == 16)
                {
                    Console.Write(j / 2 + "      ");
                }
                else if (j % 2 == 0 && j > 0)
                {
                    Console.Write(j / 2 + "   ");
                }
            }

            Console.Write("\n");
            //the y index
            for (int i = 0; i <= 18; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                if (i % 2 == 0)
                {
                    Console.Write("  " + i / 2 + "  ");
                }
                else
                {
                    Console.Write("     ");
                }

                for (int j = 0; j < 17; j++)
                {
                    if (Matrix[i, j].side == Chess.Player.black)
                    {
                        if (road[i, j].path == Chess.Piecepath.yes)
                        {
                            FeasiblePath(Board, i, j);
                            road[i, j].path = Chess.Piecepath.not;
                        }
                        else
                        {
                            InfeasiblePath(Matrix, Board, i, j);
                        }
                    }
                    else if (Matrix[i, j].side == Chess.Player.red)
                    {
                        if (road[i, j].path == Chess.Piecepath.yes)
                        {
                            FeasiblePath(Board, i, j);
                            road[i, j].path = Chess.Piecepath.not;
                        }
                        else
                        {
                            InfeasiblePath(Matrix, Board, i, j);
                        }
                    }
                    else
                    {
                        if (road[i, j].path == Chess.Piecepath.yes)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                            Console.Write(Board[i, j]);
                            Console.BackgroundColor = ConsoleColor.Gray;
                            road[i, j].path = Chess.Piecepath.not;
                        }
                        else
                        {
                            Console.Write(Board[i, j]);
                        }
                    }
                }

                if (i % 2 == 0)
                {
                    Console.Write("     ");
                }
                else
                {
                    Console.Write("     ");
                }
                Console.Write("\n");
            }

        }


        public void InfeasiblePath(Chess[,] Matrix, string[,] Board, int i, int j)         //不可行的路径颜色，黄
        {
            Console.BackgroundColor = ConsoleColor.Gray;

            if (Matrix[i, j].side == Chess.Player.red)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (Matrix[i, j].side == Chess.Player.black)
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }
            //被覆盖的把不可行路径的棋子补回去
            Console.Write(Board[i, j]);
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }


        public void FeasiblePath(string[,] Board, int i, int j)                   //可行的路径颜色，蓝
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;
            //把被覆盖的可行路径上的棋子补回去
            Console.Write(Board[i, j]);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Gray;
        }
    }
}
