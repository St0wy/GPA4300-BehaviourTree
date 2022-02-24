using System.Collections.Generic;

namespace BehaviourTree.BehaviourTree
{
    [System.Serializable]
    public abstract class Node
    {
        // protected Node parent;
        // private Dictionary<string, object> dataContext;

        public Node()
        {
            // dataContext = new Dictionary<string, object>();
        }

        public NodeState State { get; protected set; }

        public abstract NodeState Evaluate();

        // public void SetData(string key, object value)
        // {
        //     dataContext[key] = value;
        // }
        //
        // public object GetData(string key)
        // {
        //     if (dataContext.TryGetValue(key, out object value)) return value;
        //
        //     Node node = parent;
        //     while (node != null)
        //     {
        //         value = node.GetData(key);
        //         if (value != null)
        //         {
        //             return value;
        //         }
        //
        //         node = node.parent;
        //     }
        //
        //     return null;
        // }
        //
        // public bool ClearData(string key)
        // {
        //     if (dataContext.ContainsKey(key))
        //     {
        //         dataContext.Remove(key);
        //         return true;
        //     }
        //
        //     Node node = parent;
        //
        //     while (node != null)
        //     {
        //         bool cleared = node.ClearData(key);
        //         if (cleared)
        //         {
        //             return true;
        //         }
        //
        //         node = node.parent;
        //     }
        //
        //     return false;
        // }
    }
}