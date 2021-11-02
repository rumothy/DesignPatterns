using System;

namespace DesignPatterns.Structural.Decorator
{
    public class DecoratorUsage
    {
        public static void Run()
        {
            CteComponent component = new CteComponent();
            CteDecoratorA decoratorA = new CteDecoratorA();
            CteDecoratorB decoratorB = new CteDecoratorB();

            decoratorA.SetComponent(component);
            decoratorB.SetComponent(decoratorA);

            decoratorB.Operation();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

    class CteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("CteComponent.Operation()");
        }
    }

    abstract class Decorator : Component
    {
        protected Component _component;
        public override void Operation()
        {
            if (_component != null)
                _component.Operation();
        }

        public virtual void SetComponent(Component component)
        {
            _component = component;
        }
    }

    internal class CteDecoratorA : Decorator
    {
        string _addedState;
        public override void Operation()
        {
            base.Operation();
            _addedState = "new-state";
            AddedBehavior();
        }

        public virtual void AddedBehavior()
        {
            Console.WriteLine("CetDecoratorA.AddedBehavior()");
        }
    }

    internal class CteDecoratorB : Decorator
    {
        string _addedState;
        public override void Operation()
        {
            base.Operation();
            _addedState = "new-state";
            AddedBehavior();
        }

        public virtual void AddedBehavior()
        {
            Console.WriteLine("CetDecoratorB.AddedBehavior()");
        }
    }
}
