using behavior.Combat;
using UnityEngine;

namespace behavior.Player
{
    public class LightningExpand : MonoBehaviour
    {
//        private HasTarget target_sytem;
        public bool expanded = false;
        public float maxLength = 15;
        public float length = 1;
        public float speed = 10;

        // Start is called before the first frame update
        void Start()
        {
        }

        private void Awake()
        {
//            target_sytem = GetComponent<HasTarget>();
        }

        // Update is called once per frame
        void Update()
        {
            if (length < maxLength)
            {
                transform.localScale = new Vector3(1, length, 1);
                length += speed;
            }
        }
    }
}