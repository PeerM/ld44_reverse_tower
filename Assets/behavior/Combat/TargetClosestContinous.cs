using System.Linq;
using UnityEngine;

namespace behavior.Combat
{
    [RequireComponent(typeof(HasTarget))]
    public class TargetClosestContinous : MonoBehaviour
    {
        public int checkPeriod = 10;
        private int ticksToNextCheck = 1;
        public GameObject subSet;
        private HasTarget targeter;


        // Start is called before the first frame update
        void Update()
        {
            if (subSet == null)
            {
                Debug.LogError("shit Target closest has started to soon");
                return;
            }

            ticksToNextCheck -= 1;
            if (ticksToNextCheck <= 0)
            {
                ticksToNextCheck = checkPeriod;

                var potential_targets = subSet.GetComponentsInChildren<Damagable>();
//                if (potential_targets.Length == 0 )
//                {}
                var target = potential_targets
                    .OrderByDescending(p => (p.transform.position - this.transform.position).magnitude)
                    .FirstOrDefault(); //TODO this does not work right, maybe try spheerecasting
                if (target != null)
                {
                    targeter.target = target.transform;
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
    }
}