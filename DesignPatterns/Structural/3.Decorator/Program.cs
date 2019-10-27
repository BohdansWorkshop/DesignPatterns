using System;

namespace _3.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var newComponent = new ConcreteComponent();

            var componentDecorator = new ConcreteDecorator(newComponent);

            componentDecorator.Operation();
        }
    }

    public abstract class Component
    {
        public abstract void Operation();
    }

    public class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent performing operation");
        }
    }


    public abstract class Decorator : Component
    {
        Component _decoratee;
        public Decorator(Component component)
        {
            _decoratee = component;
        }
        public abstract void AddedOperation();

        public void DecoratorOperation()
        {
            _decoratee.Operation();
            AddedOperation();
        }
    }


    public class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(Component component) : base(component)
        {
        }

        public override void AddedOperation()
        {
            Console.WriteLine("Decorator's added operation");
        }

        public override void Operation()
        {
            base.DecoratorOperation();
        }
    }
}
