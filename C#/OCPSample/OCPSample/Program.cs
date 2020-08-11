using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// OCP란 Open Close Priciple의 약자이며 이는 상속에 개방적이며 변경에 폐쇠적임을 뜻한다.
/// 
/// 결국에는 한 클래스당 하나의 기능을 가지도록 분리하면 되려나ㅏ?
/// </summary>
namespace OCPSample
{

    enum Size
    {
        Small, Medium, Large
    }
    enum Color
    {
        Red, Orange, Green
    }

    class Product
    {
        public string Name { get; set; }
        public Size Size { get; set; }
        public Color Color { get; set; }

        public Product(string name, Size size, Color color)
        {
            this.Name = name;
            this.Size = size;
            this.Color = color;
        }
    }

    interface ISpecification<T>
    {
        bool IsEqual(T t);
    }

    class SizeSpecification : ISpecification<Product>
    {
        private Size _size;

        public SizeSpecification(Size size)
        {
            _size = size;
        }

        public bool IsEqual(Product t) => _size == t.Size;
    }
    class ColorSpecification : ISpecification<Product>
    {
        private Color _color;

        public ColorSpecification(Color color)
        {
            this._color = color;    
        }

        public bool IsEqual(Product t) => _color == t.Color;
    }

    class ProductFilter
    {
        public IEnumerable<Product> Filtering(IEnumerable<Product> items, ISpecification<Product> specification)
        {
            foreach(var p in items)
            {
                if (specification.IsEqual(p))
                    yield return p;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Product("windows", Size.Large, Color.Green);
            var p2 = new Product("linux", Size.Large, Color.Orange);
            var p3 = new Product("unix", Size.Large, Color.Orange);
            var p4 = new Product("mac", Size.Small, Color.Red);

            var items = new Product[] { p1, p2, p3, p4 };

            var pf = new ProductFilter();

            foreach(var p in pf.Filtering(items, new ColorSpecification(Color.Orange)))
            {
                Console.WriteLine($" Name: {p.Name} - Size: {p.Size} - Color: {p.Color}");
            }
        }
    }
}
