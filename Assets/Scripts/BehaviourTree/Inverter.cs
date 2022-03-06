namespace BehaviourTree
{
    public class Inverter : Node
    {
        public Inverter(Node child)
        {
            Child = child;
        }

        public Node Child { get; }

        public override NodeState Evaluate()
        {
            switch (Child.State)
            {
                case NodeState.Failure:
                    State = NodeState.Success;
                    return State;
                case NodeState.Success:
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