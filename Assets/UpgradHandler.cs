using System.Collections;
using System.Collections.Generic;
using behavior;
using UnityEngine;

public class UpgradHandler : MonoBehaviour
{
    public float improvment = 0.8f;

    public OnACooldown target;
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            target = GetComponentInChildren<OnACooldown>();
        }
    }

    public void Upgrade()
    {
        target.triggerPeriod *= improvment;
    }
    
}
