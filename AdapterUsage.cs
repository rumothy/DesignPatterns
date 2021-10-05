using System;
namespace DesignPatterns.Adapter
{
    /// <summary>
    /// Intent: Convert the interface of a class into another interface
    /// clients expect. Adapter lets classes work together that couldn't
    /// otherwise because of incompatible interfaces.
    ///
    /// Applicability:
    /// User the Adapter pattern when
    /// 1. you want to use an existing class, and its interface does not
    /// match the one you need.
    /// 2. you want to create a reusable class that that cooperates with
    /// unrlated or unforseen classes, that is, classes that don't
    /// necessarily have compatible interfaces.
    /// 3. (object adapter only) you need to use several existing subclasses,
    /// but it's impractical to adapt their interface by subclassing every
    /// one. An object adapter can adapt the interface of its parent class.
    /// </summary>
    public class AdapterUsage
    {
        public static void Run()
        {
            Target target = new Adapter();
            target.Request();
        }
    }

    abstract class Target
    {
        public abstract void Request();
    }

    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Adaptee.SpecificRequest");
        }
    }

    class Adapter : Target
    {
        Adaptee _adaptee = new();
        public override void Request()
        {
            _adaptee.SpecificRequest();
        }
    }
}
