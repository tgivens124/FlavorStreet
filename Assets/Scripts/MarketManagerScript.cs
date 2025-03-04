using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Market_UI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int[,] marketItems = new int[5, 5];
    public float money;
    public Text MoneyTXT;

    void Start()
    {
        MoneyTXT.text = money.ToString();

        //ID's
        marketItems[1, 1] = 1;
        marketItems[1, 2] = 2;
        marketItems[1, 3] = 3;
        marketItems[1, 4] = 4;

        //Price
        marketItems[2, 1] = 100;
        marketItems[2, 2] = 20;
        marketItems[2, 3] = 30;
        marketItems[2, 4] = 40;

        //Quantity
        marketItems[3, 1] = 0;
        marketItems[3, 2] = 0;
        marketItems[3, 3] = 0;
        marketItems[3, 4] = 0;
    }

    // Update is called once per frame
    void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(money >= marketItems[2, ButtonRef.GetComponent<MarketButtonInfo>().ItemID])
        {
            money -= marketItems[2, ButtonRef.GetComponent<MarketButtonInfo>().ItemID];
            marketItems[3, ButtonRef.GetComponent<MarketButtonInfo>().ItemID]++;
            MoneyTXT.text = money.ToString();
            ButtonRef.GetComponent<MarketButtonInfo>().QuantityTxt.text = marketItems[3, ButtonRef.GetComponent<MarketButtonInfo>().ItemID].ToString();
        }
    }
}
