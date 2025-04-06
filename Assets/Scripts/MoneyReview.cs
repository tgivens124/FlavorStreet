using TMPro;
using UnityEngine;

public class MoneyReview : MonoBehaviour
{

    public TextMeshProUGUI moneyText; // Reference to your Text component
    float roundedMoney;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roundedMoney = (float)System.Math.Round(GlobalVariables.globalMoney, 2); // Rounds to 2 decimal places
        moneyText.text = "$" + roundedMoney.ToString("F2");
    }
}
