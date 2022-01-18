using System;
using Control;

namespace Model
{
    class Soldier : Chess
    {
        public override bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            ProgramControl con = new ProgramControl();
            //不能吃掉自己的棋子，也就是两方的side不能一样                                   //小兵的X坐标和Y坐标不能同时发生改变 不能斜着走
            if (Matrix[OriginalX, OriginalY].side == Matrix[CurrentX, CurrentY].side || (CurrentX != OriginalX && CurrentY != OriginalY))
            {
                return false;
            }

            switch (Matrix[OriginalX, OriginalY].side)
            {

                case Chess.Player.red:

                    if (OriginalX > 8 && OriginalX - CurrentX != 2)
                    {
                        return false;
                    }
                    //
                    if (OriginalX < 10)
                    {
                        if (CurrentX == OriginalX && Math.Abs(CurrentY - OriginalY) != 2)
                        {
                            return false;
                        }

                        if (CurrentY == OriginalY && OriginalX - CurrentX != 2)
                        {
                            return false;
                        }
                    }

                    break;

                case Chess.Player.black:
                    //位置为黑方，也即选中的棋子是黑方小兵，棋盘上方

                    //chozen x<10 小兵不能往回走 一次不能往前走两个格 ==2说明走了一个格子
                    if (OriginalX < 10 && CurrentX - OriginalX != 2)
                    {
                        return false;
                    }

                    if (OriginalX > 8)
                    {
                        if (CurrentX == OriginalX && Math.Abs(CurrentY - OriginalY) != 2)
                        {
                            return false;
                        }

                        if (CurrentY == OriginalY && CurrentX - OriginalX != 2)
                        {
                            return false;
                        }
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
                    str = "卒";
                    return str;
                case Player.red:
                    str = "兵";
                    return str;
                default:
                    return " ";
            }
        }
    }
}