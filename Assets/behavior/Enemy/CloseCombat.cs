using behavior.Combat;
using UnityEngine;

namespace behavior.Enemy
{
    [RequireComponent(typeof(HasTarget))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class CloseCombat : MonoBehaviour
    {
        public HasTarget target_provider;
        public float speed = 1;

        // Start is called before the first frame update
        void Start()
        {
            target_provider = GetComponent<HasTarget>();
        }

        // Update is called once per frame
        void Update()
        {
//            Vector3 diff = target_provider.target.transform.position - this.transform.position;
//            diff.Normalize();
//            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
//            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

            transform.up = target_provider.target.transform.position - transform.position;

            transform.position += transform.up * speed * Time.deltaTime; // TODO move to physics changes
        }
    }
}