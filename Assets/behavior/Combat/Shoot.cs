using behavior.Combat;
using UnityEngine;

namespace behavior
{
    public class Shoot : MonoBehaviour
    {
        public Transform projectileParent;
        public GameObject prefab;

        // Start is called before the first frame update
        void Start()
        {
            if (projectileParent == null)
                projectileParent = transform;
        }

        // Update is called once per frame
        public void ShootNow()
        {
            var the_new_bullet = Instantiate(prefab, transform.position, transform.rotation, projectileParent);
            var my_targeting = this.GetComponent<HasTarget>();
            var child_targeting = the_new_bullet.GetComponent<HasTarget>();
            if (my_targeting != null && !my_targeting.Neutral && child_targeting != null)
            {
                child_targeting.target = my_targeting.target;
            }
        }
    }
}