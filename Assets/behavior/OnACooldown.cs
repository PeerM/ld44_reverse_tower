using System;
using UnityEngine;
using UnityEngine.Events;

namespace behavior
{
    public class OnACooldown : MonoBehaviour
    {
        public float triggerPeriod = 2;
        public float timeToNextTrigger;

        public UnityEvent onTrigger;

        // Start is called before the first frame update
        void Start()
        {
            timeToNextTrigger = triggerPeriod;
        }

        // Update is called once per frame
        void Update()
        {
            timeToNextTrigger -= Time.deltaTime;
            if (timeToNextTrigger <= 0)
            {
                timeToNextTrigger = triggerPeriod;
                onTrigger.Invoke();
            }
        }

        public void Faster(float ammount)
        {
            float nextPeriod = Math.Max(triggerPeriod -= ammount, 0.2f); //TODO change to setting instead of mathing
            triggerPeriod = nextPeriod;
        }
    }
}