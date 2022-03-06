using BehaviourTree;
using UnityEngine;
using UnityEngine.AI;

namespace RobberAI
{
    public class RobberBt : BTree
    {
        [SerializeField] private DisableBreakBehaviour[] windowsToPick;
        [SerializeField] private float minDistanceToWindows = 0.1f;
        [SerializeField] private DisableBreakBehaviour diamond;
        [SerializeField] private Transform carPos;

        private DisableBreakBehaviour windowPicked;
        private NavMeshAgent navMeshAgent;

        private bool stoleDiamond;

        protected new void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            base.Awake();
        }

        protected override Node SetupTree()
        {
            var stealDiamond = new Selector();

            var pickWindow = new Sequence
            {
                new Inverter(new Leaf(IsWindowPicked)),
                new Leaf(PickWindow),
            };
            stealDiamond.Add(pickWindow);
            stealDiamond.Add(new Sequence
            {
                new Leaf(() => stoleDiamond ? NodeState.Failure : NodeState.Success),
                new Leaf(GoToWindow),
                new Leaf(BreakWindow),
                new Leaf(GoToDiamond),
                new Leaf(StealDiamond)
            });

            var gotoCar = new Sequence
            {
                new Leaf(() => !stoleDiamond ? NodeState.Failure : NodeState.Success),
                new Leaf(GoToCar),
            };
            stealDiamond.Add(gotoCar);

            return stealDiamond;
        }

        private NodeState GoToCar()
        {
            Vector3 position = carPos.position;
            navMeshAgent.destination = position;

            float distance = Vector3.Distance(position, transform.position);

            return distance <= minDistanceToWindows
                ? NodeState.Success
                : NodeState.Running;
        }

        private NodeState StealDiamond()
        {
            diamond.Break();
            stoleDiamond = true;
            return NodeState.Success;
        }

        private NodeState GoToDiamond()
        {
            navMeshAgent.destination = diamond.BreakPoint.position;

            float distance = Vector3.Distance(diamond.transform.position, transform.position);

            return distance <= diamond.DistanceToBreakPoint + minDistanceToWindows
                ? NodeState.Success
                : NodeState.Running;
        }

        private NodeState IsWindowPicked() => windowPicked != null ? NodeState.Success : NodeState.Failure;

        private NodeState PickWindow()
        {
            if (windowPicked != null || windowsToPick.Length <= 0)
            {
                return NodeState.Failure;
            }

            windowPicked = windowsToPick[Random.Range(0, windowsToPick.Length)];
            return NodeState.Success;
        }

        private NodeState GoToWindow()
        {
            navMeshAgent.destination = windowPicked.BreakPoint.position;

            float distance = Vector3.Distance(windowPicked.transform.position, transform.position);

            return distance <= windowPicked.DistanceToBreakPoint + minDistanceToWindows
                ? NodeState.Success
                : NodeState.Running;
        }


        private NodeState BreakWindow()
        {
            if (windowPicked == null)
            {
                return NodeState.Failure;
            }

            windowPicked.Break();

            return NodeState.Success;
        }
    }
}