using UnityEngine;

namespace behavior
{
    public class Destroyer : MonoBehaviour
    {
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
