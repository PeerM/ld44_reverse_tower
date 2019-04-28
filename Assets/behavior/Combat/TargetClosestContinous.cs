using System.Linq;
using UnityEngine;

namespace behavior.Combat
{
    [RequireComponent(typeof(HasTarget))]
    public class TargetClosestContinous : MonoBehaviour
    {
        public int checkPeriod = 10;
        private int ticksToNextCheck = 1;
        private HasTarget targeter;
        public string targetTag;


        // Start is called before the first frame update
        void Update()
        {
            ticksToNextCheck -= 1;
            if (ticksToNextCheck <= 0)
            {
                ticksToNextCheck = checkPeriod;
                
                var target = findClosestEnemy();
                if (target != null)
                {
                    targeter.retarget(target.transform);
                }
                else
                {
                    targeter.Neutral = true;
                }
            }
        }

        private void Awake()
        {
            targeter = GetComponent<HasTarget>();
        }
        
        public GameObject findClosestEnemy()
        {
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag(targetTag);
            GameObject closest = null;
            float distance = Mathf.Infinity;
            Vector3 position = transform.position;
            foreach (GameObject go in gos)
            {
                Vector3 diff = go.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    closest = go;
                    distance = curDistance;
                }
            }
            return closest;
        }
    }
}