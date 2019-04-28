using UnityEngine;

namespace behavior.Combat
{
    [RequireComponent(typeof(HasTarget))]
    public class PointUpTo : MonoBehaviour
    {
        private HasTarget target_provider;

        // Start is called before the first frame update
        void Awake()
        {
            target_provider = GetComponent<HasTarget>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!target_provider.Neutral)
            {
                transform.up = target_provider.target.transform.position - transform.position;
            }
            else
            {
                transform.up = Vector3.up;
            }
        }
    }
}