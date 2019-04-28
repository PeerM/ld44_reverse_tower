using System;
using behavior.Combat;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.Events;

namespace behavior
{
    public class Damagable : MonoBehaviour
    {
        public int max_hp = 100; //TODO seperate damagable from thing that has health

        public int hp = 100;

        public bool missingHealth => hp < max_hp;

        public UnityEvent extraDeathEvent;

        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame

        void Update()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other == null)
                return;
            var whatDoesDamage = other.gameObject.GetComponent<DamageOnContact>();
            if (whatDoesDamage != null)
            {
                hp -= whatDoesDamage.damageAmount;
                whatDoesDamage.hasHit();
                reactToDamage();
            }
        }

        private void reactToDamage()
        {
            if (hp <= 0)
            {
                //TODO handle dying better
                extraDeathEvent.Invoke();
                Destroy(gameObject);
            }
        }

        public void heal(int amount)
        {
            int new_health = amount + hp;
            new_health = Math.Min(new_health, max_hp);
            hp = new_health;
        }
        public void damage(int amount)
        {
            hp -= amount;
            reactToDamage();
        }
        
    }
}