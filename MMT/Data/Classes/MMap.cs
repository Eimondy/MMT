﻿namespace MMT.Data.Classes
{
    public class MMap
    {
        public byte Size;
        public BLOCKS[,] Content;
    }

    public class OriginalMap
    {
        public static readonly byte[] Sizes = 
            { 10, 10, 12, 12, 13, 13, 15, 15, 10, 12, 11, 10, 12, 11, 9, 8};
        public static readonly byte[][,] maps = new byte[16][,]
        {   //  10*10 1
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 11, 3},
                {3, 2, 2, 2, 2, 2, 3, 11, 1, 3},
                {3, 2, 2, 2, 2, 2, 3, 2, 11, 3},
                {3, 2, 3, 2, 3, 3, 3, 3, 2, 3},
                {3, 2, 3, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 3, 2, 2, 2, 2, 2, 3, 3},
                {3, 11, 3, 2, 3, 2, 11, 2, 2, 3},
                {3, 2, 2, 2, 3, 2, 2, 2, 51, 3},
                {3, 3, 3, 0, 3, 3, 3, 3, 3, 3}
            },
            // 10*10 2
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 0, 2, 2, 2, 2, 3},
                {3, 11, 3, 2, 2, 2, 3, 12, 2, 3},
                {3, 2, 3, 2, 2, 2, 3, 2, 2, 3},
                {3, 2, 3, 51, 2, 2, 3, 52, 2, 3},
                {3, 11, 3, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 3, 2, 2, 12, 3, 3, 12, 3},
                {3, 12, 3, 2, 2, 2, 3, 2, 2, 3},
                {3, 1, 3, 2, 2, 52, 3, 2, 101, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //12*12 3
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 61, 2, 3, 2, 2, 3, 2, 2, 2, 2, 3},
                {3, 2, 2, 151, 2, 2, 3, 2, 2, 12, 2, 3},
                {3, 3, 3, 3, 2, 2, 2, 2, 3, 3, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 3, 0, 2, 3},
                {3, 2, 2, 2, 2, 11, 2, 3, 3, 3, 3, 3},
                {3, 12, 2, 2, 52, 2, 2, 2, 2, 2, 53, 3},
                {3, 2, 3, 3, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 3, 1, 13, 2, 2, 3, 3, 3, 3, 3},
                {3, 2, 3, 3, 3, 2, 2, 3, 2, 2, 51, 3},
                {3, 102, 2, 12, 2, 2, 2, 11, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //12*12 4
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 11, 2, 2, 103, 3},
                {3, 2, 0, 2, 2, 2, 2, 2, 2, 12, 2, 3},
                {3, 3, 3, 3, 2, 2, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 12, 3, 3, 3, 3, 3, 13, 2, 2, 2, 3},
                {3, 51, 2, 3, 2, 2, 152, 2, 2, 2, 2, 3},
                {3, 2, 2, 3, 62, 2, 3, 2, 3, 13, 2, 3},
                {3, 2, 2, 3, 3, 3, 3, 2, 3, 2, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 11, 3, 53, 2, 3},
                {3, 2, 1, 2, 2, 52, 2, 2, 3, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //13*13 5
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 3, 2, 2, 63, 2, 2, 3},
                {3, 1, 2, 14, 2, 2, 153, 2, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 2, 2, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 3},
                {3, 2, 2, 2, 2, 2, 11, 2, 2, 2, 2, 2, 3},
                {3, 11, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 13, 3},
                {3, 13, 3, 12, 2, 2, 3, 2, 2, 2, 2, 2, 3},
                {3, 2, 3, 2, 2, 2, 3, 2, 2, 12, 2, 2, 3},
                {3, 104, 3, 2, 2, 54, 3, 2, 54, 2, 55, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //13*13 6
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 3, 55, 2, 3, 105, 3},
                {3, 2, 13, 2, 2, 2, 0, 3, 2, 2, 3, 2, 3},
                {3, 2, 2, 3, 3, 3, 3, 3, 3, 2, 2, 14, 3},
                {3, 2, 2, 3, 2, 1, 3, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 3, 2, 3, 3, 2, 2, 2, 2, 55, 3},
                {3, 2, 54, 3, 2, 14, 2, 2, 3, 3, 3, 3, 3},
                {3, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 3, 3, 3, 3, 3, 2, 15, 2, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 3, 155, 3, 3},
                {3, 2, 2, 2, 2, 13, 2, 2, 2, 3, 2, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 54, 2, 3, 2, 64, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //15*15 7
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 56, 2, 2, 2, 2, 2, 3, 1, 2, 2, 3, 2, 106, 3},
                {3, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, 3},
                {3, 2, 2, 13, 2, 2, 2, 3, 16, 2, 13, 3, 2, 2, 3},
                {3, 3, 3, 3, 2, 2, 2, 3, 2, 2, 2, 15, 2, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 3, 2, 2, 2, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 3, 0, 3, 2, 2, 2, 3, 2, 65, 3},
                {3, 2, 3, 3, 3, 3, 3, 3, 3, 2, 3, 3, 2, 2, 3},
                {3, 2, 14, 57, 3, 56, 2, 2, 2, 2, 2, 3, 156, 3, 3},
                {3, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 3, 2, 2, 12, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 12, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //15*15 8
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 3, 107, 2, 2, 2, 2, 12, 2, 2, 2, 0, 3},
                {3, 2, 2, 157, 2, 2, 2, 2, 2, 12, 2, 2, 2, 2, 3},
                {3, 2, 2, 3, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 15, 2, 3, 2, 2, 2, 2, 2, 2, 2, 3, 2, 54, 3},
                {3, 66, 2, 3, 2, 2, 2, 2, 2, 2, 2, 3, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 3, 2, 2, 3},
                {3, 55, 2, 2, 2, 2, 2, 2, 3, 2, 2, 3, 14, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 3, 2, 2, 2, 3, 2, 2, 2, 13, 53, 3},
                {3, 2, 2, 2, 3, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3},
                {3, 17, 2, 2, 3, 2, 2, 2, 13, 2, 2, 2, 2, 2, 3},
                {3, 1, 2, 2, 3, 2, 2, 2, 2, 2, 2, 2, 2, 54, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //10*10 9
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 56, 2, 2, 2, 2, 154, 2, 108, 3},
                {3, 2, 16, 2, 2, 2, 3, 2, 2, 3},
                {3, 52, 2, 2, 2, 2, 3, 2, 67, 3},
                {3, 3, 3, 3, 0, 2, 3, 3, 3, 3},
                {3, 52, 2, 2, 2, 2, 2, 2, 51, 3},
                {3, 2, 2, 3, 3, 3, 3, 2, 2, 3},
                {3, 2, 2, 3, 2, 17, 2, 2, 2, 3},
                {3, 56, 2, 3, 2, 1, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //12*12 10
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 1, 2, 2, 2, 2, 2, 3, 2, 68, 2, 3},
                {3, 109, 2, 18, 2, 2, 2, 3, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 2, 2, 3, 3, 3, 158, 3},
                {3, 56, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 14, 3, 2, 2, 2, 2, 2, 2, 3},
                {3, 55, 2, 2, 3, 2, 2, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 3, 2, 2, 3, 0, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 2, 3, 55, 2, 2, 3},
                {3, 56, 2, 13, 2, 2, 2, 3, 3, 3, 13, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //11*11 11
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 69, 2, 3, 2, 1, 53, 3, 2, 52, 3},
                {3, 2, 2, 3, 2, 19, 2, 3, 2, 2, 3},
                {3, 2, 2, 3, 2, 2, 2, 3, 2, 2, 3},
                {3, 161, 3, 3, 3, 2, 3, 3, 14, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 3, 3, 3, 3, 2, 3, 3, 3, 3},
                {3, 2, 2, 14, 2, 3, 2, 2, 15, 110, 3},
                {3, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3},
                {3, 51, 2, 2, 2, 0, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //10*10 12
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 55, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 57, 18, 2, 3, 3, 3, 3, 2, 3},
                {3, 2, 2, 2, 3, 0, 2, 2, 2, 3},
                {3, 2, 2, 1, 3, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 2, 3, 19, 111, 3},
                {3, 55, 2, 2, 159, 2, 3, 57, 2, 3},
                {3, 70, 2, 2, 3, 2, 3, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //12*12 13
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 1, 52, 2, 2, 2, 3, 2, 54, 2, 2, 3},
                {3, 54, 2, 20, 2, 2, 3, 2, 17, 52, 2, 3},
                {3, 2, 2, 2, 2, 2, 3, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 2, 3, 2, 3, 3, 3, 3},
                {3, 3, 3, 0, 2, 2, 2, 2, 15, 54, 2, 3},
                {3, 3, 3, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 2, 3, 3, 3},
                {3, 2, 112, 2, 3, 51, 2, 2, 2, 2, 2, 3},
                {3, 71, 2, 2, 164, 15, 2, 2, 2, 2, 2, 3},
                {3, 2, 2, 2, 3, 2, 2, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //11*11 14
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 113, 2, 2, 3, 3, 2, 56, 54, 2, 3},
                {3, 2, 16, 2, 3, 3, 2, 16, 2, 2, 3},
                {3, 57, 2, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 0, 3, 3, 3, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 3},
                {3, 2, 2, 2, 2, 2, 2, 3, 3, 2, 3},
                {3, 2, 2, 56, 2, 21, 2, 2, 2, 2, 3},
                {3, 2, 2, 3, 3, 163, 3, 3, 2, 2, 3},
                {3, 1, 2, 3, 2, 72, 2, 3, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //9*9 15
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3, 3},
                {3, 2, 2, 2, 2, 2, 2, 2, 3},
                {3, 2, 114, 20, 3, 21, 57, 2, 3},
                {3, 2, 2, 52, 3, 51, 2, 2, 3},
                {3, 2, 2, 1, 3, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 2, 3},
                {3, 73, 51, 3, 0, 2, 2, 2, 3},
                {3, 2, 2, 162, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 3, 3, 3}
            },
            //8*8 16
            new byte[,]
            {
                {3, 3, 3, 3, 3, 3, 3, 3},
                {3, 4, 2, 2, 2, 2, 2, 3},
                {3, 3, 3, 3, 3, 3, 2, 3},
                {3, 2, 2, 22, 2, 2, 2, 3},
                {3, 2, 3, 2, 2, 3, 160, 3},
                {3, 2, 3, 2, 2, 3, 2, 3},
                {3, 0, 3, 2, 2, 3, 74, 3},
                {3, 3, 3, 3, 3, 3, 3, 3}
            }
        };
    }
}