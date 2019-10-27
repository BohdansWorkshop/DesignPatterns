using System;

namespace _5.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Proxy(null);
            subject.Request();
        }
    }

    #region UML Implementation

    abstract class Subject
    {
        public abstract void Request();
    }

    class ConcreteSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Subject received request");
        }
    }

    class Proxy : Subject
    {
        ConcreteSubject _subject;
        public Proxy(ConcreteSubject subject)
        {
            _subject = subject;
        }
        public override void Request()
        {
            if(_subject == null)
            {
                _subject = new ConcreteSubject();
            }
            _subject.Request();
        }
    }

    #endregion

}
