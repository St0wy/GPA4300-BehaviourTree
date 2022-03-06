using UnityEngine;
using UnityEngine.Scripting;

public class DisableBreakBehaviour : MonoBehaviour, IBreakableBehaviour
{
    [field: SerializeField]
    public Transform BreakPoint { get; private set;  }

    public float DistanceToBreakPoint => Vector3.Distance(BreakPoint.position, transform.position);
        
    public void Break()
    {
        gameObject.SetActive(false);
    }
}