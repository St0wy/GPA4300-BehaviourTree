using System.Collections.Generic;

namespace BehaviourTree.BehaviourTree
{
    public class Sequence : ListNode
    {
        public Sequence() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            var isAnyChildRunning = false;

            foreach (Node child in children)
            {
                switch (child.Evaluate())
                {
                    case NodeState.Failure:
                        State = NodeState.Failure;
                        return State;
                    case NodeState.Success:
                        continue;
                    case NodeState.Running:
                        isAnyChildRunning = true;
                        continue;
                    default:
                        State = NodeState.Success;
                        return State;
                }
            }

            State = isAnyChildRunning ? NodeState.Running : NodeState.Success;
            return State;
        }
    }
}