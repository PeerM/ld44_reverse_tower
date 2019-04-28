using behavior.Combat;
using UnityEngine;

namespace behavior.Player
{
    public class LightningExpand : MonoBehaviour
    {
        private HasTarget target_sytem;
        public bool expanded = false;

        // Start is called before the first frame update
        void Start()
        {
        }

        private void Awake()
        {
            target_sytem = GetComponent<HasTarget>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!expanded)
            {
                expanded = true;
                if (target_sytem.target == null)
                {
                    Debug.Log("ligthning without target");
                    Destroy(gameObject);
                    return;
                }

                // strech from 0 to targetposition
                var diff = target_sytem.target.transform.position - transform.position;
                transform.up = diff;
                transform.localScale = new Vector3(1, diff.magnitude, 1);
            }
        }
    }
}