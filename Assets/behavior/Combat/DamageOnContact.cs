using UnityEngine;
using UnityEngine.Events;

namespace behavior
{
    public class DamageOnContact : MonoBehaviour
    {
        public int damageAmount = 10;
        public UnityEvent afterHit;

        public void hasHit()
        {
            afterHit.Invoke();
        }
    }
}