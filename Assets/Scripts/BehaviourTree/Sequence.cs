using System.Collections.Generic;

namespace BehaviourTree
{
    public class Sequence : ListNode
    {
        private int currentStep;
        
        public Sequence() { }
        public Sequence(List<Node> children) : base(children) { }

        public override NodeState Evaluate()
        {
            if (Children.Count <= 0)
            {
                State = NodeState.Success;
                return State;
            }

            Node currentNode = Children[currentStep];
            switch (currentNode.Evaluate())
            {
                case NodeState.Success:
                    currentStep++;
                    if (currentStep >= Children.Count)
                    {
                        currentStep = 0;
                        State = NodeState.Success;
                        return State;
                    }
                    else
                    {
                        State = NodeState.Running;
                        return State;
                    }
                case NodeState.Failure:
                    State = NodeState.Failure;
                    return State;
                case NodeState.Running:
                    State = NodeState.Running;
                    return State;
                default:
                    State = NodeState.Success;
                    return State;
            }
        }
    }
}