using System.Transactions;
using BehaviourTree.BehaviourTree;
using UnityEngine;

namespace BehaviourTree.RobberAI
{
    public class FindHouse : Node
    {
        private Transform robberTransform;
        private Transform houseTransform;

        public FindHouse(Transform robberTransform, Transform houseTransform)
        {
            this.robberTransform = robberTransform;
            this.houseTransform = houseTransform;
        }

        public override NodeState Evaluate()
        {
            robberTransform.LookAt(houseTransform);

            State = NodeState.Running;
            return State;
        }
    }
}