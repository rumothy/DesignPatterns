using System;

namespace DesignPatterns.Singleton
{

    /// <summary>
    /// Intent: Ensure a class only has one instance and provide a global point of access to it.
    ///
    /// Applicability:
    /// Use the Singleton pattern when
    /// - there must be exactly one instance of a class, and it must be accessible to
    /// client from a well known access point.
    /// - when the sole instance should be extensible by subclassing, and clients
    /// should be able to use an extended instance without modifying their code. 
    /// </summary>
    class SingletonUsage
    {
        public static void Run()
        {
            Singleton instA = Singleton.Instance();
            Singleton instB = Singleton.Instance();
            Console.WriteLine($"{instA.GetHashCode()} {instB.GetHashCode()}");           
        }
    }

    class Singleton
    {
        private static Singleton _instance;

        public static Singleton Instance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }

        protected Singleton()
        {
        }
    }
    
}