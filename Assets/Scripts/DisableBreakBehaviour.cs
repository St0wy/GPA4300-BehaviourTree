using UnityEngine;

namespace BehaviourTree
{
    public class DisableBreakBehaviour : MonoBehaviour, IBreakableBehaviour
    {
        public void Break()
        {
            gameObject.SetActive(false);
        }
    }
}