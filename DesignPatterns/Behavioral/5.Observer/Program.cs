using System;
using System.Collections.Generic;

namespace _5.Observer
{
    // remember about possibility of memory leaks in this pattern;
    class Program
    {
        static void Main()
        {
            var shakhid = new Shakhid("Mahmed");
            var firstSpy = new Spy("Eagle");
            var secondSpy = new Spy("Polar Bear");


            shakhid.AddObserver(firstSpy);
            shakhid.AddObserver(secondSpy);

            shakhid.NotifyAboutMoving();
            Console.WriteLine();
            shakhid.NotifyAboutSmoking();
        }
    }

    public interface IObservable
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyAboutMoving();
        void NotifyAboutSmoking();
    }


    public interface IObserver
    {
        void Notify(string about);
    }


    public class Shakhid : IObservable
    {
        private List<IObserver> _observers;
        public Shakhid(string name)
        {
            _observers = new List<IObserver>();
            Name = name;
        }
        public string Name { get; set; }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyAboutMoving()
        {
            foreach (var item in _observers)
            {
                item.Notify($"Shakhid {Name} is on moving.");
            }
        }

        public void NotifyAboutSmoking()
        {
            foreach (var item in _observers)
            {
                item.Notify($"Shakhid {Name} smoking.");
            }
        }
    }

    public class Spy : IObserver
    {
        public string Name { get; set; }
        public Spy(string name)
        {
            Name = name;
        }

        public void Notify(string about)
        {
            Console.WriteLine($"{Name} notified about {about}");
        }
    }
}