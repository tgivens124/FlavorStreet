using UnityEngine;
using UnityEngine.UI;

public class IceCreamTruckManager : MonoBehaviour
{
    public int iceCream;
    public int syrup;
    public int toppings;
    public float money;
    public Text inventoryText;
    public Text moneyText;
    public float price;

    private float iceCreamPrice;

    void Start()
    {
        iceCream = 10;
        syrup = 10;
        toppings = 10;
        money = 20.0f;
        UpdateUI();
    }

    public void StartNewDay()
    {
        // Logic for starting a new day and calculating sales
        int servingsSold = Mathf.Min(iceCream, syrup, toppings); // Simple example
        money += servingsSold * iceCreamPrice;
        iceCream -= servingsSold;
        syrup -= servingsSold;
        toppings -= servingsSold;
        UpdateUI();
    }

    void UpdateUI()
    {
        inventoryText.text = $"Ice Cream: {iceCream} | Syrup: {syrup} | Toppings: {toppings}";
        moneyText.text = $"Money: ${money:F2}";
    }
}
