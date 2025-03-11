using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class MarketButtonInfo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int ItemID;
    public TMP_Text PriceTxt;
    public TMP_Text QuantityTxt;
    public GameObject MarketManager;
    

    // Update is called once per frame
    void Update()
    {
        PriceTxt.text = MarketManager.GetComponent<MarketManagerScript>().marketItems[2, ItemID].ToString();
        QuantityTxt.text = MarketManager.GetComponent<MarketManagerScript>().marketItems[3, ItemID].ToString();
    }
}
