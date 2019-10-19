using System;

namespace _1.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            var strategyCommander = new Strategy();

            //Here's we chosing algorithm of ConcreteStrategyA class to use.
            strategyCommander.concreteStrategy = new ConcreteStrategyA();
            strategyCommander.DoSomeJob();

            strategyCommander.concreteStrategy = new ConcreteStrategyB();
            strategyCommander.DoSomeJob();

        }
    }


    public interface IStrategy
    {
        void DoSomeJob();
    }

    public class Strategy
    {
        public IStrategy concreteStrategy;
        public void DoSomeJob()
        {
            concreteStrategy.DoSomeJob();
        }
    }


    public class ConcreteStrategyA : IStrategy
    {
        public void DoSomeJob()
        {
            Console.WriteLine("Concrete Strategy A works.");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void DoSomeJob()
        {
            Console.WriteLine("Concrete Strategy B works.");
        }
    }
}
