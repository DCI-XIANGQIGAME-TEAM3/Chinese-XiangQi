using System;
using Model;


namespace Control
{
    public class ProgramControl
    {
        //第一周我们写的是0 现在我们换成了red
        //这里的0，1，2是调用了enum里的player，即red=0,black=1,blank=2
        int turn = (int)Chess.Player.red;        //回合数从0开始 ROUND 0

        //这里的turn是交换红黑方，红先黑后，可以认为是调用了递归(recursion),直到游戏结束
        // 确保不能用对方的棋子 也是棋子类的继承方法
        public bool SwitchPlayer(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {

            switch (turn)
            {
                case (int)Chess.Player.red:
                    if (Matrix[OriginalX, OriginalY].side != Chess.Player.red)
                    {
                        return false;
                    }
                    else
                    {
                        //红方回合
                        //每种棋子的移动方法
                        bool check = MovePiece(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                        if (check == true)
                        {
                            // 红方走完把回合权交给黑方
                            turn = (int)Chess.Player.black;
                            return true;
                        }
                        else
                            return false;
                    }
                case (int)Chess.Player.black:
                    if (Matrix[OriginalX, OriginalY].side != Chess.Player.black)
                    {
                        return false;
                    }
                    else
                    {
                        bool check = MovePiece(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                        if (check == true)
                        {
                            turn = (int)Chess.Player.red;
                            return true;
                        }
                        else
                            return false;
                    }
                case (int)Chess.Player.blank:
                    return false;
                default:
                    break;
            }
            return false;
        }


        public bool Result(Chess[,] Matrix)
        {
            int count = 0;
            bool result = true;
            //遍历上方田字格
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 6; j <= 10; j++)
                {
                    if (Matrix[i, j].type == Chess.Piecetype.jiang)
                        count++;
                }
            }
            //遍历下方田字格
            for (int i = 14; i <= 18; i++)
            {
                for (int j = 6; j <= 10; j++)
                {
                    if (Matrix[i, j].type == Chess.Piecetype.jiang)
                        count++;
                }
            }
            if (count == 2)
                return result;
            else
                return false;
        }


        public bool MovePiece(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)//定义每种棋子的移动方式,这里是调用pieceControl中的棋子
        {
            //实例化棋子
            Advisor advisor = new Advisor();
            Cannon cannon = new Cannon();
            Elephant elephant = new Elephant();
            General general = new General();
            Horse horse = new Horse();
            Rook rook = new Rook();
            Soldier soldier = new Soldier();

            bool Move;

            switch (Matrix[OriginalX, OriginalY].type)
            {
                case Chess.Piecetype.che:
                    Move = rook.ChessMovingRule(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                    return Move;
                case Chess.Piecetype.ma:
                    Move = horse.ChessMovingRule(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                    return Move;
                case Chess.Piecetype.xiang:
                    Move = elephant.ChessMovingRule(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                    return Move;
                case Chess.Piecetype.shi:
                    Move = advisor.ChessMovingRule(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                    return Move;
                case Chess.Piecetype.jiang:
                    Move = general.ChessMovingRule(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                    return Move;
                case Chess.Piecetype.pao:
                    Move = cannon.ChessMovingRule(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                    return Move;
                case Chess.Piecetype.bing:
                    Move = soldier.ChessMovingRule(CurrentX, CurrentY, OriginalX, OriginalY, Matrix);
                    return Move;
            }

            return false;
        }


        public Chess[,] Road(int chozenX, int chozenY, Chess[,] Matrix)      // 使棋子显示可行路径时，并使移动前的棋子不移动
        {
            ProgramModel mod = new ProgramModel();                  //实例化，方便使用该类里的方法
            Chess[,] road = mod.SetRoad();              //用Chess类创建出一个[19，17]的road数组，并一个个实例，再初始化路径，即将Chess.Piecepath.not赋到每个road里
            Chess[,] trans = new Chess[19, 17];         //用Chess类创建出一个[19，17]的trans数组，方便临时储存信息
            bool cr;

            for (int i = 0; i < 19; i++)                //遍历整个棋盘
            {
                for (int j = 0; j < 17; j++)
                {
                    trans[i, j] = new Chess();             //通过循环，一个个地具体实例化每个trans
                }
            }

            for (int i = 0; i < 19; i++)                //遍历整个棋盘
            {
                for (int j = 0; j < 17; j++)
                {
                    if (i % 2 == 0)                     //因为x实际的坐标是输入坐标的两倍，即都为偶数的x才是棋盘上的的点
                    {
                        trans[i, j].side = Matrix[i, j].side;           //把每个位置的side属性一个个赋到trans上暂时储存
                        trans[i, j].type = Matrix[i, j].type;              //把每个位置的type属性一个个赋到trans上暂时储存
                        trans[chozenX, chozenY].side = Matrix[chozenX, chozenY].side;      //把当前选择的具体位置的side属性赋到trans暂时储存
                        trans[chozenX, chozenY].type = Matrix[chozenX, chozenY].type;       //把当前选择的具体位置的type属性赋到trans暂时储存
                        cr = MovePiece(i, j, chozenX, chozenY, Matrix);                 //使用该方法依据棋子类型，通过遍历一个个检查当前选择的棋子能走的格子，通过返回true或false来形成路径，能否走动在棋子中已经定义说明

                        if (cr == true)     //如果该格子能走
                        {
                            road[i, j].path = Chess.Piecepath.yes;      //把该格子的位置的path属性里赋上Chess.Piecepath.yes,即把之前初始化的not变成了yes
                        }

                        Matrix[i, j].side = trans[i, j].side;           //每遍历了一个位置后及时把该位置的属性再赋回去，避免选择该棋子准备进行移动时棋子就已经提前移动影响整个函数的判断
                        Matrix[i, j].type = trans[i, j].type;
                        Matrix[chozenX, chozenY].side = trans[chozenX, chozenY].side;
                        Matrix[chozenX, chozenY].type = trans[chozenX, chozenY].type;
                    }
                }
            }

            return road;            //返回road即可行路径
        }

        //判断选中的是否是棋子
        //这里的0，1，2是调用了enum里的player，即red=0,black=1,blank=2
        public int CheckPiece(int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            if (Matrix[OriginalX, OriginalY].type == Chess.Piecetype.blank)
            {
                return 0;//no pieces
            }
            else if (turn == (int)Chess.Player.red)
            {
                if (Matrix[OriginalX, OriginalY].side != Chess.Player.red)
                {
                    return 1;//选择了对方的棋子
                }
                else
                {
                    return 2;//选择了己方的棋子 选择正确
                }
            }
            else if (turn == (int)Chess.Player.black)
            {
                if (Matrix[OriginalX, OriginalY].side != Chess.Player.black)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }

            return 0;
        }


        public void SetMove(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)       //基本移动方式
        {
            Matrix[CurrentX, CurrentY].side = Matrix[OriginalX, OriginalY].side;
            Matrix[CurrentX, CurrentY].type = Matrix[OriginalX, OriginalY].type;
            Matrix[OriginalX, OriginalY].side = Chess.Player.blank;
            Matrix[OriginalX, OriginalY].type = Chess.Piecetype.blank;
        }


    }

}