using System;

namespace _2.Abstract_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            //UML Implementation client
            //var firstclient = new Client(new ConcreteFactoryA());
            //firstclient.DoAWork();
            //firstclient.DoBWork();

            //var secondclient = new Client(new ConcreteFactoryB());
            //secondclient.DoAWork();
            //secondclient.DoBWork();


            //Custom implementation client
            var firstBeast = new Beast(new DarkBeast());
            firstBeast.HearVoice();
            firstBeast.BeholdAura();


            var secondBeast = new Beast(new LightBeast());
            secondBeast.HearVoice();
            secondBeast.BeholdAura();

        }
    }

    #region UML Implementation
    public abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }


    public class ConcreteFactoryA : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactoryB : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    public abstract class AbstractProductA
    {
        public abstract void ProductAWork();
    }

    public abstract class AbstractProductB
    {
        public abstract void ProductBWork();
    }

    public class ProductA1 : AbstractProductA
    {
        public override void ProductAWork()
        {
            Console.WriteLine("ProductA1 execituing ProductAWork");
        }
    }

    public class ProductA2 : AbstractProductA
    {
        public override void ProductAWork()
        {
            Console.WriteLine("ProductA2 execituing ProductAWork");
        }
    }

    public class ProductB1 : AbstractProductB
    {
        public override void ProductBWork()
        {
            Console.WriteLine("ProductB1 executing ProductBWork");
        }
    }

    public class ProductB2 : AbstractProductB
    {
        public override void ProductBWork()
        {
            Console.WriteLine("ProductB2 execituing ProductBWork");
        }
    }

    public class Client
    {
        AbstractProductA _abstractProductA;
        AbstractProductB _abstractProductB;

        public Client(AbstractFactory factory)
        {
            _abstractProductA = factory.CreateProductA();
            _abstractProductB = factory.CreateProductB();
        }

        public void DoAWork()
        {
            _abstractProductA.ProductAWork();
        }

        public void DoBWork()
        {
            _abstractProductB.ProductBWork();
        }
    }
    #endregion


    #region CustomImplementation
    
    public abstract class BeastFactory
    {
        public abstract Voice GetVoice();
        public abstract Aura GetAura();
    }

    public class DarkBeast : BeastFactory
    {
        public override Aura GetAura()
        {
            return new DarkAura();
        }

        public override Voice GetVoice()
        {
            return new DarkVoice();
        }
    }

    public class LightBeast : BeastFactory
    {
        public override Aura GetAura()
        {
            return new LightAura();
        }

        public override Voice GetVoice()
        {
            return new LightVoice();
        }
    }


    public abstract class Voice
    {
        public abstract void MakeSound();
    }

    public abstract class Aura
    {
        public abstract void Shine();
    }


    public class DarkVoice : Voice
    {
        public override void MakeSound()
        {
            Console.WriteLine("Makes dark and deep sounds");
        }
    }

    public class LightVoice : Voice
    {
        public override void MakeSound()
        {
            Console.WriteLine("Makes light and ringing sounds");
        }
    }


    public class DarkAura : Aura
    {
        public override void Shine()
        {
            Console.WriteLine("Shines with a dark light");
        }
    }

    public class LightAura : Aura
    {
        public override void Shine()
        {
            Console.WriteLine("Shines with a light light");
        }
    }

    public class Beast
    {
        private Voice _voice;
        private Aura _aura;

        public Beast(BeastFactory factory)
        {
            _voice = factory.GetVoice();
            _aura = factory.GetAura();
        }

        public void HearVoice()
        {
            _voice.MakeSound();
        }

        public void BeholdAura()
        {
            _aura.Shine();
        }
    }

    #endregion


}
