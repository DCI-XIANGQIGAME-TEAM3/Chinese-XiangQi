using System;

namespace Model
{
    public class Chess
    {
        public enum Player    //different type of player
        {
            red,
            black,
            blank
        };


        public enum Piecetype    //different type of chess
        {
            blank,        //the blank grid of the chess Board
            jiang,
            che,
            ma,
            pao,
            xiang,
            bing,
            shi
        };


        public enum Piecepath     //Whether can be move or not
        {
            yes,
            not
        };


        public Player side;
        public Piecetype type;
        public Piecepath path;

        public virtual bool ChessMovingRule(int CurrentX, int CurrentY, int OriginalX, int OriginalY, Chess[,] Matrix)
        {
            return false;
        }

        public virtual string ToString(Chess[,] Matrix, int i, int j, string str)
        {
            return "";
        }
    }

}
