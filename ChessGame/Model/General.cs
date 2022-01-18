using System;
using Control;
namespace Model
{
    class General : Chess
    {
        public override bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            ProgramControl con = new ProgramControl();
            int i, j, k;
            //飞将军
            if (Matrix[CurrentX, CurrentY].type == Chess.Piecetype.jiang && OriginalY == CurrentY)
            {
                if (OriginalX < CurrentX)
                {
                    i = OriginalX;
                    j = CurrentX;
                }
                else
                {
                    i = CurrentX;
                    j = OriginalX;
                }

                for (k = i + 1; k < j; k++)
                {
                    //两个将军之间有棋子时不能飞将
                    if (Matrix[k, CurrentY].side != Chess.Player.blank)
                    {
                        return false;
                    }
                }

                //为了在飞将时避免被下面的条件限制
                con.SetMove(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);

                return true;
            }


            switch (OriginalX == CurrentX)
            {
                //水平移动时
                case true:
                    if (Math.Abs(OriginalY - CurrentY) != 2)
                    {
                        return false;
                    }
                    break;
                //垂直移动时
                case false:
                    if (Math.Abs(OriginalX - CurrentX) != 2)
                    {
                        return false;
                    }
                    break;
            }

            //  不能吃自己的棋子
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
                    str = "将";
                    return str;
                case Player.red:
                    str = "帅";
                    return str;
                default:
                    return " ";
            }

        }
    }
}