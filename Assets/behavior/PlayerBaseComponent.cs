using behavior.Combat;
using UnityEngine;

namespace behavior
{
    [RequireComponent(typeof(Damagable))]
    [RequireComponent(typeof(UpgradHandler))]
    public class PlayerBaseComponent : MonoBehaviour
    {
        public Damagable damagable;

        public UpgradHandler upgradHandler;

        // Start is called before the first frame update
        void Start()
        {
            damagable = GetComponent<Damagable>();
            upgradHandler = GetComponent<UpgradHandler>();
        }
    }
}