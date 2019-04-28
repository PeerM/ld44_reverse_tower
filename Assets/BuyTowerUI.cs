using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTowerUI : MonoBehaviour
{
    public bool availabe = true;

    public bool canAfford;
    public GameObject tower;

    private Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        myButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        myButton.interactable = availabe && canAfford;
    }

    public void Buy()
    {
        FindObjectOfType<IntegrityManager>().buyTower(tower);
        availabe = false;
    }
}