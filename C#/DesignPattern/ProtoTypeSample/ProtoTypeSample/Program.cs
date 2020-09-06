 using System;

namespace ProtoTypeSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Line line = new Line();
            line.Start = new Point() {X=1, Y=2 };
            line.End = new Point() { X = 3, Y = 4 };

            Console.WriteLine(line);

            var tt = line.DeepCopy();
            var shalow = line;
            shalow.Start.X = 10;
            tt.Start.X = 15;

            Console.WriteLine(line);
            Console.WriteLine(shalow);
            Console.WriteLine(tt);
        }
    }
}
