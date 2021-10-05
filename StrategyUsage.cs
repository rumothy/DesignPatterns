using System;

namespace DesignPatterns.Strategy
{
    /// <summary>
    /// Intent: Define a family of algorithms, encapsulate each one, and make them 
    /// interchangeable. Strategy lets the algorithm vary independently from clients 
    /// use it.
    /// 
    /// Applicability: Use the Strategy pattern when
    /// 1. many related classes differ only in their behavior.
    /// 2. you need different variants of an algorithm.
    /// 3. an algorithm uses data that clients shouldn't know about.
    /// 4. a class defines many behaviors, and these appear as multiple conditional
    /// statements in its operations.
    /// </summary>
    class StrategyUsage
    {

        public static void Run()
        {
            Context context = new Context(new CteStrategyA());
            context.ContextInterface();

            context = new Context(new CteStrategyB());
            context.ContextInterface();

            context = new Context(new CteStrategyC());
            context.ContextInterface();
        }
    }

    abstract class Strategy
    {
        public abstract void AlgorithmInterface();
    }

    class Context
    {
        private Strategy _strategy;

        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void ContextInterface()
        {
            _strategy.AlgorithmInterface();
        }
    }
    class CteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("CteStrategyA.AlgorithmInterface()");
        }
    }

    class CteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("CteStrategyB.AlgorithmInterface()");
        }
    }

    class CteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("CteStrategyC.AlgorithmInterface()");
        }
    }

}
