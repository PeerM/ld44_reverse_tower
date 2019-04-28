using System;
using behavior.Combat;
using UnityEngine;

namespace behavior
{
    public class Shoot : MonoBehaviour
    {
        public Transform projectileParent;
        public string parentTag;
        public GameObject prefab;

        // Start is called before the first frame update
        void Start()
        {
            if (string.IsNullOrEmpty(parentTag))
                projectileParent = transform;
            else
            {
                var go = GameObject.FindGameObjectWithTag(parentTag);
                if (go == null)
                {
                    Debug.Log(String.Format("Shoot {0} did not find anything with tag {1}", gameObject.name, parentTag));
                    projectileParent = transform;
                    return;
                }

                projectileParent = go.transform;
            }
        }

        // Update is called once per frame
        public void ShootNow()
        {
            var the_new_bullet = Instantiate(prefab, transform.position, transform.rotation, projectileParent);
            var my_targeting = this.GetComponent<HasTarget>();
            var child_targeting = the_new_bullet.GetComponent<HasTarget>();
            if (my_targeting != null && !my_targeting.Neutral && child_targeting != null)
            {
                child_targeting.retarget(my_targeting.target);
            }
        }
    }
}