using System;
using DesignPatterns.Singleton;
using DesignPatterns.Strategy;
using DesignPatterns.Structural.Decorator;
using DesignPatterns.Structural.Facade;
using DesignPatterns.Visitor;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingletonUsage.Run();
            //VisitorUsage.Run();
            //StrategyUsage.Run();
            //FacadeClient.Run();
            DecoratorUsage.Run();
        }
    }
}
