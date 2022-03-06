using System.Collections;
using System.Collections.Generic;

namespace BehaviourTree
{
    public abstract class ListNode : Node, IEnumerable<Node>
    {
        protected readonly List<Node> Children;

        public ListNode() : this(new List<Node>()) { }

        public ListNode(List<Node> children)
        {
            this.Children = new List<Node>();
            foreach (Node child in children)
            {
                this.Children.Add(child);
            }
        }

        public void Add(Node child)
        {
            Children.Add(child);
        }

        public IEnumerator<Node> GetEnumerator() => Children.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}