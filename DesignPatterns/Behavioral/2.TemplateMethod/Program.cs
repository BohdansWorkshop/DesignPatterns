using System;

namespace _2.TemplateMethod
{
    public class Program
    {

        static void Main()
        {
            var concreteClassA = new ConcreteClassA();
            concreteClassA.FirstOperation();
            concreteClassA.SecondOperation();

            Console.WriteLine(new String('*', 20));

            var concreteClassB = new ConcreteClassB();
            concreteClassB.FirstOperation();
            concreteClassB.SecondOperation();
        }
    }


    public abstract class AbstractClass
    {
        public abstract void FirstOperation();
        public abstract void SecondOperation();
    }


    public class ConcreteClassA : AbstractClass
    {
        public override void FirstOperation()
        {
            Console.WriteLine($"{this.GetType().Name} performing First Operation.");
        }

        public override void SecondOperation()
        {
            Console.WriteLine($"{this.GetType().Name} performing Second Operation.");
        }
    }

    public class ConcreteClassB : AbstractClass
    {
        public override void FirstOperation()
        {
            Console.WriteLine($"{this.GetType().Name} performing First Operation.");
        }

        public override void SecondOperation()
        {
            Console.WriteLine($"{this.GetType().Name} performing Second Operation.");
        }
    }
}

