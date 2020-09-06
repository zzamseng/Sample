using System;
using System.IO;
using System.Xml.Serialization;

namespace ProtoTypeSample
{
    public static class DeepCopyExtention
    {
        public static T DeepCopy<T>(this T self)
        {
            using(var ms = new MemoryStream())
            {
                var x = new XmlSerializer(typeof(T));
                x.Serialize(ms, self);
                ms.Position = 0;

                var tmp = x.Deserialize(ms);

                return (T)tmp;
            }
        }
    }


    public class Point
    {
        public int X, Y;
    }

    public class Line
    {
        public Point Start, End;

        public Line DeepCopy()
        {
            return this.DeepCopy<Line>();
        }

        public override string ToString()
        {
            return $"{Start.X} / {Start.Y} ,, {End.X} / {End.Y}";
        }
    }
}
