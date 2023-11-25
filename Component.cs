using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp18_11
{
    public abstract class Component
    {
        public abstract void AddComponent(Component component);
        public abstract string Operation();
    }

    public class Composite : Component
    {
        private char _data;
        private List<Component> _children = new List<Component>();

        public Composite(char data)
        {
            _data = data;
        }

        public override void AddComponent(Component component) => _children.Add(component);

        public override string Operation()
        {
            return $"({_data} [{String.Join(", ", _children.Select(c => c.Operation()).ToArray())}])";
        }
    }
    
    public class Leaf : Component
    {
        private char _data;
        private List<Component> _children = new List<Component>();

        public Leaf(char data)
        {
            _data = data;
        }

        public override void AddComponent(Component component) {}

        public override string Operation()
        {
            return _data.ToString();
        }
    }
}