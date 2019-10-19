using System;
using System.Collections.Generic;

namespace _6.Visitor
{
    public class Program
    {
        static void Main()
        {
            var objectStructure = new ObjectStructure();
            var first = new ElementA("Adam, Element A");
            var second = new ElementB("Benny, Element B");

            objectStructure.Add(first);
            objectStructure.Add(second);

            var firstVisitor = new ConcreteVisitorA();
            var secondVisitor = new ConcreteVisitorB();

            objectStructure.Accept(firstVisitor);
            Console.WriteLine();
            objectStructure.Accept(secondVisitor);

        }
    }


    public class ObjectStructure
    {
        List<IElementInterface> _elements = new List<IElementInterface>();

        //if we want to restrict access for some visitors
        //List<IVisitor> bannedVisitors = new List<IVisitor>() { new ConcreteVisitorB() };

        public void Add(IElementInterface element)
        {
            _elements.Add(element);
        }

        public void Remove(IElementInterface element)
        {
            _elements.Remove(element);
        }

        public void Accept(IVisitor visitor)
        {
            //check if visitor has appropriate access

            //if (!bannedVisitors.Any(x => x.GetType() == visitor.GetType()))
            //{
                foreach (var item in _elements)
                {
                    item.Accept(visitor);
                }
            //}
        }
    }

    public interface IElementInterface
    {
        void Accept(IVisitor visitor);
    }

    public class ElementA : IElementInterface
    {
        public string Name { get; set; }

        public ElementA(string name)
        {
            this.Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitElementA(this);
        }
    }

    public class ElementB : IElementInterface
    {
        public string Name { get; set; }

        public ElementB(string name)
        {
            this.Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitElementB(this);
        }
    }

    public interface IVisitor
    {
        void VisitElementA(ElementA elementA);
        void VisitElementB(ElementB elementB);
    }

    public class ConcreteVisitorA : IVisitor
    {
        public void VisitElementA(ElementA elementA)
        {
            Console.WriteLine($"ConcreteVisitorA visited {elementA.Name}");
        }

        public void VisitElementB(ElementB elementB)
        {
            Console.WriteLine($"ConcreteVisitorA visited {elementB.Name}");
        }
    }

    public class ConcreteVisitorB : IVisitor
    {
        public void VisitElementA(ElementA elementA)
        {
            Console.WriteLine($"ConcreteVisitorB visited {elementA.Name}");
        }

        public void VisitElementB(ElementB elementB)
        {
            Console.WriteLine($"ConcreteVisitorB visited {elementB.Name}");
        }
    }
}
