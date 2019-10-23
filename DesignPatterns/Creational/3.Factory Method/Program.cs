using System;

namespace _3.Factory_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            var pistolDeveloper = new PistolDeveloper();
            pistolDeveloper.CreateWeapon();

            var rifleDeveloper = new RifleDeveloper();
            rifleDeveloper.CreateWeapon();

            Console.ReadLine();
        }


        #region UML implementation
        abstract class Product { }

        class ConcreteProductA : Product { }
        class ConcreteProductB : Product { }

        abstract class Creator 
        {
            public abstract Product FactoryMethod();
        }
        class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductA();
            }
        }

        class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductB();
            }
        }
        #endregion

        #region Custom Implementation
        public abstract class WeaponCompany
        {
            //public string Name { get; set; }

            //public WeaponCompany(string name)
            //{
            //    this.Name = name;
            //}

            public abstract Weapon CreateWeapon();
        }

        public class RifleDeveloper : WeaponCompany
        {
            public override Weapon CreateWeapon()
            {
                return new Rifle();
            }
        }

        public class PistolDeveloper : WeaponCompany
        {
            public override Weapon CreateWeapon()
            {
                return new Pistol();
            }
        }

        public abstract class Weapon { }

        public class Pistol : Weapon
        {
            public Pistol()
            {
                Console.WriteLine("Pistol has created");
            }
        }


        public class Rifle : Weapon
        {
            public Rifle()
            {
                Console.WriteLine("Rifle has created");
            }
        }
        #endregion


    }
}
