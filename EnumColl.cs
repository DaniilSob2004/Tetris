using System;


namespace Tetris
{
    public static class EnumColl
    {
        public enum Direction
        {
            Down,
            Left,
            Right
        }

        public enum Field
        {
            Empty,
            Element,
            Wall
        }

        public enum TypeFigure
        {
            Line1,
            Line2,
            Square,
            L1,
            L2,
            L3,
            L4,
            InvertedL1,
            InvertedL2,
            InvertedL3,
            InvertedL4,
            Z1,
            Z2,
            InvertedZ1,
            InvertedZ2,
            T1,
            T2,
            T3,
            T4
        }
    }
}
