using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanWinForms
{
    public static class PointLists
    {
        private static List<Point> dotList = new List<Point>();
        public static List<Point> dotPointList()
        {
            dotListInit();
            return dotList;
        }
        private static List<Point> banList = new List<Point>();
        public static List<Point> banPointList()
        {
            banListInit();
            return banList;
        }
        private static void dotListInit()
        {
            dotList.Clear();
            dotList.Add(new Point(26, 42));
            dotList.Add(new Point(24, 42));
            dotList.Add(new Point(22, 42));
            dotList.Add(new Point(20, 42));
            dotList.Add(new Point(18, 42));
            dotList.Add(new Point(16, 42));
            dotList.Add(new Point(14, 42));
            dotList.Add(new Point(12, 42));
            dotList.Add(new Point(10, 42));
            dotList.Add(new Point(8, 42));
            dotList.Add(new Point(6, 42));
            dotList.Add(new Point(4, 42));
            dotList.Add(new Point(4, 44));
            dotList.Add(new Point(4, 46));
            dotList.Add(new Point(4, 48));
            dotList.Add(new Point(6, 48));
            //dotList.Add(new Point(8, 48));
            dotList.Add(new Point(8, 50));
            dotList.Add(new Point(8, 52));
            dotList.Add(new Point(8, 54));
            dotList.Add(new Point(10, 54));
            dotList.Add(new Point(12, 54));
            dotList.Add(new Point(6, 54));
            dotList.Add(new Point(4, 54));
            dotList.Add(new Point(4, 56));
            dotList.Add(new Point(4, 58));
            dotList.Add(new Point(4, 60));
            dotList.Add(new Point(6, 60));
            dotList.Add(new Point(8, 60));
            dotList.Add(new Point(10, 60));
            dotList.Add(new Point(12, 60));
            //1st node
            dotList.Add(new Point(14, 60));
            for (int i = 58; i >= 6; i--)
            {
                dotList.Add(new Point(14, i));
                i--;
            }
            //
            dotList.Add(new Point(16, 60));
            dotList.Add(new Point(18, 60));
            dotList.Add(new Point(20, 60));
            dotList.Add(new Point(22, 60));
            dotList.Add(new Point(24, 60));
            dotList.Add(new Point(26, 60));
            dotList.Add(new Point(26, 58));
            dotList.Add(new Point(26, 56));
            dotList.Add(new Point(26, 54));
            dotList.Add(new Point(24, 54));
            dotList.Add(new Point(22, 54));
            dotList.Add(new Point(20, 54));
            dotList.Add(new Point(20, 52));
            dotList.Add(new Point(20, 50));
            dotList.Add(new Point(20, 48));
            dotList.Add(new Point(18, 48));
            dotList.Add(new Point(16, 48));
            dotList.Add(new Point(22, 48));
            dotList.Add(new Point(24, 48));
            dotList.Add(new Point(26, 48));
            dotList.Add(new Point(26, 46));
            dotList.Add(new Point(26, 44));
            dotList.Add(new Point(28, 60));
            dotList.Add(new Point(30, 60));
            dotList.Add(new Point(32, 60));
            dotList.Add(new Point(32, 58));
            dotList.Add(new Point(32, 56));
            dotList.Add(new Point(32, 54));
            dotList.Add(new Point(34, 54));
            dotList.Add(new Point(36, 54));
            dotList.Add(new Point(38, 54));
            dotList.Add(new Point(38, 52));
            dotList.Add(new Point(38, 50));
            dotList.Add(new Point(38, 48));
            dotList.Add(new Point(40, 48));
            dotList.Add(new Point(42, 48));
            dotList.Add(new Point(36, 48));
            dotList.Add(new Point(34, 48));
            dotList.Add(new Point(32, 48));
            dotList.Add(new Point(32, 46));
            dotList.Add(new Point(32, 44));
            dotList.Add(new Point(34, 60));
            dotList.Add(new Point(36, 60));
            dotList.Add(new Point(38, 60));
            dotList.Add(new Point(40, 60));
            dotList.Add(new Point(42, 60));
            dotList.Add(new Point(44, 60));
            for (int i = 58; i >= 6; i--)
            {
                dotList.Add(new Point(44, i));
                i--;
            }
            dotList.Add(new Point(46, 60));
            dotList.Add(new Point(48, 60));
            dotList.Add(new Point(50, 60));
            dotList.Add(new Point(52, 60));
            dotList.Add(new Point(54, 60));
            dotList.Add(new Point(54, 58));
            dotList.Add(new Point(54, 56));
            dotList.Add(new Point(54, 54));
            dotList.Add(new Point(52, 54));
            dotList.Add(new Point(50, 54));
            dotList.Add(new Point(48, 54));
            dotList.Add(new Point(46, 54));
            dotList.Add(new Point(50, 52));
            dotList.Add(new Point(50, 50));
            //dotList.Add(new Point(50, 48));
            dotList.Add(new Point(52, 48));
            dotList.Add(new Point(54, 48));
            dotList.Add(new Point(54, 46));
            dotList.Add(new Point(54, 44));
            dotList.Add(new Point(54, 42));
            dotList.Add(new Point(52, 42));
            dotList.Add(new Point(50, 42));
            dotList.Add(new Point(48, 42));
            dotList.Add(new Point(46, 42));
            dotList.Add(new Point(42, 42));
            dotList.Add(new Point(40, 42));
            dotList.Add(new Point(38, 42));
            dotList.Add(new Point(36, 42));
            dotList.Add(new Point(34, 42));
            dotList.Add(new Point(32, 42));

            for (int i = 40; i >= 24; i--)
            {
                dotList.Add(new Point(20, i));
                i--;
            }
            for (int i = 40; i >= 24; i--)
            {
                dotList.Add(new Point(38, i));
                i--;
            }
            for (int i = 36; i >= 22; i--)
            {
                dotList.Add(new Point(i, 36));
                i--;
            }
            for (int i = 36; i >= 22; i--)
            {
                dotList.Add(new Point(i, 24));
                i--;
            }

            dotList.Add(new Point(40, 24));
            dotList.Add(new Point(42, 24));
            dotList.Add(new Point(18, 24));
            dotList.Add(new Point(16, 24));

            for (int i = 4; i <= 26; i++)
            {
                dotList.Add(new Point(i, 4));
                i++;
            }
            for (int i = 32; i <= 54; i++)
            {
                dotList.Add(new Point(i, 4));
                i++;
            }
            for (int i = 6; i <= 18; i++)
            {
                dotList.Add(new Point(54, i));
                i++;
            }
            for (int i = 6; i <= 18; i++)
            {
                dotList.Add(new Point(4, i));
                i++;
            }
            for (int i = 24; i <= 36; i++)
            {
                dotList.Add(new Point(4, i));
                i++;
            }
            for (int i = 24; i <= 36; i++)
            {
                dotList.Add(new Point(54, i));
                i++;
            }
            for (int i = 46; i <= 54; i++)
            {
                dotList.Add(new Point(i, 30));
                i++;
            }
            for (int i = 46; i <= 54; i++)
            {
                dotList.Add(new Point(i, 18));
                i++;
            }
            for (int i = 46; i <= 54; i++)
            {
                dotList.Add(new Point(i, 12));
                i++;
            }
            for (int i = 6; i <= 14; i++)
            {
                dotList.Add(new Point(i, 12));
                i++;
            }
            for (int i = 6; i <= 14; i++)
            {
                dotList.Add(new Point(i, 18));
                i++;
            }
            for (int i = 6; i <= 14; i++)
            {
                dotList.Add(new Point(i, 30));
                i++;
            }
            for (int i = 20; i <= 26; i++)
            {
                dotList.Add(new Point(i, 18));
                i++;
            }
            for (int i = 32; i <= 38; i++)
            {
                dotList.Add(new Point(i, 18));
                i++;
            }
            for (int i = 16; i <= 26; i++)
            {
                dotList.Add(new Point(i, 12));
                i++;
            }
            for (int i = 32; i <= 42; i++)
            {
                dotList.Add(new Point(i, 12));
                i++;
            }
            for (int i = 26; i <= 32; i++)
            {
                dotList.Add(new Point(i, 8));
                i++;
            }
            for (int i = 20; i <= 24; i++)
            {
                dotList.Add(new Point(50, i));
                i++;
            }
            for (int i = 20; i <= 24; i++)
            {
                dotList.Add(new Point(8, i));
                i++;
            }
            for (int i = 36; i <= 40; i++)
            {
                dotList.Add(new Point(8, i));
                i++;
            }
            for (int i = 36; i <= 40; i++)
            {
                dotList.Add(new Point(50, i));
                i++;
            }
            dotList.Add(new Point(52, 36));
            dotList.Add(new Point(52, 24));
            dotList.Add(new Point(6, 36));
            dotList.Add(new Point(6, 24));
            dotList.Add(new Point(26, 20));
            dotList.Add(new Point(26, 22));
            dotList.Add(new Point(32, 20));
            dotList.Add(new Point(32, 22));
            dotList.Add(new Point(20, 16));
            dotList.Add(new Point(20, 14));
            dotList.Add(new Point(38, 16));
            dotList.Add(new Point(38, 14));
            dotList.Add(new Point(32, 10));
            dotList.Add(new Point(26, 10));
            dotList.Add(new Point(32, 6));
            dotList.Add(new Point(26, 6));

        }
        private static void banListInit()
        {
            banList.Clear();

            
                for (int i = 1; i <= 56; i++)
                {
                    banList.Add(new Point(i, 1));
                }

            
                for (int j = 2; j <= 62; j++)
                {
                    banList.Add(new Point(1, j));
                }

            
                for (int i = 2; i <= 56; i++)
                {
                    banList.Add(new Point(i, 62));
                }

                for (int j = 2; j <= 64 - 2; j++)
                {
                    banList.Add(new Point(56, j));
                }
            banList.Add(new Point(28, 2));
            banList.Add(new Point(29, 2));
            banList.Add(new Point(28, 3));
            banList.Add(new Point(29, 3));
            banList.Add(new Point(28, 4));
            banList.Add(new Point(29, 4));
            banList.Add(new Point(28, 5));
            banList.Add(new Point(29, 5));
            banList.Add(new Point(28, 10));
            banList.Add(new Point(29, 10));
            banList.Add(new Point(28, 11));
            banList.Add(new Point(29, 11));
            banList.Add(new Point(28, 12));
            banList.Add(new Point(29, 12));
            banList.Add(new Point(28, 13));
            banList.Add(new Point(29, 13));
            banList.Add(new Point(28, 14));
            banList.Add(new Point(29, 14));
            banList.Add(new Point(28, 15));
            banList.Add(new Point(29, 15));
            banList.Add(new Point(28, 16));
            banList.Add(new Point(29, 16));
            banList.Add(new Point(28, 17));
            banList.Add(new Point(29, 17));
            banList.Add(new Point(28, 18));
            banList.Add(new Point(29, 18));
            banList.Add(new Point(28, 19));
            banList.Add(new Point(29, 19));
            banList.Add(new Point(28, 20));
            banList.Add(new Point(29, 20));
            banList.Add(new Point(28, 21));
            banList.Add(new Point(29, 21));
            banList.Add(new Point(27, 14));
            banList.Add(new Point(27, 15));
            banList.Add(new Point(26, 14));
            banList.Add(new Point(26, 15));
            banList.Add(new Point(25, 14));
            banList.Add(new Point(25, 15));
            banList.Add(new Point(24, 14));
            banList.Add(new Point(24, 15));
            banList.Add(new Point(23, 14));
            banList.Add(new Point(23, 15));
            banList.Add(new Point(22, 14));
            banList.Add(new Point(22, 15));
            banList.Add(new Point(30, 14));
            banList.Add(new Point(30, 15));
            banList.Add(new Point(31, 14));
            banList.Add(new Point(31, 15));
            banList.Add(new Point(32, 14));
            banList.Add(new Point(32, 15));
            banList.Add(new Point(33, 14));
            banList.Add(new Point(33, 15));
            banList.Add(new Point(34, 14));
            banList.Add(new Point(34, 15));
            banList.Add(new Point(35, 14));
            banList.Add(new Point(35, 15));
            banList.Add(new Point(16, 6));
            banList.Add(new Point(16, 7));
            banList.Add(new Point(16, 8));
            banList.Add(new Point(16, 9));
            banList.Add(new Point(17, 6));
            //banList.Add(new Point(17, 7));
            //banList.Add(new Point(17, 8));
            banList.Add(new Point(17, 9));
            banList.Add(new Point(18, 6));
            //banList.Add(new Point(18, 7));
            //banList.Add(new Point(18, 8));
            banList.Add(new Point(18, 9));
            banList.Add(new Point(19, 6));
            //banList.Add(new Point(19, 7));
            //banList.Add(new Point(19, 8));
            banList.Add(new Point(19, 9));
            banList.Add(new Point(20, 6));
            //banList.Add(new Point(20, 7));
            //banList.Add(new Point(20, 8));
            banList.Add(new Point(20, 9));
            banList.Add(new Point(21, 6));
            //banList.Add(new Point(21, 7));
            //banList.Add(new Point(21, 8));
            banList.Add(new Point(21, 9));
            banList.Add(new Point(22, 6));
            //banList.Add(new Point(22, 7));
            //banList.Add(new Point(22, 8));
            banList.Add(new Point(22, 9));
            banList.Add(new Point(23, 6));
            banList.Add(new Point(23, 7));
            banList.Add(new Point(23, 8));
            banList.Add(new Point(23, 9));
            banList.Add(new Point(11, 6));
            banList.Add(new Point(11, 7));
            banList.Add(new Point(11, 8));
            banList.Add(new Point(11, 9));
            banList.Add(new Point(10, 6));
            //banList.Add(new Point(10, 7));
            //banList.Add(new Point(10, 8));
            banList.Add(new Point(10, 9));
            banList.Add(new Point(9, 6));
            //banList.Add(new Point(9, 7));
            //banList.Add(new Point(9, 8));
            banList.Add(new Point(9, 9));
            banList.Add(new Point(8, 6));
            //banList.Add(new Point(8, 7));
            //banList.Add(new Point(8, 8));
            banList.Add(new Point(8, 9));
            banList.Add(new Point(7, 6));
            //banList.Add(new Point(7, 7));
            //banList.Add(new Point(7, 8));
            banList.Add(new Point(7, 9));
            banList.Add(new Point(6, 6));
            banList.Add(new Point(6, 7));
            banList.Add(new Point(6, 8));
            banList.Add(new Point(6, 9));
            banList.Add(new Point(35, 6));
            //banList.Add(new Point(35, 7));
            //banList.Add(new Point(35, 8));
            banList.Add(new Point(35, 9));
            banList.Add(new Point(34, 6));
            banList.Add(new Point(34, 7));
            banList.Add(new Point(34, 8));
            banList.Add(new Point(34, 9));
            banList.Add(new Point(36, 6));
            //banList.Add(new Point(36, 7));
            //banList.Add(new Point(36, 8));
            banList.Add(new Point(36, 9));
            banList.Add(new Point(37, 6));
            //banList.Add(new Point(37, 7));
            //banList.Add(new Point(37, 8));
            banList.Add(new Point(37, 9));
            banList.Add(new Point(38, 6));
            //banList.Add(new Point(38, 7));
            //banList.Add(new Point(38, 8));
            banList.Add(new Point(38, 9));
            banList.Add(new Point(39, 6));
            //banList.Add(new Point(39, 7));
            //banList.Add(new Point(39, 8));
            banList.Add(new Point(39, 9));
            banList.Add(new Point(40, 6));
            //banList.Add(new Point(40, 7));
            //banList.Add(new Point(40, 8));
            banList.Add(new Point(40, 9));
            banList.Add(new Point(41, 6));
            banList.Add(new Point(41, 7));
            banList.Add(new Point(41, 8));
            banList.Add(new Point(41, 9));
            banList.Add(new Point(46, 6));
            banList.Add(new Point(46, 7));
            banList.Add(new Point(46, 8));
            banList.Add(new Point(46, 9));
            banList.Add(new Point(47, 6));
            //banList.Add(new Point(47, 7));
            //banList.Add(new Point(47, 8));
            banList.Add(new Point(47, 9));
            banList.Add(new Point(48, 6));
            //banList.Add(new Point(48, 7));
            //banList.Add(new Point(48, 8));
            banList.Add(new Point(48, 9));
            banList.Add(new Point(49, 6));
            //banList.Add(new Point(49, 7));
            //banList.Add(new Point(49, 8));
            banList.Add(new Point(49, 9));
            banList.Add(new Point(50, 6));
            //banList.Add(new Point(50, 7));
            //banList.Add(new Point(50, 8));
            banList.Add(new Point(50, 9));
            banList.Add(new Point(51, 6));
            banList.Add(new Point(51, 7));
            banList.Add(new Point(51, 8));
            banList.Add(new Point(51, 9));
            banList.Add(new Point(51, 14));
            banList.Add(new Point(50, 14));
            banList.Add(new Point(49, 14));
            banList.Add(new Point(48, 14));
            banList.Add(new Point(47, 14));
            banList.Add(new Point(46, 14));
            banList.Add(new Point(51, 15));
            banList.Add(new Point(50, 15));
            banList.Add(new Point(49, 15));
            banList.Add(new Point(48, 15));
            banList.Add(new Point(47, 15));
            banList.Add(new Point(46, 15));
            banList.Add(new Point(6, 15));
            banList.Add(new Point(7, 15));
            banList.Add(new Point(8, 15));
            banList.Add(new Point(9, 15));
            banList.Add(new Point(10, 15));
            banList.Add(new Point(11, 15));
            banList.Add(new Point(6, 14));
            banList.Add(new Point(7, 14));
            banList.Add(new Point(8, 14));
            banList.Add(new Point(9, 14));
            banList.Add(new Point(10, 14));
            banList.Add(new Point(11, 14));
            banList.Add(new Point(16, 14));
            banList.Add(new Point(17, 14));
            banList.Add(new Point(16, 15));
            banList.Add(new Point(17, 15));
            banList.Add(new Point(16, 16));
            banList.Add(new Point(17, 16));
            banList.Add(new Point(16, 17));
            banList.Add(new Point(17, 17));
            banList.Add(new Point(16, 18));
            banList.Add(new Point(17, 18));
            banList.Add(new Point(16, 19));
            banList.Add(new Point(17, 19));
            banList.Add(new Point(16, 20));
            banList.Add(new Point(17, 20));
            banList.Add(new Point(16, 21));
            banList.Add(new Point(17, 21));
            banList.Add(new Point(18, 21));
            banList.Add(new Point(19, 21));
            banList.Add(new Point(20, 21));
            banList.Add(new Point(21, 21));
            banList.Add(new Point(22, 21));
            banList.Add(new Point(23, 21));
            banList.Add(new Point(18, 20));
            banList.Add(new Point(19, 20));
            banList.Add(new Point(20, 20));
            banList.Add(new Point(21, 20));
            banList.Add(new Point(22, 20));
            banList.Add(new Point(23, 20));
            banList.Add(new Point(34, 21));
            banList.Add(new Point(35, 21));
            banList.Add(new Point(36, 21));
            banList.Add(new Point(37, 21));
            banList.Add(new Point(38, 21));
            banList.Add(new Point(39, 21));
            banList.Add(new Point(34, 20));
            banList.Add(new Point(35, 20));
            banList.Add(new Point(36, 20));
            banList.Add(new Point(37, 20));
            banList.Add(new Point(38, 20));
            banList.Add(new Point(39, 20));
            banList.Add(new Point(40, 20));
            banList.Add(new Point(41, 20));
            banList.Add(new Point(40, 21));
            banList.Add(new Point(41, 21));
            banList.Add(new Point(40, 19));
            banList.Add(new Point(41, 19));
            banList.Add(new Point(40, 18));
            banList.Add(new Point(41, 18));
            banList.Add(new Point(40, 17));
            banList.Add(new Point(41, 17));
            banList.Add(new Point(40, 16));
            banList.Add(new Point(41, 16));
            banList.Add(new Point(40, 15));
            banList.Add(new Point(41, 15));
            banList.Add(new Point(40, 14));
            banList.Add(new Point(41, 14));
            banList.Add(new Point(2, 20));
            banList.Add(new Point(2, 21));
            banList.Add(new Point(3, 20));
            banList.Add(new Point(3, 21));
            banList.Add(new Point(4, 20));
            banList.Add(new Point(4, 21));
            banList.Add(new Point(5, 20));
            banList.Add(new Point(5, 21));
            banList.Add(new Point(52, 20));
            banList.Add(new Point(52, 21));
            banList.Add(new Point(53, 20));
            banList.Add(new Point(53, 21));
            banList.Add(new Point(54, 20));
            banList.Add(new Point(54, 21));
            banList.Add(new Point(55, 20));
            banList.Add(new Point(55, 21));
            banList.Add(new Point(47, 20));
            banList.Add(new Point(46, 20));
            banList.Add(new Point(47, 21));
            banList.Add(new Point(46, 21));
            banList.Add(new Point(47, 22));
            banList.Add(new Point(46, 22));
            banList.Add(new Point(47, 23));
            banList.Add(new Point(46, 23));
            banList.Add(new Point(47, 24));
            banList.Add(new Point(46, 24));
            banList.Add(new Point(47, 25));
            banList.Add(new Point(46, 25));
            banList.Add(new Point(47, 26));
            banList.Add(new Point(46, 26));
            banList.Add(new Point(47, 27));
            banList.Add(new Point(46, 27));
            banList.Add(new Point(48, 27));
            banList.Add(new Point(49, 27));
            banList.Add(new Point(50, 27));
            banList.Add(new Point(51, 27));
            banList.Add(new Point(48, 26));
            banList.Add(new Point(49, 26));
            banList.Add(new Point(50, 26));
            banList.Add(new Point(51, 26));
            banList.Add(new Point(10, 20));
            banList.Add(new Point(11, 20));
            banList.Add(new Point(10, 21));
            banList.Add(new Point(11, 21));
            banList.Add(new Point(10, 22));
            banList.Add(new Point(11, 22));
            banList.Add(new Point(10, 23));
            banList.Add(new Point(11, 23));
            banList.Add(new Point(10, 24));
            banList.Add(new Point(11, 24));
            banList.Add(new Point(10, 25));
            banList.Add(new Point(11, 25));
            banList.Add(new Point(10, 26));
            banList.Add(new Point(11, 26));
            banList.Add(new Point(10, 27));
            banList.Add(new Point(11, 27));
            banList.Add(new Point(9, 27));
            banList.Add(new Point(8, 27));
            banList.Add(new Point(7, 27));
            banList.Add(new Point(6, 27));
            banList.Add(new Point(9, 26));
            banList.Add(new Point(8, 26));
            banList.Add(new Point(7, 26));
            banList.Add(new Point(6, 26));
            banList.Add(new Point(9, 32));
            banList.Add(new Point(8, 32));
            banList.Add(new Point(7, 32));
            banList.Add(new Point(6, 32));
            banList.Add(new Point(9, 33));
            banList.Add(new Point(8, 33));
            banList.Add(new Point(7, 33));
            banList.Add(new Point(6, 33));
            banList.Add(new Point(10, 34));
            banList.Add(new Point(11, 34));
            banList.Add(new Point(10, 35));
            banList.Add(new Point(11, 35));
            banList.Add(new Point(10, 36));
            banList.Add(new Point(11, 36));
            banList.Add(new Point(10, 37));
            banList.Add(new Point(11, 37));
            banList.Add(new Point(10, 38));
            banList.Add(new Point(11, 38));
            banList.Add(new Point(10, 39));
            banList.Add(new Point(11, 39));
            banList.Add(new Point(10, 33));
            banList.Add(new Point(11, 33));
            banList.Add(new Point(10, 32));
            banList.Add(new Point(11, 32));
            banList.Add(new Point(47, 34));
            banList.Add(new Point(46, 34));
            banList.Add(new Point(47, 35));
            banList.Add(new Point(46, 35));
            banList.Add(new Point(47, 36));
            banList.Add(new Point(46, 36));
            banList.Add(new Point(47, 37));
            banList.Add(new Point(46, 37));
            banList.Add(new Point(47, 38));
            banList.Add(new Point(46, 38));
            banList.Add(new Point(47, 39));
            banList.Add(new Point(46, 39));
            banList.Add(new Point(47, 33));
            banList.Add(new Point(46, 33));
            banList.Add(new Point(47, 32));
            banList.Add(new Point(46, 32));
            banList.Add(new Point(48, 32));
            banList.Add(new Point(49, 32));
            banList.Add(new Point(50, 32));
            banList.Add(new Point(51, 32));
            banList.Add(new Point(48, 33));
            banList.Add(new Point(49, 33));
            banList.Add(new Point(50, 33));
            banList.Add(new Point(51, 33));
            banList.Add(new Point(40, 34));
            banList.Add(new Point(41, 34));
            banList.Add(new Point(40, 35));
            banList.Add(new Point(41, 35));
            banList.Add(new Point(40, 36));
            banList.Add(new Point(41, 36));
            banList.Add(new Point(40, 37));
            banList.Add(new Point(41, 37));
            banList.Add(new Point(40, 38));
            banList.Add(new Point(41, 38));
            banList.Add(new Point(40, 39));
            banList.Add(new Point(41, 39));
            banList.Add(new Point(40, 33));
            banList.Add(new Point(41, 33));
            banList.Add(new Point(40, 32));
            banList.Add(new Point(41, 32));
            banList.Add(new Point(40, 31));
            banList.Add(new Point(41, 31));
            banList.Add(new Point(40, 30));
            banList.Add(new Point(41, 30));
            banList.Add(new Point(40, 29));
            banList.Add(new Point(41, 29));
            banList.Add(new Point(40, 28));
            banList.Add(new Point(41, 28));
            banList.Add(new Point(40, 27));
            banList.Add(new Point(41, 27));
            banList.Add(new Point(40, 26));
            banList.Add(new Point(41, 26));
            banList.Add(new Point(16, 34));
            banList.Add(new Point(17, 34));
            banList.Add(new Point(16, 35));
            banList.Add(new Point(17, 35));
            banList.Add(new Point(16, 36));
            banList.Add(new Point(17, 36));
            banList.Add(new Point(16, 37));
            banList.Add(new Point(17, 37));
            banList.Add(new Point(16, 38));
            banList.Add(new Point(17, 38));
            banList.Add(new Point(16, 39));
            banList.Add(new Point(17, 39));
            banList.Add(new Point(16, 33));
            banList.Add(new Point(17, 33));
            banList.Add(new Point(16, 32));
            banList.Add(new Point(17, 32));
            banList.Add(new Point(16, 31));
            banList.Add(new Point(17, 31));
            banList.Add(new Point(16, 30));
            banList.Add(new Point(17, 30));
            banList.Add(new Point(16, 29));
            banList.Add(new Point(17, 29));
            banList.Add(new Point(16, 28));
            banList.Add(new Point(17, 28));
            banList.Add(new Point(16, 27));
            banList.Add(new Point(17, 27));
            banList.Add(new Point(16, 26));
            banList.Add(new Point(17, 26));
            banList.Add(new Point(2, 38));
            banList.Add(new Point(2, 39));
            banList.Add(new Point(3, 38));
            banList.Add(new Point(3, 39));
            banList.Add(new Point(4, 38));
            banList.Add(new Point(4, 39));
            banList.Add(new Point(5, 38));
            banList.Add(new Point(5, 39));
            banList.Add(new Point(2, 51));
            banList.Add(new Point(2, 50));
            banList.Add(new Point(3, 51));
            banList.Add(new Point(3, 50));
            banList.Add(new Point(4, 51));
            banList.Add(new Point(4, 50));
            banList.Add(new Point(5, 51));
            banList.Add(new Point(5, 50));
            banList.Add(new Point(52, 51));
            banList.Add(new Point(52, 50));
            banList.Add(new Point(53, 51));
            banList.Add(new Point(53, 50));
            banList.Add(new Point(54, 51));
            banList.Add(new Point(54, 50));
            banList.Add(new Point(55, 51));
            banList.Add(new Point(55, 50));
            banList.Add(new Point(52, 39));
            banList.Add(new Point(52, 38));
            banList.Add(new Point(53, 39));
            banList.Add(new Point(53, 38));
            banList.Add(new Point(54, 39));
            banList.Add(new Point(54, 38));
            banList.Add(new Point(55, 39));
            banList.Add(new Point(55, 38));
            banList.Add(new Point(16, 44));
            banList.Add(new Point(16, 45));
            banList.Add(new Point(17, 44));
            banList.Add(new Point(17, 45));
            banList.Add(new Point(18, 44));
            banList.Add(new Point(18, 45));
            banList.Add(new Point(19, 44));
            banList.Add(new Point(19, 45));
            banList.Add(new Point(20, 44));
            banList.Add(new Point(20, 45));
            banList.Add(new Point(21, 44));
            banList.Add(new Point(21, 45));
            banList.Add(new Point(22, 44));
            banList.Add(new Point(22, 45));
            banList.Add(new Point(23, 44));
            banList.Add(new Point(23, 45));
            banList.Add(new Point(16, 56));
            banList.Add(new Point(16, 57));
            banList.Add(new Point(17, 56));
            banList.Add(new Point(17, 57));
            banList.Add(new Point(18, 56));
            banList.Add(new Point(18, 57));
            banList.Add(new Point(19, 56));
            banList.Add(new Point(19, 57));
            banList.Add(new Point(20, 56));
            banList.Add(new Point(20, 57));
            banList.Add(new Point(21, 56));
            banList.Add(new Point(21, 57));
            banList.Add(new Point(22, 56));
            banList.Add(new Point(22, 57));
            banList.Add(new Point(23, 56));
            banList.Add(new Point(23, 57));
            banList.Add(new Point(34, 56));
            banList.Add(new Point(34, 57));
            banList.Add(new Point(35, 56));
            banList.Add(new Point(35, 57));
            banList.Add(new Point(36, 56));
            banList.Add(new Point(36, 57));
            banList.Add(new Point(37, 56));
            banList.Add(new Point(37, 57));
            banList.Add(new Point(38, 56));
            banList.Add(new Point(38, 57));
            banList.Add(new Point(39, 56));
            banList.Add(new Point(39, 57));
            banList.Add(new Point(40, 56));
            banList.Add(new Point(40, 57));
            banList.Add(new Point(41, 56));
            banList.Add(new Point(41, 57));
            banList.Add(new Point(34, 44));
            banList.Add(new Point(34, 45));
            banList.Add(new Point(35, 44));
            banList.Add(new Point(35, 45));
            banList.Add(new Point(36, 44));
            banList.Add(new Point(36, 45));
            banList.Add(new Point(37, 44));
            banList.Add(new Point(37, 45));
            banList.Add(new Point(38, 44));
            banList.Add(new Point(38, 45));
            banList.Add(new Point(39, 44));
            banList.Add(new Point(39, 45));
            banList.Add(new Point(40, 44));
            banList.Add(new Point(40, 45));
            banList.Add(new Point(41, 44));
            banList.Add(new Point(41, 45));
            banList.Add(new Point(6, 56));
            banList.Add(new Point(6, 57));
            banList.Add(new Point(7, 56));
            banList.Add(new Point(7, 57));
            banList.Add(new Point(8, 56));
            banList.Add(new Point(8, 57));
            banList.Add(new Point(9, 56));
            banList.Add(new Point(9, 57));
            banList.Add(new Point(10, 56));
            banList.Add(new Point(10, 57));
            banList.Add(new Point(11, 56));
            banList.Add(new Point(11, 57));
            banList.Add(new Point(6, 44));
            banList.Add(new Point(6, 45));
            banList.Add(new Point(7, 44));
            banList.Add(new Point(7, 45));
            banList.Add(new Point(8, 44));
            banList.Add(new Point(8, 45));
            banList.Add(new Point(9, 44));
            banList.Add(new Point(9, 45));
            banList.Add(new Point(10, 44));
            banList.Add(new Point(10, 45));
            banList.Add(new Point(11, 44));
            banList.Add(new Point(11, 45));
            banList.Add(new Point(46, 56));
            banList.Add(new Point(46, 57));
            banList.Add(new Point(47, 56));
            banList.Add(new Point(47, 57));
            banList.Add(new Point(48, 56));
            banList.Add(new Point(48, 57));
            banList.Add(new Point(49, 56));
            banList.Add(new Point(49, 57));
            banList.Add(new Point(50, 56));
            banList.Add(new Point(50, 57));
            banList.Add(new Point(51, 56));
            banList.Add(new Point(51, 57));
            banList.Add(new Point(46, 44));
            banList.Add(new Point(46, 45));
            banList.Add(new Point(47, 44));
            banList.Add(new Point(47, 45));
            banList.Add(new Point(48, 44));
            banList.Add(new Point(48, 45));
            banList.Add(new Point(49, 44));
            banList.Add(new Point(49, 45));
            banList.Add(new Point(50, 44));
            banList.Add(new Point(50, 45));
            banList.Add(new Point(51, 44));
            banList.Add(new Point(51, 45));
            banList.Add(new Point(22, 38));
            banList.Add(new Point(22, 39));
            banList.Add(new Point(23, 38));
            banList.Add(new Point(23, 39));
            banList.Add(new Point(24, 38));
            banList.Add(new Point(24, 39));
            banList.Add(new Point(25, 38));
            banList.Add(new Point(25, 39));
            banList.Add(new Point(26, 38));
            banList.Add(new Point(26, 39));
            banList.Add(new Point(27, 38));
            banList.Add(new Point(27, 39));
            banList.Add(new Point(28, 38));
            banList.Add(new Point(28, 39));
            banList.Add(new Point(29, 38));
            banList.Add(new Point(29, 39));
            banList.Add(new Point(30, 38));
            banList.Add(new Point(30, 39));
            banList.Add(new Point(31, 38));
            banList.Add(new Point(31, 39));
            banList.Add(new Point(32, 38));
            banList.Add(new Point(32, 39));
            banList.Add(new Point(33, 38));
            banList.Add(new Point(33, 39));
            banList.Add(new Point(34, 38));
            banList.Add(new Point(34, 39));
            banList.Add(new Point(35, 38));
            banList.Add(new Point(35, 39));
            banList.Add(new Point(22, 50));
            banList.Add(new Point(22, 51));
            banList.Add(new Point(23, 50));
            banList.Add(new Point(23, 51));
            banList.Add(new Point(24, 50));
            banList.Add(new Point(24, 51));
            banList.Add(new Point(25, 50));
            banList.Add(new Point(25, 51));
            banList.Add(new Point(26, 50));
            banList.Add(new Point(26, 51));
            banList.Add(new Point(27, 50));
            banList.Add(new Point(27, 51));
            banList.Add(new Point(28, 50));
            banList.Add(new Point(28, 51));
            banList.Add(new Point(29, 50));
            banList.Add(new Point(29, 51));
            banList.Add(new Point(30, 50));
            banList.Add(new Point(30, 51));
            banList.Add(new Point(31, 50));
            banList.Add(new Point(31, 51));
            banList.Add(new Point(32, 50));
            banList.Add(new Point(32, 51));
            banList.Add(new Point(33, 50));
            banList.Add(new Point(33, 51));
            banList.Add(new Point(34, 50));
            banList.Add(new Point(34, 51));
            banList.Add(new Point(35, 50));
            banList.Add(new Point(35, 51));
            banList.Add(new Point(22, 26));
            banList.Add(new Point(22, 27));
            banList.Add(new Point(23, 26));
            //banList.Add(new Point(23, 27));
            banList.Add(new Point(24, 26));
            //banList.Add(new Point(24, 27));
            banList.Add(new Point(25, 26));
            //banList.Add(new Point(25, 27));
           // banList.Add(new Point(26, 26));
            //banList.Add(new Point(26, 27));
           // banList.Add(new Point(27, 26));
            //banList.Add(new Point(27, 27));
           // banList.Add(new Point(28, 26));
            //banList.Add(new Point(28, 27));
           // banList.Add(new Point(29, 26));
            //banList.Add(new Point(29, 27));
           // banList.Add(new Point(30, 26));
            //banList.Add(new Point(30, 27));
           // banList.Add(new Point(31, 26));
            //banList.Add(new Point(31, 27));
            banList.Add(new Point(32, 26));
            //banList.Add(new Point(32, 27));
            banList.Add(new Point(33, 26));
            //banList.Add(new Point(33, 27));
            banList.Add(new Point(34, 26));
            //banList.Add(new Point(34, 27));
            banList.Add(new Point(35, 26));
            banList.Add(new Point(35, 27));
            banList.Add(new Point(22, 28));
            banList.Add(new Point(22, 29));
            //banList.Add(new Point(23, 28));
            //banList.Add(new Point(23, 29));
            //banList.Add(new Point(24, 28));
            //banList.Add(new Point(24, 29));
            //banList.Add(new Point(25, 28));
            //banList.Add(new Point(25, 29));
            //banList.Add(new Point(26, 28));
            //banList.Add(new Point(26, 29));
            //banList.Add(new Point(27, 28));
            //banList.Add(new Point(27, 29));
            //banList.Add(new Point(28, 28));
            //banList.Add(new Point(28, 29));
            //banList.Add(new Point(29, 28));
            //banList.Add(new Point(29, 29));
            //banList.Add(new Point(30, 28));
            //banList.Add(new Point(30, 29));
            //banList.Add(new Point(31, 28));
            //banList.Add(new Point(31, 29));
            //banList.Add(new Point(32, 28));
            //banList.Add(new Point(32, 29));
            //banList.Add(new Point(33, 28));
            //banList.Add(new Point(33, 29));
            //banList.Add(new Point(34, 28));
            //banList.Add(new Point(34, 29));
            banList.Add(new Point(35, 28));
            banList.Add(new Point(35, 29));
            banList.Add(new Point(22, 30));
            banList.Add(new Point(22, 31));
            //banList.Add(new Point(23, 30));
            //banList.Add(new Point(23, 31));
            //banList.Add(new Point(24, 30));
            //banList.Add(new Point(24, 31));
            //banList.Add(new Point(25, 30));
            //banList.Add(new Point(25, 31));
            //banList.Add(new Point(26, 30));
            //banList.Add(new Point(26, 31));
            //banList.Add(new Point(27, 30));
            //banList.Add(new Point(27, 31));
            //banList.Add(new Point(28, 30));
            //banList.Add(new Point(28, 31));
            //banList.Add(new Point(29, 30));
            //banList.Add(new Point(29, 31));
            //banList.Add(new Point(30, 30));
            //banList.Add(new Point(30, 31));
            //banList.Add(new Point(31, 30));
            //banList.Add(new Point(31, 31));
            //banList.Add(new Point(32, 30));
            //banList.Add(new Point(32, 31));
            //banList.Add(new Point(33, 30));
            //banList.Add(new Point(33, 31));
            //banList.Add(new Point(34, 30));
            //banList.Add(new Point(34, 31));
            banList.Add(new Point(35, 30));
            banList.Add(new Point(35, 31));
            banList.Add(new Point(22, 32));
            banList.Add(new Point(22, 33));
            //banList.Add(new Point(23, 32));
            banList.Add(new Point(23, 33));
            //banList.Add(new Point(24, 32));
            banList.Add(new Point(24, 33));
            //banList.Add(new Point(25, 32));
            banList.Add(new Point(25, 33));
            //banList.Add(new Point(26, 32));
            banList.Add(new Point(26, 33));
            //banList.Add(new Point(27, 32));
            banList.Add(new Point(27, 33));
            //banList.Add(new Point(28, 32));
            banList.Add(new Point(28, 33));
            //banList.Add(new Point(29, 32));
            banList.Add(new Point(29, 33));
            //banList.Add(new Point(30, 32));
            banList.Add(new Point(30, 33));
            //banList.Add(new Point(31, 32));
            banList.Add(new Point(31, 33));
            //banList.Add(new Point(32, 32));
            banList.Add(new Point(32, 33));
            //banList.Add(new Point(33, 32));
            banList.Add(new Point(33, 33));
            //banList.Add(new Point(34, 32));
            banList.Add(new Point(34, 33));
            banList.Add(new Point(35, 32));
            banList.Add(new Point(35, 33));
            banList.Add(new Point(10, 46));
            banList.Add(new Point(11, 46));
            banList.Add(new Point(10, 47));
            banList.Add(new Point(11, 47));
            banList.Add(new Point(10, 48));
            banList.Add(new Point(11, 48));
            banList.Add(new Point(10, 49));
            banList.Add(new Point(11, 49));
            banList.Add(new Point(10, 50));
            banList.Add(new Point(11, 50));
            banList.Add(new Point(10, 51));
            banList.Add(new Point(11, 51));
            banList.Add(new Point(16, 50));
            banList.Add(new Point(17, 50));
            banList.Add(new Point(16, 51));
            banList.Add(new Point(17, 51));
            banList.Add(new Point(16, 52));
            banList.Add(new Point(17, 52));
            banList.Add(new Point(16, 53));
            banList.Add(new Point(17, 53));
            banList.Add(new Point(16, 54));
            banList.Add(new Point(17, 54));
            banList.Add(new Point(16, 55));
            banList.Add(new Point(17, 55));
            banList.Add(new Point(40, 50));
            banList.Add(new Point(41, 50));
            banList.Add(new Point(40, 51));
            banList.Add(new Point(41, 51));
            banList.Add(new Point(40, 52));
            banList.Add(new Point(41, 52));
            banList.Add(new Point(40, 53));
            banList.Add(new Point(41, 53));
            banList.Add(new Point(40, 54));
            banList.Add(new Point(41, 54));
            banList.Add(new Point(40, 55));
            banList.Add(new Point(41, 55));
            banList.Add(new Point(46, 46));
            banList.Add(new Point(47, 46));
            banList.Add(new Point(46, 47));
            banList.Add(new Point(47, 47));
            banList.Add(new Point(46, 48));
            banList.Add(new Point(47, 48));
            banList.Add(new Point(46, 49));
            banList.Add(new Point(47, 49));
            banList.Add(new Point(46, 50));
            banList.Add(new Point(47, 50));
            banList.Add(new Point(46, 51));
            banList.Add(new Point(47, 51));
            banList.Add(new Point(28, 44));
            banList.Add(new Point(29, 44));
            banList.Add(new Point(28, 45));
            banList.Add(new Point(29, 45));
            banList.Add(new Point(28, 46));
            banList.Add(new Point(29, 46));
            banList.Add(new Point(28, 47));
            banList.Add(new Point(29, 47));
            banList.Add(new Point(28, 48));
            banList.Add(new Point(29, 48));
            banList.Add(new Point(28, 49));
            banList.Add(new Point(29, 49));
            banList.Add(new Point(28, 52));
            banList.Add(new Point(29, 52));
            banList.Add(new Point(28, 53));
            banList.Add(new Point(29, 53));
            banList.Add(new Point(28, 54));
            banList.Add(new Point(29, 54));
            banList.Add(new Point(28, 55));
            banList.Add(new Point(29, 55));
            banList.Add(new Point(28, 56));
            banList.Add(new Point(29, 56));
            banList.Add(new Point(28, 57));
            banList.Add(new Point(29, 57));


        }

    }
}
