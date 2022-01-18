using System;
using Control;

namespace Model
{
    class Rook : Chess
    {
        public override bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            ProgramControl con = new ProgramControl();
            int i, j, k;
            //如果是Y坐标发生改变
            switch (OriginalX == CurrentX)
            {
                case true:
                    if (OriginalY < CurrentY)
                    {
                        //如果原来的y小于移动后的y i就等于原来的y
                        i = OriginalY;
                        j = CurrentY;
                    }
                    else
                    {
                        //如果原来的y大于移动后的y j就等于原来的y
                        i = CurrentY;
                        j = OriginalY;
                        // 右移（原来的y小于现在的）i原来的y，j现在的y
                    }
                    //原来的和现在的y坐标之间不能有棋子 
                    for (k = i + 1; k < j; k++)
                    {
                        if (Matrix[CurrentX, k].side != Chess.Player.blank)
                        {
                            return false;
                        }
                    }
                    break;
                case false:
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
                        if (Matrix[k, CurrentY].side != Chess.Player.blank)
                        {
                            return false;
                        }
                    }
                    break;
            }


            //不能吃掉自己的棋子
            if (Matrix[OriginalX, OriginalY].side == Matrix[CurrentX, CurrentY].side)
            {
                return false;
            }
            //不能X坐标和Y坐标同时发生改变
            if (OriginalX != CurrentX && OriginalY != CurrentY)
            {
                return false;
            }

            con.SetMove(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);

            return true;
        }

        public override string ToString(Chess[,] Matrix, int i, int j, string str)
        {

            switch (Matrix[i, j].side)
            {
                case Player.black:
                    str = "车";
                    return str;
                case Player.red:
                    str = "車";
                    return str;
                default:
                    return " ";
            }

        }
    }
}