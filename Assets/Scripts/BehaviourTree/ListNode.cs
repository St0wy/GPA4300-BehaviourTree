using System.Collections.Generic;

namespace BehaviourTree.BehaviourTree
{
    public abstract class ListNode : Node
    {
        protected readonly List<Node> children;

        public ListNode() : this(new List<Node>()) { }

        public ListNode(List<Node> children)
        {
            this.children = new List<Node>();
            foreach (Node child in children)
            {
                this.children.Add(child);
            }
        }

        public void AddChild(Node child)
        {
            children.Add(child);
        }
    }
}