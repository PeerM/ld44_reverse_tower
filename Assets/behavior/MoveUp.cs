using UnityEngine;

namespace behavior
{
    public class MoveUp : MonoBehaviour
    {
        public float speed = 1;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
}
