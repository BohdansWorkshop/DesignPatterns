using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ConcreteMediator();

            var participantA = new ConcreteParticipantA(mediator);
            var participantB = new ConcreteParticipantB(mediator);


            mediator.participantA = participantA;
            mediator.participantB = participantB;

            participantA.Send("Hi to ParticipantB from ParticipantA");
            Console.WriteLine();
            participantB.Send("Hi to ParticipantA from participantB");
        }
    }


    public abstract class Mediator
    {
        public abstract void Send(string message, Participant colleague);
    }

    public abstract class Participant
    {
        protected Mediator mediator;
        public Participant(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            Console.WriteLine($"{this.GetType()} sending message");
            mediator.Send(message, this);
        }

        public abstract void Notify(string message);
    }

    public class ConcreteParticipantA : Participant
    {
        public ConcreteParticipantA(Mediator mediator) : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Concrete Participant A has get notification: " + message);
        }
    }

    public class ConcreteParticipantB : Participant
    {
        public ConcreteParticipantB(Mediator mediator) : base(mediator)
        { }

        public override void Notify(string message)
        {
            Console.WriteLine("Concrete Participant B has get notification: " + message);
        }

    }


    public class ConcreteMediator : Mediator
    {
        public ConcreteParticipantA participantA;
        public ConcreteParticipantB participantB;

        public override void Send(string message, Participant colleague)
        {
            if (colleague == participantA)
            {
                participantB.Notify(message);
            }
            else
            {
                participantA.Notify(message);
            }
        }
    }

}
