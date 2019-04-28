using System;
using UnityEngine;

namespace behavior.Combat
{
    public class HasTarget : MonoBehaviour
    {
        public Transform target;

        // Start is called before the first frame update
        void Start()
        {
        }

        public bool Neutral
        {
            get { return target == null; }
            set
            {
                if (value)
                    target = null;
                else
                {
                    throw new ArgumentException("Setting neutral to False is not valid");
                }
            }
        }


        // Update is called once per frame
        void Update()
        {
        }
    }
}