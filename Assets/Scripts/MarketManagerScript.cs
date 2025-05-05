using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MarketManagerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int[,] marketItems = new int[5, 5];
    public static float money;
    public TMP_Text MoneyTXT;

    void Start()
    {
        if (GlobalVariables.globalCurrentMoney == null || GlobalVariables.globalCurrentMoney == 0){
            money = 60f;
        }
        else {
            money = (float)System.Math.Round(GlobalVariables.globalCurrentMoney, 2);
        }

        GlobalVariables.globalStartingDayMoney = money;

        MoneyTXT.text = money.ToString("F2");

        //ID's
        marketItems[1, 1] = 1;
        marketItems[1, 2] = 2;
        marketItems[1, 3] = 3;
        marketItems[1, 4] = 4;

        //Price
        marketItems[2, 1] = 3;
        marketItems[2, 2] = 2;
        marketItems[2, 3] = 2;
        marketItems[2, 4] = 2;

        if(GlobalVariables.dayNumber == 0){
            //Quantity
            marketItems[3, 1] = 0;
            marketItems[3, 2] = 0;
            marketItems[3, 3] = 0;
            marketItems[3, 4] = 0;
        }
        else {
            marketItems[3, 1] = GlobalVariables.iceCreamCount;
            marketItems[3, 2] = GlobalVariables.toppingsCount;
            marketItems[3, 3] = GlobalVariables.syrupCount;
            marketItems[3, 4] = 0;
        }
        
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(money >= marketItems[2, ButtonRef.GetComponent<MarketButtonInfo>().ItemID])
        {
            money -= marketItems[2, ButtonRef.GetComponent<MarketButtonInfo>().ItemID];
            marketItems[3, ButtonRef.GetComponent<MarketButtonInfo>().ItemID] = marketItems[3, ButtonRef.GetComponent<MarketButtonInfo>().ItemID] +5;
            MoneyTXT.text = money.ToString();
            ButtonRef.GetComponent<MarketButtonInfo>().QuantityTxt.text = marketItems[3, ButtonRef.GetComponent<MarketButtonInfo>().ItemID].ToString();
        }

        GlobalVariables.iceCreamCount = marketItems[3,1];
        GlobalVariables.syrupCount = marketItems[3,3];
        GlobalVariables.toppingsCount = marketItems[3, 2];
        GlobalVariables.globalCurrentMoney = money;

    }

    public static float getMoney(){
        return money;
    }
}
