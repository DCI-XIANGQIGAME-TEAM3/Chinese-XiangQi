
using Control;

namespace Model
{
    //public class ProMod:Chess 没必要？
    public class ProgramModel
    {

        public Chess[,] SetPosition()   //设置棋子位置，初始化棋子的位置
        {
            Chess[,] Matrix = new Chess[19, 17];

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    Matrix[i, j] = new Chess();
                    Matrix[i, j].side = Chess.Player.blank;
                    Matrix[i, j].type = Chess.Piecetype.blank;
                }
            }


            for (int j = 0; j < 17; j++)
            {
                if (j % 2 == 0)
                {
                    Matrix[0, j].side = Chess.Player.black;
                    Matrix[18, j].side = Chess.Player.red;
                }

                if (j == 2 || j == 14)
                {
                    Matrix[4, j].side = Chess.Player.black;
                    Matrix[14, j].side = Chess.Player.red;
                }
                else if (j % 4 == 0)
                {
                    Matrix[6, j].side = Chess.Player.black;
                    Matrix[12, j].side = Chess.Player.red;
                }
            }

            for (int i = 0; i < 19; i++)
            {
                if (i == 0 || i == 18)
                {
                    Matrix[i, 0].type = Chess.Piecetype.che;
                    Matrix[i, 2].type = Chess.Piecetype.ma;
                    Matrix[i, 4].type = Chess.Piecetype.xiang;
                    Matrix[i, 6].type = Chess.Piecetype.shi;
                    Matrix[i, 8].type = Chess.Piecetype.jiang;
                    Matrix[i, 10].type = Chess.Piecetype.shi;
                    Matrix[i, 12].type = Chess.Piecetype.xiang;
                    Matrix[i, 14].type = Chess.Piecetype.ma;
                    Matrix[i, 16].type = Chess.Piecetype.che;
                }
                else if (i == 4 || i == 14)
                {
                    Matrix[i, 2].type = Chess.Piecetype.pao;
                    Matrix[i, 14].type = Chess.Piecetype.pao;
                }
                else if (i == 6 || i == 12)
                {
                    for (int j = 0; j < 17; j++)
                    {
                        if (j % 4 == 0)
                        {
                            Matrix[i, j].type = Chess.Piecetype.bing;
                        }
                    }
                }
            }

            return Matrix;
        }


        public string[,] Piece(Chess[,] Matrix)          //把棋子一个个弄到棋盘上
        {
            Rook rook = new Rook();
            Soldier soldier = new Soldier();
            Horse horse = new Horse();
            General general = new General();
            Elephant elephant = new Elephant();
            Cannon canno = new Cannon();
            Advisor adviosr = new Advisor();

            string[,] result = ChessBoard.DrawingBoard();
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    string str = result[i, j];
                    switch (Matrix[i, j].type)
                    {
                        case Chess.Piecetype.che:
                            result[i, j] = rook.ToString(Matrix, i, j, str);
                            break;
                        case Chess.Piecetype.ma:
                            result[i, j] = horse.ToString(Matrix, i, j, str);
                            break;
                        case Chess.Piecetype.xiang:
                            result[i, j] = elephant.ToString(Matrix, i, j, str);
                            break;
                        case Chess.Piecetype.shi:
                            result[i, j] = adviosr.ToString(Matrix, i, j, str);
                            break;
                        case Chess.Piecetype.jiang:
                            result[i, j] = general.ToString(Matrix, i, j, str);
                            break;
                        case Chess.Piecetype.pao:
                            result[i, j] = canno.ToString(Matrix, i, j, str);
                            break;
                        case Chess.Piecetype.bing:
                            result[i, j] = soldier.ToString(Matrix, i, j, str);
                            break;
                    }
                }
            }
            return result;
        }
        public Chess[,] SetRoad()          //初始化并设置棋子路径
        {
            Chess[,] road = new Chess[19, 17];

            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    road[i, j] = new Chess();
                    //初设路径为不可移动，需判断可移动后在赋值为true
                    road[i, j].path = Chess.Piecepath.not;
                }
            }

            return road;
        }
    }
}