using System;

namespace _1.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            var drink = new Drink();
            drink.UseDrink();

            var juice = new Juice();
            //juice.DrinkJuice();

            var adapted = new JuiceToDrink(juice);
            adapted.UseDrink();
        }
    }

    #region UML Implementation

    class Client
    {
        void Main()
        {
            Target target = new Adapter();
            target.TargetRequest();
        }
    }
    //class which needs to be adapted;
    class Adaptee
    {
        public void AdapteeRequest()
        {

        }
    }

    //the destination of adaptation process
    class Target
    {
        public virtual void TargetRequest()
        {

        }
    }

    class Adapter : Target
    {
        Adaptee _adaptee = new Adaptee();

        public override void TargetRequest()
        {
            _adaptee.AdapteeRequest();
        }

    }

    #endregion

    #region Custom Implementation

    public interface IDrink
    {
        void UseDrink();
    }

    public class Drink : IDrink
    {
        public void UseDrink()
        {
            Console.WriteLine("Drink default drink");
        }
    }

    public interface IJuice
    {
        void DrinkJuice();
    }

    public class Juice : IJuice
    {
        public void DrinkJuice()
        {
            Console.WriteLine("Drink Juice");
        }
    }


    public class JuiceToDrink : IDrink
    {
        IJuice _juice;
        public JuiceToDrink(Juice juice)
        {
            _juice = juice;
        }

        public void UseDrink()
        {
            Console.WriteLine("Adapted juice to drink");
            _juice.DrinkJuice();
        }
    }


    #endregion
}
