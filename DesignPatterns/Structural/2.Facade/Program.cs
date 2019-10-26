using System;

namespace _2.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new Facade();
            facade.OperationA();
            facade.OperationB();
        }
    }

    public class ComponentA
    {
        public void DoWork()
        {
            Console.WriteLine("ComponentA doing it's work");
        }
    }

    public class ComponentB
    {
        public void DoWork()
        {
            Console.WriteLine("ComponentB doing it's work");
        }
    }

    public class ComponentC
    {
        public void DoWork()
        {
            Console.WriteLine("ComponentC doing it's work");
        }
    }

    public class Facade
    {
        private readonly ComponentA _componentA;
        private readonly ComponentB _componentB;
        private readonly ComponentC _componentC;

        //initializing components
        public Facade()
        {
            _componentA = new ComponentA();
            _componentB = new ComponentB();
            _componentC = new ComponentC();
        }


        public void OperationA()
        {
            _componentA.DoWork();
            _componentB.DoWork();
        }

        public void OperationB()
        {
            _componentC.DoWork();
        }
    }
}
