using System.Collections;
using System.Collections.Generic;
using behavior;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour
{
    public Text healtText;
    public PlayerBaseComponent subject;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void Donate()
    {
        FindObjectOfType<IntegrityManager>().donateTowerHealt(subject.damagable); //TODO This is terible 
    }

    public void Upgrade()
    {
        FindObjectOfType<IntegrityManager>().buyUpgrade(subject);
    }
}