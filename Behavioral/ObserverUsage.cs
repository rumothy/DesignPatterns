using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Intent: 
    /// Define a one-to-many dependency between objects so that when 
    /// one object changes state, all its dependents are notified and updated 
    /// automatically.
    /// 
    /// Applicability: 
    /// Use the Observer pattern in any of the following situataions:
    /// 1. When an abstraction has two aspects, one dependent on the other.
    /// 
    /// 2. When a change to one object requires changing others, and you don't
    /// know how many objects need to be changed. 
    /// 
    /// 3. When an object should be able to notify other objects without making
    /// assumptions about who these objects are. 
    /// </summary>
    public class ObserverUsage
    {
        public static void Run()
        {
            Console.WriteLine("ObserverUsage");
        }

        internal abstract class Observer
        {
            public abstract void Update(Subject subject);
        }

        internal class Subject
        {
            private List<Observer> _observers = new List<Observer>();

            public virtual void Attach(Observer observer)
            {
                _observers.Add(observer);
            }

            public virtual void Detach(Observer observer)
            {
                _observers.Remove(observer);
            }

            public virtual void Notify()
            {
                foreach (var observer in _observers)
                {
                    observer.Update(this);
                }
            }
        }

        class CteSubject : Subject
        {
            public virtual string State { get; private set; }

            public virtual void SetSubjectState(string newState)
            {
                Console.WriteLine($"Changing subject state from {State} to {newState}. Notifying Observers");
                State = newState;
                Notify();
            }
        }

        class CteObserver : Observer
        {
            private string _name;
            private string _observerState;

            public CteObserver(CteSubject subject, string name)
            {
                Subject = subject;
                _name = name;
            }
            public override void Update(Subject subject)
            {
                if (Subject == subject)
                {
                    _observerState = Subject.State;
                    Console.WriteLine($"\tObserver {_name}'s new state is {_observerState}");
                }
            }

            public virtual CteSubject Subject { get; set; }
        }

    }
}
