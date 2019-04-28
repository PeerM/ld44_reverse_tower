using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButtonManager : MonoBehaviour
{
    public IntegrityManager im;

    public Button myButton;

    // Start is called before the first frame update
    void Start()
    {
        im = FindObjectOfType<IntegrityManager>();
        myButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        myButton.interactable = im.CanAfforUpgrade;
    }
}