using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleApp10
{
    class Program
    {
        class Subj
        {
            public event EventHandler Oops;
            public void CryOops()
            {
                if (Oops != null) Oops(this, null);
            }
        }
        class ObsA
        {
            public void OnOops(object sender, EventArgs e)
            {
                int cursX = Console.CursorLeft;
                int cursY = Console.CursorTop;
                MessageBox.Show($" Опа !!! Вы вышли за поля! \n Координаты: x = {cursX}; y = { cursY}");

            }
        }
        static void Main(string[] args)
            {
            Subj s = new Subj();
            ObsA obj1 = new ObsA();
            ObsA obj2 = new ObsA();
            Program Action = new Program();
                //Допуски на перемещение
                bool up = true, left = true, right = true, down = true;
                int x = 15, y = 15;
                Action.Draw(x, y, ref up, ref left, ref right, ref down);
                Console.SetCursorPosition(x, y);
                Console.Write("*");
                while (true)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow: if (up) y--; break;
                        case ConsoleKey.DownArrow: if (down) y++; break;
                        case ConsoleKey.LeftArrow: if (left) x--; break;
                        case ConsoleKey.RightArrow: if (right) x++; break;
                        case ConsoleKey.Escape: return;
                        default: break;
                    }
                    up = true; left = true; right = true; down = true;
                    //Рисуем карту:
                    Console.Clear();
                    Action.Draw(x, y, ref up, ref left, ref right, ref down);
                    //Запрет на преодоление границ ком.строки:
                    if (x > 78) right = false;
                    if (x < 1) left = false;
                    if (y < 1) up = false;
                    if (y > 23) down = false;
                    //Выводим точку
                    Console.SetCursorPosition(x, y);
                    Console.Write("*");
                if (x == 46  && y == 17)
                {
                    s.Oops += new EventHandler(obj1.OnOops);
                    s.CryOops();
                    s.Oops -= new EventHandler(obj1.OnOops);




                }
                if (x == 9 && y == 16)
                {
                    s.Oops += new EventHandler(obj1.OnOops);
                    s.CryOops();
                    



                }

                }
                
        }
            //Горизонтальная
            void DrawHLine(int x, int y, int from, int to, int yLine,
                           ref bool up, ref bool down)
            {
                for (int i = from; i <= to; i++)
                {
                    if ((y - yLine == -1) && (x >= from) && (x <= to)) down = false;
                    if ((y - yLine == 1) && (x >= from) && (x <= to)) up = false;
                    Console.SetCursorPosition(i, yLine);
                    Console.Write("#");
                }
            }
            //Вертикальная
            void DrawVLine(int x, int y, int from, int to, int xLine,
                           ref bool left, ref bool right)
            {
                for (int i = from; i <= to; i++)
                {
                    if ((x - xLine == -1) && (y >= from) && (y <= to)) right = false;
                    if ((x - xLine == 1) && (y >= from) && (y <= to)) left = false;
                    Console.SetCursorPosition(xLine, i);
                    Console.Write("#");
                }
            }
        //Карта
        void Draw(int x, int y, ref bool up, ref bool left, ref bool right, ref bool down)
        {
            DrawHLine(x, y, 10, 30, 5, ref up, ref down);
            DrawVLine(x, y, 5, 10, 30, ref left, ref right);
            DrawHLine(x, y, 30, 43, 10, ref up, ref down);
            DrawVLine(x, y, 5, 10, 40, ref left, ref right);
            DrawHLine(x, y, 40, 45, 5, ref up, ref down);
            DrawVLine(x, y, 5, 16, 45, ref left, ref right);
            DrawVLine(x, y, 18, 20, 45, ref left, ref right);
            DrawHLine(x, y, 10, 45, 20, ref up, ref down);
            DrawVLine(x, y, 5, 15, 10, ref left, ref right);
            DrawVLine(x, y, 17, 20, 10, ref left, ref right);
        }

    }
    }



