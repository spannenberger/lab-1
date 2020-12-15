using System;
using System.Collections.Generic;
using Library;
using System.Linq;

namespace Spannenberger_s_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rectangle> Rectangles = new List<Rectangle>();
            PrintHelp();
            while (Run(Rectangles)) ;
        }

        static bool Run(List<Rectangle> Rectangles)
        {
            string buf;
            string[] command;
            buf = Console.ReadLine();
            command = buf.Split(' ');
            try
            {
                switch (command[0].ToLower())
                {
                    case "stop":
                        return false;

                    case "new":
                        AddNewRectangle(Rectangles, command);
                        break;

                    case "min":
                        GetMinRectangle(Rectangles, command);
                        break;

                    case "int":
                        GetIntersection(Rectangles, command);
                        break;

                    case "scale":
                        ScaleRectangle(Rectangles, command);
                        break;

                    case "move":
                        MoveRectangle(Rectangles, command);
                        break;

                    case "print":
                        PrintRectangles(Rectangles);
                        break;

                    case "help":
                        PrintHelp();
                        break;

                    default:
                        Console.WriteLine("Комманда некорректна");
                        break;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine($"Комманда некорректна:{e?.Message}");
            }
            return true;
        }

        static void GetIntersection(List<Rectangle> Rectangles, string[] command)
        {
            Rectangles.Add(Rectangles[Convert.ToInt32(command[1])].Intersection(Rectangles[Convert.ToInt32(command[2])]));
            Console.WriteLine(Rectangles.Last());
        }

        static void GetMinRectangle(List<Rectangle> Rectangles, string[] command)
        {
            Rectangles.Add(Rectangles[Convert.ToInt32(command[1])].Min(Rectangles[Convert.ToInt32(command[2])]));
            Console.WriteLine(Rectangles.Last());
        }

        static void AddNewRectangle(List<Rectangle> Rectangles, string[] command)
        {
            var tmp_args = Parse(command);
            Rectangles.Add(new Rectangle(tmp_args[0], tmp_args[1], tmp_args[2], tmp_args[3]));
        }

        static void ScaleRectangle(List<Rectangle> Rectangles, string[] command)
        {
            Rectangles.Add(
                Rectangles[Convert.ToInt32(command[1])]
                .Scale(
                    Convert.ToSingle(command[2]),
                    Convert.ToInt32(command[3])
                )
            );
        }

        static void MoveRectangle(List<Rectangle> Rectangles, string[] command)
        {
            Rectangles.Add(
                Rectangles[Convert.ToInt32(command[1])]
                .Move(
                    Convert.ToInt32(command[2]),
                    Convert.ToInt32(command[3])
                )
            );
        }

        static void PrintRectangles(List<Rectangle> Rectangles)
        {
            for (int i = 0; i < Rectangles.Count; i++)
            {
                Console.WriteLine($"rect №{i}\n{Rectangles[i]}");
                Console.WriteLine("---------------------------------");
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("Списко доступных комманд:" +
                "\nnew x0 y0 x1 y1 - создает новый прямоугольник с началом в точке {x0, y0} и с концом в точке {x1, y2}" +
                "\nmove rect_number x y - создает копию прямоугольника под номером rect_number и двигает её на x единиц по Ox, y по Oy" +
                "\nscale rect_number x y - создает копию прямоугольника под номером rect_number и увеличивает/уменьшает её в х раз по Ох, у по Оу" +
                "\nmin rect_number1 rect_number2 - создает наименьший прямоугольник, содержащий два заданных прямоугольника" +
                "\nint rect_number1 rect_number2 - создает прямоугольник, являющийся общей частью (пересечением) двух заданых прямоугольников" +
                "\nprint - печатает все прямоугольники" +
                "\nhelp - печатает список комманд" +
                "\nstop - заканчивает программу");
        }

        static float[] Parse(string[] coor)
        {
            var res = new float[coor.Length - 1];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = Convert.ToSingle(coor[i + 1]);
            }
            return res;
        }
    }
}
