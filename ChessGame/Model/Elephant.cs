using System;
using Control;

namespace Model
{
    class Elephant : Chess
    {
        public override bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            ProgramControl con = new ProgramControl();
            int centerX = (CurrentX + OriginalX) / 2;
            int centerY = (CurrentY + OriginalY) / 2;
            //确保路线是田字路线
            if (Math.Abs(CurrentX - OriginalX) != 4 || Math.Abs(CurrentY - OriginalY) != 4)
            {
                return false;
            }
            //田字格的中心不能有棋子
            if (Matrix[centerX, centerY].side != Chess.Player.blank)
            {
                return false;
            }


            // 不能吃掉自己方的棋子
            if (Matrix[OriginalX, OriginalY].side == Matrix[CurrentX, CurrentY].side)
            {
                return false;
            }

            switch (Matrix[OriginalX, OriginalY].side)
            {

                case Chess.Player.red:
                    //相不能过河
                    if (CurrentX < 10)
                    {
                        return false;
                    }

                    break;

                case Chess.Player.black:

                    if (CurrentX > 8)
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
                    str = "相";
                    return str;
                case Player.red:
                    str = "象";
                    return str;
                default:
                    return " ";
            }

        }
    }
}