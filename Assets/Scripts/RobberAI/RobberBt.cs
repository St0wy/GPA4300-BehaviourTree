using BehaviourTree.BehaviourTree;
using UnityEngine;
using UnityEngine.AI;
using Tree = BehaviourTree.BehaviourTree.Tree;

namespace BehaviourTree.RobberAI
{
    public class RobberBt : Tree
    {
        [SerializeField] private DisableBreakBehaviour[] windowsToPick;
        private DisableBreakBehaviour windowPicked;
        private NavMeshAgent navMeshAgent;

        protected new void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            base.Awake();
        }

        protected override Node SetupTree()
        {
            var goToHouse = new Sequence();

            var pickWindow = new Leaf(PickWindow);
            goToHouse.AddChild(pickWindow);

            var goToWindow = new Leaf(GoToWindow);
            goToHouse.AddChild(goToWindow);

            var breakWindow = new Leaf(BreakWindow);
            goToHouse.AddChild(breakWindow);

            return goToHouse;
        }

        private NodeState PickWindow()
        {
            if (windowsToPick.Length <= 0)
            {
                return NodeState.Failure;
            }

            windowPicked = windowsToPick[Random.Range(0, windowsToPick.Length)];
            return NodeState.Success;
        }

        private NodeState GoToWindow()
        {
            navMeshAgent.destination = windowPicked.transform.position;

            return navMeshAgent.remainingDistance <= Mathf.Epsilon ? NodeState.Success : NodeState.Running;
        }

        private NodeState BreakWindow()
        {
            windowPicked.Break();

            return NodeState.Success;
        }
    }
}