using System;
using UnityEngine;
using UnityEngine.Events;

namespace behavior.Combat
{
    
    [System.Serializable]
    public class TargetingStateEvent: UnityEvent<bool>
    {
    }
    public class HasTarget : MonoBehaviour
    {
        public Transform target;

        public TargetingStateEvent targetingStateChange;
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
                {
                    target = null;
                    targetingStateChange.Invoke(false);
                }
                else
                {
                    throw new ArgumentException("Setting neutral to False is not valid");
                }
            }
        }

        public void retarget(Transform nextTarget)
        {
            target = nextTarget;
            targetingStateChange.Invoke(true);
        }


        // Update is called once per frame
        void Update()
        {
        }
    }
}