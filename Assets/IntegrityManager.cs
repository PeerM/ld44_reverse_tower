using System;
using System.Collections;
using System.Collections.Generic;
using behavior;
using UnityEngine;
using UnityEngine.UI;

public class IntegrityManager : MonoBehaviour
{
    public Text displayText;

    public int integrity;

    public int donateAmount = 15;

    public int buyAmount = 70;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = $"{integrity}";
    }

    public void Donate()
    {
    }

    public void donateTowerHealt(Damagable tower)
    {
        tower.damage(donateAmount);
        integrity += donateAmount;
    }

    public void buyUpgrade(PlayerBaseComponent subject)
    {
        if (integrity >= buyAmount)
        {
            integrity -= buyAmount;
            subject.upgradHandler.Upgrade();        
        }

    }
}