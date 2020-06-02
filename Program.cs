using System;

namespace practica10
{
    class Program
    {
        static double InputNum()
        {
            double num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = double.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
            } while (!ok);

            return num;

        }
        static int InputInt()
        {
            int num;
            string input;
            bool ok;
            do
            {
                input = Console.ReadLine();
                ok = int.TryParse(input, out num);
                if (!ok) Console.WriteLine("Некорректный ввод");
                else if (num < 1 ) Console.WriteLine($"Некорректный ввод. Введите натуральное число");
            } while (!ok || num < 1 );

            return num;

        }
        static void Main(string[] args)
        {
            bool change = false;
            double aNext;
            string output="";
            ListOne<double> list = new ListOne<double>();
            ListOne<double> listNoChange = new ListOne<double>();
            Console.WriteLine($"Введите n");
            int n = InputInt();
            Console.WriteLine($"Введите a1");
            double a = InputNum();
            list.AddReverse(a);
            listNoChange.Add(a);
            output += a + "\n";
            if (n == 1)
            {
                Console.WriteLine("Последовательность:");
                Console.WriteLine(a);
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    Console.WriteLine($"Введите a{i}");
                    aNext = InputNum();
                    if (aNext < a) change = true;
                    a = aNext;
                    list.AddReverse(a);
                    if(!change) listNoChange.Add(a);
                }
                Console.WriteLine("Последовательность:");
                if (change) list.ShowList();
                else listNoChange.ShowList();

            }

        }
        public class Point<T>
        {
            public T Data { get; set; }
            public Point<T> Next { get; set; }

            public Point()
            {
                Next = null;
                Data = default(T);
            }

            public Point(T data)
            {
                Data = data;
                Next = null;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }
        public class ListOne<T>
        {
            public Point<T> Beg { get; set; }

            public ListOne()
            {
                Beg = null;
            }
            public ListOne(T d)
            {
                Beg = new Point<T>(d);
            }
            public void AddReverse(T d)
            {
                if (Beg == null)
                {
                    Beg = new Point<T>(d);
                }
                else
                {
                    Point<T> p = new Point<T>(d);
                    p.Next = Beg;
                    Beg = p;
                }
            }
            public void Add(T d)
            {
                Point<T> NewPoint = new Point<T>(d);
                if (Beg == null)
                {
                    Beg = NewPoint;
                }
                else
                {
                    Point<T> p = Beg;
                    while (p.Next != null)
                    {
                        p = p.Next;
                    }
                    p.Next = NewPoint;
                    
                    
                }
            }

            public void ShowList()
            {
                if (Beg == null)
                {
                    Console.WriteLine("Коллекция пуста");
                    return;
                }
                else
                {
                    Point<T> p = Beg;
                    while (p != null)
                    {
                        Console.WriteLine(p);
                        p = p.Next;
                    }
                    Console.WriteLine();
                }
            }

        }
    }
}
