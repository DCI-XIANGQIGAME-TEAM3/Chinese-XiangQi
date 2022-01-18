using System;
using Control;

namespace Model
{
    class Cannon : Chess
    {
        public override bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            ProgramControl con = new ProgramControl();
            int i, j, k, num;
            //不能斜着走 X,Y坐标不能同时改变
            if (CurrentX != OriginalX && CurrentY != OriginalY)
            {
                return false;
            }

            switch (OriginalX == CurrentX)
            {
                //横着走,就是当原来X和原来X的坐标相同为真时 只有y改变
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
                    num = 0;
                    //n就是他原来位置和现在位置中间的棋子数量
                    for (k = i + 1; k < j; k++)
                    {
                        if (Matrix[CurrentX, k].side != Chess.Player.blank)
                        {
                            num++;
                        }
                    }

                    break;
                //原来的X坐标不等于现在的X坐标只有一种可能就是原来的Y等于现在的Y 也就是竖着移动
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

                    num = 0;

                    for (k = i + 1; k < j; k++)
                    {
                        if (Matrix[k, CurrentY].side != Chess.Player.blank)
                        {
                            num++;
                        }
                    }

                    break;
            }
            //如果中间的棋子数量大于一个的话 说明不能移动
            if (num > 1)
            {
                return false;
            }
            //CurrentX,CurrentY  为移动后的坐标 中间没有棋子且移动后的坐标不是空的
            if (num == 0 && Matrix[CurrentX, CurrentY].side != Chess.Player.blank)
            {
                return false;
            }
            //中间有一个棋子，且移动后的坐标是空的
            if (num == 1 && Matrix[CurrentX, CurrentY].side == Chess.Player.blank)
            {
                return false;
            }
            //不能吃掉自己方的棋子
            if (Matrix[OriginalX, OriginalY].side == Matrix[CurrentX, CurrentY].side)
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
                    str = "砲";
                    return str;
                case Player.red:
                    str = "炮";
                    return str;
                default:
                    return " ";
            }

        }
    }
}