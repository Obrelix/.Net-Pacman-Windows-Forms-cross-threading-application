using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanWinForms
{
    public static class PointLists
    {


        private static List<Point> boxList = new List<Point>();
        public static List<Point> boxPointList()
        {
            boxListInit();
            boxList = boxList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return boxList;
        }

        private static List<Point> BoxDoorList = new List<Point>();
        public static List<Point> boxDoorPointList()
        {
            boxDoorInit();
            BoxDoorList = BoxDoorList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return BoxDoorList;
        }



        private static void boxListInit()
        {
            boxList.Clear();
            boxList.Add(new Point(22, 26));
            boxList.Add(new Point(22, 27));
            boxList.Add(new Point(23, 26));
            boxList.Add(new Point(23, 27));
            boxList.Add(new Point(24, 26));
            boxList.Add(new Point(24, 27));
            boxList.Add(new Point(25, 26));
            boxList.Add(new Point(25, 27));
            boxList.Add(new Point(26, 26));
            boxList.Add(new Point(26, 27));
            boxList.Add(new Point(27, 26));
            boxList.Add(new Point(27, 27));
            boxList.Add(new Point(28, 26));
            boxList.Add(new Point(28, 27));
            boxList.Add(new Point(29, 26));
            boxList.Add(new Point(29, 27));
            boxList.Add(new Point(30, 26));
            boxList.Add(new Point(30, 27));
            boxList.Add(new Point(31, 26));
            boxList.Add(new Point(31, 27));
            boxList.Add(new Point(32, 26));
            boxList.Add(new Point(32, 27));
            boxList.Add(new Point(33, 26));
            boxList.Add(new Point(33, 27));
            boxList.Add(new Point(34, 26));
            boxList.Add(new Point(34, 27));
            boxList.Add(new Point(35, 26));
            boxList.Add(new Point(35, 27));
            boxList.Add(new Point(22, 28));
            boxList.Add(new Point(22, 29));
            boxList.Add(new Point(23, 28));
            boxList.Add(new Point(23, 29));
            boxList.Add(new Point(24, 28));
            boxList.Add(new Point(24, 29));
            boxList.Add(new Point(25, 28));
            boxList.Add(new Point(25, 29));
            boxList.Add(new Point(26, 28));
            boxList.Add(new Point(26, 29));
            boxList.Add(new Point(27, 28));
            boxList.Add(new Point(27, 29));
            boxList.Add(new Point(28, 28));
            boxList.Add(new Point(28, 29));
            boxList.Add(new Point(29, 28));
            boxList.Add(new Point(29, 29));
            boxList.Add(new Point(30, 28));
            boxList.Add(new Point(30, 29));
            boxList.Add(new Point(31, 28));
            boxList.Add(new Point(31, 29));
            boxList.Add(new Point(32, 28));
            boxList.Add(new Point(32, 29));
            boxList.Add(new Point(33, 28));
            boxList.Add(new Point(33, 29));
            boxList.Add(new Point(34, 28));
            boxList.Add(new Point(34, 29));
            boxList.Add(new Point(35, 28));
            boxList.Add(new Point(35, 29));
            boxList.Add(new Point(22, 30));
            boxList.Add(new Point(22, 31));
            boxList.Add(new Point(23, 30));
            boxList.Add(new Point(23, 31));
            boxList.Add(new Point(24, 30));
            boxList.Add(new Point(24, 31));
            boxList.Add(new Point(25, 30));
            boxList.Add(new Point(25, 31));
            boxList.Add(new Point(26, 30));
            boxList.Add(new Point(26, 31));
            boxList.Add(new Point(27, 30));
            boxList.Add(new Point(27, 31));
            boxList.Add(new Point(28, 30));
            boxList.Add(new Point(28, 31));
            boxList.Add(new Point(29, 30));
            boxList.Add(new Point(29, 31));
            boxList.Add(new Point(30, 30));
            boxList.Add(new Point(30, 31));
            boxList.Add(new Point(31, 30));
            boxList.Add(new Point(31, 31));
            boxList.Add(new Point(32, 30));
            boxList.Add(new Point(32, 31));
            boxList.Add(new Point(33, 30));
            boxList.Add(new Point(33, 31));
            boxList.Add(new Point(34, 30));
            boxList.Add(new Point(34, 31));
            boxList.Add(new Point(35, 30));
            boxList.Add(new Point(35, 31));
            boxList.Add(new Point(22, 32));
            boxList.Add(new Point(22, 33));
            boxList.Add(new Point(23, 32));
            boxList.Add(new Point(23, 33));
            boxList.Add(new Point(24, 32));
            boxList.Add(new Point(24, 33));
            boxList.Add(new Point(25, 32));
            boxList.Add(new Point(25, 33));
            boxList.Add(new Point(26, 32));
            boxList.Add(new Point(26, 33));
            boxList.Add(new Point(27, 32));
            boxList.Add(new Point(27, 33));
            boxList.Add(new Point(28, 32));
            boxList.Add(new Point(28, 33));
            boxList.Add(new Point(29, 32));
            boxList.Add(new Point(29, 33));
            boxList.Add(new Point(30, 32));
            boxList.Add(new Point(30, 33));
            boxList.Add(new Point(31, 32));
            boxList.Add(new Point(31, 33));
            boxList.Add(new Point(32, 32));
            boxList.Add(new Point(32, 33));
            boxList.Add(new Point(33, 32));
            boxList.Add(new Point(33, 33));
            boxList.Add(new Point(34, 32));
            boxList.Add(new Point(34, 33));
            boxList.Add(new Point(35, 32));
            boxList.Add(new Point(35, 33));
            for (int i = 0; i < boxList.Count; i++)
            {
                if (boxList[i].X == 0 || boxList[i].Y == 0)
                {
                    boxList.RemoveAt(i);
                }
                else
                {
                    boxList[i] = new Point(boxList[i].X - 1, boxList[i].Y - 1);
                }
            }
        }

        private static void boxDoorInit()
        {
            BoxDoorList.Clear();
            BoxDoorList.Add(new Point(26, 26));
            BoxDoorList.Add(new Point(27, 26));
            BoxDoorList.Add(new Point(28, 26));
            BoxDoorList.Add(new Point(29, 26));
            BoxDoorList.Add(new Point(30, 26));
            BoxDoorList.Add(new Point(31, 26));

            for (int i = 0; i < BoxDoorList.Count; i++)
            {
                if (BoxDoorList[i].X == 0 || BoxDoorList[i].Y == 0)
                {
                    BoxDoorList.RemoveAt(i);
                }
                else
                {
                    BoxDoorList[i] = new Point(BoxDoorList[i].X - 1, BoxDoorList[i].Y - 1);
                }
            }
        }



        public static void saveMap(int stage)
        {
            int[,] map = new int[56, 62];
            for (int i = 0; i < 56; i++)
            {
                for (int j = 0; j < 62; j++)
                {

                    map[i, j] = 1;
                }
            }
            foreach (Point p in mapList(stage, '0'))
                map[p.X, p.Y] = 0;
            foreach (Point p in mapList(stage, '1'))
                map[p.X, p.Y] = 1;
            foreach (Point p in mapList(stage, '2'))
                map[p.X, p.Y] = 2;
            foreach (Point p in mapList(stage, '8'))
                map[p.X, p.Y] = 8;
            string s = string.Empty;
            for (int j = 0; j < 62; j++)
            {
                for (int i = 0; i < 56; i++)
                {
                    s += map[i, j].ToString();
                }
                s += Environment.NewLine;
            }
            System.IO.File.WriteAllText(@"C:\map.txt", s);
        }
        private static string wallInit()
        {
            string s = @"00000000000000000000000000000000000000000000000000000000
01111111111111111111111111100111111111111111111111111110
01111111111111111111111111100111111111111111111111111110
01121212121212121212121212100112121212121212121212121210
01111111111111111111111111100111111111111111111111111110
01121000000112100000000112111112100000000112100000011210
01111011110111101111110111111111101111110111101111011110
01121011110112101111110112121212101111110112101111011210
01111000000111100000000111111111100000000111100000011110
01121111111112111111111112100112111111111112111111111210
01111111111111111111111111100111111111111111111111111110
01121218121212121212121212100112121212121212121218121210
01111111111111111111111111100111111111111111111111111110
01121000000112100112100000000000000112100112100000011210
01111000000111100111100000000000000111100111100000011110
01121111111112100112111111100111111112100112111111111210
01111111111111100111111111100111111111100111111111111110
01121212121212100112121212100112121212100112121212121210
01111111111111100111111111100111111111100111111111111110
00000112100112100000000112100112100000000112100112100000
00000111100111100000000111100111100000000111100111100000
01111112100112111111111112111112111111111112100112111110
01111111100111111111111111111111111111111111100111111110
01121212100112121212121212121212121212121212100112121210
01111111100111111111111111111111111111111111100111111110
01121000000112100112100001111110000112100112100000011210
01111000000111100111101111111111110111100111100000011110
01121111111112100112101111111111110112100112111111111210
01111111111111100111101111111111110111100111111111111110
01121212121212100112101111111111110112100112121212121210
01111111111111100111101111111111110111100111111111111110
01121000000112100112101111111111110112100112100000011210
01111000000111100111100000000000000111100111100000011110
01121111100112100112111111111111111112100112100111111210
01111111100111100111111111111111111111100111100111111110
01121212100112100112121212121212121212100112100112121210
01111111100111100111111111111111111111100111100111111110
00000112100112100112100000000000000112100112100112100000
00000111100111100111100000000000000111100111100111100000
01111112111112111112111111111111111112111112111112111110
01111111111111111111111111111111111111111111111111111110
01121212121212121212121212121112121212121212121212121210
01111111111111111111111111111111111111111111111111111110
01121000000112100000000112100112100000000112100000011210
01111000000111100000000111100111100000000111100000011110
01121111100112111111111112100112111111111112100111111210
01111111100111111111111111100111111111111111100111111110
01121218100112121212121212100112121212121212100118121210
01111111100111111111111111100111111111111111100111111110
00000112100112100112100000000000000112100112100112100000
00000111100111100111100000000000000111100111100111100000
01111112111112100112111111100111111112100112111112111110
01111111111111100111111111100111111111100111111111111110
01121212121212100112121212100112121212100112121212121210
01111111111111100111111111100111111111100111111111111110
01121000000112100000000112100112100000000112100000011210
01111000000111100000000111100111100000000111100000011110
01121111111112111111111112111112111111111112111111111210
01111111111111111111111111111111111111111111111111111110
01121212121212121212121212121212121212121212121212121210
01111111111111111111111111111111111111111111111111111110
00000000000000000000000000000000000000000000000000000000";
            return s;
        }

        private static string wall2Init()
        {
            string s = @"00000000000000000000000000000000000000000000000000000000
01111111111111111111111111100111111111111111111111111110
01111111111111111111111111100111111111111111111111111110
01121212121212121212121212100112121212121212121212121210
01111111111111111111111111100111111111111111111111111110
01121000000112100000000112100112100000000112100000011210
01111011110111101111110111100111101111110111101111011110
01121011110112101111110112100112101111110112101111011210
01111000000111100000000111100111100000000111100000011110
01121111111112111111111112111112111111111112111111111210
01111111111111111111111111111111111111111111111111111110
01121218121212121212121212121212121212121212121218121210
01111111111111111111111111111111111111111111111111111110
01121000000112100112100000000000000112100112100000011210
01111000000111100111100000000000000111100111100000011110
01121111111112100112111111100111111112100112111111111210
01111111111111100111111111100111111111100111111111111110
01121212121212100112121212100112121212100112121212121210
01111111111111100111111111100111111111100111111111111110
00000000000112100000000112100112100000000112100000000000
11111111110111100000000111100111100000000111101111111111
11111111110112100111111112111112111111100112101111111111
11111111110111100111111111111111111111100111101111111111
11111111110112100112121212121212121212100112101111111111
11111111110111100111111111111111111111100111101111111111
11111111110112100112100001111110000112100112101111111111
00000000000111100111101111111111110111100111100000000000
11111111111112111112101111111111110112111112111111111111
11111111111111111111101111111111110111111111111111111111
12121212121212121212101111111111110112121212121212121212
11111111111111111111101111111111110111111111111111111111
00000000000112100112101111111111110112100112100000000000
11111111110111100111100000000000000111100111101111111111
11111111110112100112111111111111111112100112101111111111
11111111110111100111111111111111111111100111101111111111
11111111110112100112121212121212121212100112101111111111
11111111110111100111111111111111111111100111101111111111
11111111110112100112100000000000000112100112101111111111
00000000000111100111100000000000000111100111100000000000
01111111111112111112111111100111111112111112111111111110
01111111111111111111111111100111111111111111111111111110
01121212121212121212121212100112121212121212121212121210
01111111111111111111111111100111111111111111111111111110
01121000000112100000000112100112100000000112100000011210
01111000000111100000000111100111100000000111100000011110
01121111100112111111111112111112111111111112100111111210
01111111100111111111111111111111111111111111100111111110
01121218100112121212121212121112121212121212100118121210
01111111100111111111111111111111111111111111100111111110
00000112100112100112100000000000000112100112100112100000
00000111100111100111100000000000000111100111100111100000
01111112111112100112111111100111111112100112111112111110
01111111111111100111111111100111111111100111111111111110
01121212121212100112121212100112121212100112121212121210
01111111111111100111111111100111111111100111111111111110
01121000000000000000000112100112100000000000000000011210
01111000000000000000000111100111100000000000000000011110
01121111111111111111111112111112111111111111111111111210
01111111111111111111111111111111111111111111111111111110
01121212121212121212121212121212121212121212121212121210
01111111111111111111111111111111111111111111111111111110
00000000000000000000000000000000000000000000000000000000";
            return s;
        }

    public static List<Point> mapList(int stage, char mark)
    {
        // hardwired data instead of reading from file (not feasible on web player)
        List<Point> wList = new List<Point>();
        string walls = (stage == 1) ? wallInit() : wall2Init();
        using (StringReader reader = new StringReader(walls))
        {
            string line;
            int Y = 0;
            while ((line = reader.ReadLine()) != null)
            {

                for (int i = 0; i < line.Length; ++i)
                {
                    if (line[i] == mark)
                    {
                        wList.Add(new Point(i, Y));
                    }
                }
                Y++;
            }
        }
        wList = wList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
        return wList;
    }

    //    public static List<Point> dotList(int stage)
    //    {
    //        // hardwired data instead of reading from file (not feasible on web player)
    //        List<Point> wList = new List<Point>();
    //        string walls = (stage == 1) ? wallInit() : wall2Init();
    //        using (StringReader reader = new StringReader(walls))
    //        {
    //            string line;
    //            int Y = 0;
    //            while ((line = reader.ReadLine()) != null)
    //            {

    //                for (int X = 0; X < line.Length; ++X)
    //                {
    //                    if (line[X] == '2')
    //                    {
    //                        wList.Add(new Point(X, Y));
    //                    }
    //                }
    //                Y++;
    //            }
    //        }
    //        wList = wList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
    //        return wList;
    //    }

    //    public static List<Point> bonusList()
    //    {
    //        // hardwired data instead of reading from file (not feasible on web player)
    //        List<Point> wList = new List<Point>();
    //        string walls = wall2Init();
    //        using (StringReader reader = new StringReader(walls))
    //        {
    //            string line;
    //            int Y = 0;
    //            while ((line = reader.ReadLine()) != null)
    //            {

    //                for (int X = 0; X < line.Length; ++X)
    //                {
    //                    if (line[X] == '8')
    //                    {
    //                        wList.Add(new Point(X, Y));
    //                    }
    //                }
    //                Y++;
    //            }
    //        }
    //        wList = wList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
    //        return wList;
    //    }

     
    }

    public static class MazeList
    {
        //private static List<MazeRectangle> mList = new List<MazeRectangle>();


        private static string roadInit()
        {
            string data = @"0000000000000000000000000000
0111111111111001111111111110
0100001000001001000001000010
0101101011101111011101011010
0100001000001001000001000010
0111111111111001111111111110
0100001001000000001001000010
0100001001000000001001000010
0111111001111001111001111110
0001001000001001000001001000
0001001000001001000001001000
0111001111111111111111001110
0100001001001111001001000010
0100001001011111101001000010
0111111001011111101001111110
0100001001011111101001000010
0100001001000000001001000010
0111001001111111111001001110
0001001001000000001001001000
0001001001000000001001001000
0111111111111111111111111110
0100001000001001000001000010
0100001000001001000001000010
0111001111111001111111001110
0001001001000000001001001000
0001001001000000001001001000
0111111001111001111001111110
0100001000001001000001000010
0100001000001001000001000010
0111111111111111111111111110
0000000000000000000000000000";
            return data;
        }

        private static string road2Init()
        {
            string data = @"0000000000000000000000000000
0111111111111001111111111110
0100001000001001000001000010
0101101011101001011101011010
0100001000001001000001000010
0111111111111111111111111110
0100001001000000001001000010
0100001001000000001001000010
0111111001111001111001111110
0000001000001001000001000000
1111101000001001000001011111
1111101001111111111001011111
1111101001001111001001011111
0000001001011111101001000000
1111111111011111101111111111
0000001001011111101001000000
1111101001000000001001011111
1111101001111111111001011111
1111101001000000001001011111
0000001001000000001001000000
0111111111111001111111111110
0100001000001001000001000010
0100001000001001000001000010
0111001111111111111111001110
0001001001000000001001001000
0001001001000000001001001000
0111111001111001111001111110
0100000000001001000000000010
0100000000001001000000000010
0111111111111111111111111110
0000000000000000000000000000";
            return data;
        }




        public static List<Point> WallList(int stage)
        {
            // hardwired data instead of reading from file (not feasible on web player)
            List<Point> wList = new List<Point>();
            string map = (stage == 1) ? roadInit() : road2Init();
            using (StringReader reader = new StringReader(map))
            {
                string line;
                int Y = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    for (int i = 0; i < line.Length; ++i)
                    {
                        if (line[i] == '0')
                        {
                            wList.Add(new Point(i, Y));
                        }
                    }
                    Y++;
                }
            }
            wList = wList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return wList;
        }

        public static List<Point> RoadList()
        {
            // hardwired data instead of reading from file (not feasible on web player)
            List<Point> wList = new List<Point>();
            using (StringReader reader = new StringReader(road2Init()))
            {
                string line;
                int Y = 0;
                while ((line = reader.ReadLine()) != null)
                {

                    for (int i = 0; i < line.Length; ++i)
                    {
                        if (line[i] == '1')
                        {
                            wList.Add(new Point(i, Y));

                        }
                    }
                    Y++;
                }
            }

            return wList;
        }

        public static List<Point> wallPoints()
        {
            List<Point> pList = new List<Point>();
            return pList;
        }
    }

}
