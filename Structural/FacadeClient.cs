using System;

namespace DesignPatterns.Structural.Facade
{

    /// <summary>
    /// Facade
    /// Intent: Provide a unified interface to a set of interfaces in a subsystem.
    /// Facade defines a higher-level interface that makes the subsystem easier to use.
    /// 
    /// Applicability: 
    /// Use the Facade pattern when 
    /// 1. you want to provide a simple interface to a complex subsystem. Sybsystems
    /// often get more complex as they evolve. Most patterns, when applied, result in
    /// more and smaller classes. This makes the subsystem more reusable and easier to
    /// customize, but it also becomes harder to use for clients that don't need to 
    /// customze it. A facade can provide a simple default view of the subsystem that
    /// is good enough for most clients. Only clients needing more customizability will
    /// need to look beyond the facade.
    /// 2. there are many dependencies between clients and the implementation classes
    /// of an abstraction. Introduce a facade to decouple the subsystem from clients
    /// and other subsystems, thereby promoting subsystem independence and portability.
    /// 3. you want to layer your subsystems. Use a facade to define an entry point
    /// to each subsystem level. If subsystems are dependent, then you can simplify
    /// the dependencies between them by making them communicate with each other 
    /// solely through their facades.
    /// </summary>
    
    using LibraryWithFacade;
    public class FacadeClient
    {
        public static void Run()
        {
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
        }
    }

}

namespace LibraryWithFacade
{ 
    class SubsystemOne
    {
        public void MethodOne()
        {
            Console.WriteLine("Sys1");
        }
    }

    class SubsystemTwo
    {
        public void MethodTwo()
        {
            Console.WriteLine("Sys2");
        }
    }

    class SubsystemNnn
    {
        public void MethodNnn()
        {
            Console.WriteLine("SysN");
        }
    }

    public class Facade
    {
        private SubsystemOne _sysOne;
        private SubsystemTwo _sysTwo;
        private SubsystemNnn _sysNnn;

        public Facade()
        {
            _sysOne = new SubsystemOne();
            _sysTwo = new SubsystemTwo();
            _sysNnn = new SubsystemNnn();
        }

        public virtual void MethodA()
        {
            _sysOne.MethodOne();
            _sysTwo.MethodTwo();
            _sysNnn.MethodNnn();
        }

        public virtual void MethodB()
        {
            _sysNnn.MethodNnn();
            _sysTwo.MethodTwo();
        }
    }
}
