using UnityEngine;
using UnityEngine.Events;

namespace behavior.Player
{
    public class OnEnterTrigger : MonoBehaviour
    {
        public UnityEvent onEnter;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            onEnter.Invoke();
        }
    }
}
