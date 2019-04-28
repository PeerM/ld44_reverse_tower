using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using behavior;
using UnityEngine;
using UnityEngine.UI;

public class IntegrityManager : MonoBehaviour
{
    public Text displayText;

    public int integrity;

    public int donateAmount = 15;

    public int buyAmount = 70;
    public int buyTowerAmount = 200;
    public BuyTowerUI[] buyTowerButtons;
    public bool CanAfforUpgrade => integrity >= buyAmount;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        displayText.text = $"{integrity}";

        foreach (var button in buyTowerButtons)
        {
            button.canAfford = integrity >= buyTowerAmount;
        }
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
        if (CanAfforUpgrade)
        {
            integrity -= buyAmount;
            subject.upgradHandler.Upgrade();
        }
    }

    public void buyTower(GameObject tower)
    {
        if (integrity >= buyAmount)
        {
            integrity -= buyAmount;
            tower.SetActive(true);
//            usedButton.enabled = false;
            
//            buyTowerButtons = buyTowerButtons.Where(val => val != usedButton).ToArray();
        }
    }
}