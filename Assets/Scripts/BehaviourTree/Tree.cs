using System;
using UnityEngine;

namespace BehaviourTree.BehaviourTree
{
    public abstract class Tree : MonoBehaviour
    {
        private Node root;

        protected  void Awake()
        {
            root = SetupTree();
        }

        private void Update()
        {
            root?.Evaluate();
        }

        protected abstract Node SetupTree();
    }
}