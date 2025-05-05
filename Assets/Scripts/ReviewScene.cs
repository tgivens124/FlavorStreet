using UnityEngine;
using TMPro;

public class ReviewScene : MonoBehaviour
{

    public TextMeshProUGUI moneyText; // Reference to your Text component
    public TextMeshProUGUI dayText; // Reference to your Text component
    public TextMeshProUGUI moneyMadeText; // Reference to your Text component
    public TextMeshProUGUI customerServedText; // Reference to your Text component
    public float roundedMoney;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //MoneyText
        roundedMoney = (float)System.Math.Round(GlobalVariables.globalCurrentMoney, 2); // Rounds to 2 decimal places
        moneyText.text = "CurrentMoney: $" + roundedMoney.ToString("F2");

        //DayText
        dayText.text = "Day: " + GlobalVariables.dayNumber;

        //CustomersServed
        customerServedText.text = "Customers Served: " + GlobalVariables.customersServed;

        //MoneyMade
        roundedMoney = (float)System.Math.Round(GlobalVariables.globalCurrentMoney - GlobalVariables.globalStartingDayMoney, 2); // Rounds to 2 decimal places
        moneyMadeText.text = "Money Made: $" + roundedMoney.ToString("F2");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
