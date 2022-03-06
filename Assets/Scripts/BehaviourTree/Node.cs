using System;

namespace BehaviourTree
{
    [Serializable]
    public abstract class Node
    {
        public NodeState State { get; protected set; }

        public abstract NodeState Evaluate();
    }
}