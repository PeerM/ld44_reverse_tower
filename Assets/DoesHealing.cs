using System.Collections;
using System.Collections.Generic;
using System.Linq;
using behavior;
using UnityEngine;

public class DoesHealing : MonoBehaviour
{
    public Transform playerRoot;

    public Damagable[] healingTargets;
    public float chance = 0.5f;
    public int amountEachTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        healingTargets = playerRoot.GetComponentsInChildren<Damagable>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO suck up nano matter
        
    }

    public void healSomething()
    {
            foreach (var target in healingTargets.OrderBy(a => Random.value)) //TODO choose randomly(shuffeld)
            {
                if (target.missingHealth)
                {
                    target.heal(amountEachTime);
                    return;
                }
            }       


    }
}
