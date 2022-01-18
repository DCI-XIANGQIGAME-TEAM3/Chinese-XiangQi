using System;
using Control;

namespace Model
{
    class Horse : Chess
    {
        public override bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            ProgramControl con = new ProgramControl();
            //横着走
            Boolean YMoving = Math.Abs(OriginalX - CurrentX) == 2 && Math.Abs(OriginalY - CurrentY) == 4;
            //竖着走
            Boolean XMoving = Math.Abs(OriginalX - CurrentX) == 4 && Math.Abs(OriginalY - CurrentY) == 2;

            switch (XMoving || YMoving)
            {
                case true:
                    if (XMoving)
                    {
                        if (Matrix[(OriginalX + CurrentX) / 2, OriginalY].side != Chess.Player.blank)
                        {
                            return false;
                        }
                    }
                    if (YMoving)
                    {
                        if (Matrix[OriginalX, (OriginalY + CurrentY) / 2].side != Chess.Player.blank)
                        {
                            return false;
                        }
                    }
                    break;
                case false:
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
            return "马";
        }
    }
}