using UnityEngine;

namespace Models
{
    public class Rotate : MonoBehaviour
    {
        // Update is called once per frame
        private void Update()
        {
            transform.Rotate(0, 2, 0);
        }
    }
}
