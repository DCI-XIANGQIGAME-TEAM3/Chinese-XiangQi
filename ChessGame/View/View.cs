using System;
using Model;
using Control;
using View;
namespace ChessGame.View
{
    class View
    {
        static void Main(string[] args)
        {
            bool GameContinue = true;
            bool turn;
            //初始化棋子方为红
            int player = (int)Chess.Player.red;

            ProgramControl con = new ProgramControl();
            //实例化一个棋子模块
            ProgramModel mod = new ProgramModel();
            //ProgramView menu = new ProgramView();
            //初始化棋子位置 方法在pieces中 Matrix中包含棋盘上每个坐标的type，path，等属性
            Chess[,] Matrix = mod.SetPosition();
            UserInterface @interface = new UserInterface();
            Chess[,] road = mod.SetRoad();

            //结果为真，也就是场上仍存在两名将时
            while (GameContinue == true)
            {
                //board 包含棋盘上的每个图案 棋子文字等等（没有坐标轴）
                string[,] Board = mod.Piece(Matrix);//传入棋盘坐标 每个图案
                @interface.Displaying(Matrix, road);
                @interface.Start(player);

                try
                {
                    //ChozenX,Y为原来位置，X,Y为移动后的位置
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("                   X = ");
                    int OriginalX = Convert.ToInt32(Console.ReadLine());
                    //Console.WriteLine($"{chozenX}");
                    Console.Write("                   Y = ");
                    int OriginalY = Convert.ToInt32(Console.ReadLine());
                    int checkpiece = con.CheckPiece(OriginalX * 2, OriginalY * 2, Matrix);

                    if (checkpiece == 2)                //检测是否有棋子
                    {
                        road = con.Road(OriginalX * 2, OriginalY * 2, Matrix);
                        @interface.Displaying(Matrix, road);
                        road = mod.SetRoad();
                        @interface.Check(checkpiece, Board, OriginalX, OriginalY);
                        Console.Write("                   X = ");
                        int CurrentX = Convert.ToInt32(Console.ReadLine());
                        //Console.WriteLine($"{X}");
                        Console.Write("                   Y = ");
                        int CurrentY = Convert.ToInt32(Console.ReadLine());
                        turn = con.SwitchPlayer(CurrentX * 2, CurrentY * 2, OriginalX * 2, OriginalY * 2, Matrix);
                        player = @interface.Move(turn, player, OriginalX, OriginalY, CurrentX, CurrentY);
                        GameContinue = con.Result(Matrix);
                    }
                    else if (checkpiece == 0)
                    {
                        @interface.Check(checkpiece, Board, OriginalX, OriginalY);
                    }
                    else
                    {
                        @interface.Check(checkpiece, Board, OriginalX, OriginalY);
                    }
                }

                catch (Exception)       //检测异常
                {
                    @interface.Wrong();
                }
            }

            @interface.Displaying(Matrix, road);
            @interface.Win(player);
        }
    }
}
