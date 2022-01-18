using System;
using Control;

namespace Model
{
    class Advisor : Chess
    {

        public override bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            ProgramControl con = new ProgramControl();
            //一次只能移动一格
            if (Math.Abs(CurrentX - OriginalX) != 2 || Math.Abs(OriginalY - CurrentY) != 2)
            {
                return false;
            }
            //不能吃自己的棋子
            if (Matrix[OriginalX, OriginalY].side == Matrix[CurrentX, CurrentY].side)
            {
                return false;
            }

            switch (Matrix[OriginalX, OriginalY].side)
            {

                case Chess.Player.red:

                    if (CurrentY < 6 || CurrentY > 10 || CurrentX < 14)
                    {
                        return false;
                    }

                    break;

                case Chess.Player.black:

                    if (CurrentY < 6 || CurrentY > 10 || CurrentX > 4)
                    {
                        return false;
                    }

                    break;
                default:
                    break;
            }

            con.SetMove(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);

            return true;
        }

        public override string ToString(Chess[,] Matrix, int i, int j, string str)
        {

            switch (Matrix[i, j].side)
            {
                case Player.black:
                    str = "士";
                    return str;
                case Player.red:
                    str = "仕";
                    return str;
                default:
                    return " ";
            }
        }
    }
}