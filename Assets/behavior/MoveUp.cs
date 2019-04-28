using UnityEngine;

namespace behavior
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveUp : MonoBehaviour
    {
        public float speed = 1;

        private Rigidbody2D body;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            body.MovePosition( transform.position + transform.up * speed * Time.deltaTime); //TODO move to nice physics
//            body.velocity = transform.up * speed;
        }
    }
}
