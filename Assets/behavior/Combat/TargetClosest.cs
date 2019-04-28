using System.Linq;
using UnityEngine;

namespace behavior.Combat
{
    [RequireComponent(typeof(HasTarget))]
    public class TargetClosest : MonoBehaviour
    {
        public GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            if (player == null)
            {
                Debug.LogError("shit Target closest has started to soon");
                return;
            }

            var potential_targets = player.GetComponentsInChildren<PlayerBaseComponent>();
            var target = potential_targets
                .OrderByDescending(p => (p.transform.position - this.transform.position).magnitude)
                .First();
            GetComponent<HasTarget>().retarget(target.transform);
        }
    }
}