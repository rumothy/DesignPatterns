using System;
using System.Collections.Generic;

namespace DesignPatterns.Visitor
{
    /// <summary>
    /// Intent: Represent an operation to be performed on the elemnts of an
    /// object structure. Visitor lets you define a new operation without
    /// changing the classes of the elements on which it operates.
    ///
    /// Applicability: User the Visitor pattern when
    /// 1. an object structure contains many classes of objects with differing
    /// interfaces, and you want to perform operations on these objects that
    /// depend on their concrete classes.
    /// 2. many distinct and unrealated operations need to be performed on
    /// objects in an object structure, and you want to avoid "polluting" their
    /// classes with these operations.
    /// 3. the classes defining the object structure rarely change, but you
    /// often want define new operations over the structure.
    /// </summary>
    public class VisitorUsage
    {
        public static void Run()
        {
            ObjectStructure o = new();
            CteElementA ca = new();
            CteElementB cb = new();
            o.Attach(ca);
            o.Attach(cb);

            CteVisitor1 v1 = new();
            CteVisitor2 v2 = new();

            o.Accept(v1);
            o.Accept(v2);

            o.Detach(ca);
        }
    }

    abstract class Visitor
    {
        public abstract void VisitConcreteElementA(CteElementA a);
        public abstract void VisitConcreteElementB(CteElementB b);
    }

    class CteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(CteElementA a)
        {
            Console.WriteLine($"{a.GetType()} visited by {this.GetType()}");
        }

        public override void VisitConcreteElementB(CteElementB b)
        {
            Console.WriteLine($"{b.GetType()} visited by {this.GetType()}");
        }
    }

    class CteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(CteElementA a)
        {
            Console.WriteLine($"{a.GetType()} visited by {this.GetType()}");
        }

        public override void VisitConcreteElementB(CteElementB b)
        {
            Console.WriteLine($"{b.GetType()} visited by {this.GetType()}");
        }
    }

    abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }

    class CteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }
    }

    class CteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }
    }

    class ObjectStructure
    {
        readonly List<Element> _elements = new();

        public virtual void Attach(Element e)
        {
            _elements.Add(e);
        }

        public virtual void Detach(Element e)
        {
            _elements.Remove(e);

        }

        public virtual void Accept(Visitor v)
        {
            foreach (var element in _elements)
            {
                element.Accept(v);
            }
        }
    }
}
