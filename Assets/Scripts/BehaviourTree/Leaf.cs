using System;
using System.Diagnostics;

namespace BehaviourTree.BehaviourTree
{
    public class Leaf : Node
    {
        public delegate NodeState LeafDelegate();

        private LeafDelegate action;

        public Leaf(LeafDelegate action)
        {
            this.action = action;
        }

        public override NodeState Evaluate()
        {
            switch (action())
            {
                case NodeState.Failure:
                    State = NodeState.Failure;
                    return State;
                case NodeState.Success:
                    State = NodeState.Success;
                    return State;
                case NodeState.Running:
                    State = NodeState.Running;
                    return State;
                default:
                    State = NodeState.Failure;
                    return State;
            }
        }
    }
}