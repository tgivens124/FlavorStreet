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
    public WeatherManager weatherManager; // Reference to WeatherManager
    public Sprite customerSprite; // Reference to the customer sprite
    public float minX, maxX, minY, maxY; // Define the boundaries for customer positions

    private Customer[] customers;

    void Start()
    {
        iceCream = 10;
        syrup = 10;
        toppings = 10;
        money = 20.0f;
        weatherManager = FindObjectOfType<WeatherManager>(); // Find the WeatherManager in the scene
        UpdateUI();

        // Create customers (you can adjust the number as needed)
        customers = new Customer[10];
        for (int i = 0; i < customers.Length; i++)
        {
            GameObject customerObject = new GameObject("Customer");
            SpriteRenderer spriteRenderer = customerObject.AddComponent<SpriteRenderer>(); // Add SpriteRenderer component
            customers[i] = customerObject.AddComponent<Customer>();
            customers[i].spriteRenderer = spriteRenderer; // Assign the SpriteRenderer to the Customer

            // Ensure customerSprite is assigned
            if (customerSprite != null)
            {
                customers[i].spriteRenderer.sprite = customerSprite; // Assign the customer sprite
            }
            else
            {
                Debug.LogError("Customer sprite is not assigned in the IceCreamTruckManager script.");
            }

            customers[i].currentWeather = (Customer.Weather)weatherManager.currentWeather;
            customers[i].transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0); // Set random initial position
            customers[i].customerIndex = i; // Set the customer index
        }
    }

    public void StartNewDay()
    {
        // Update weather for the new day
        weatherManager.UpdateWeather();

        // Logic for starting a new day and calculating sales
        int totalServingsSold = 0;
        foreach (var customer in customers)
        {
            customer.currentWeather = (Customer.Weather)weatherManager.currentWeather; // Explicit cast
            customer.UpdatePurchaseProbability();
            if (Random.value <= customer.purchaseProbability)
            {
                totalServingsSold++;
            }

            customer.LeaveFeedback(iceCream, syrup, toppings);
        }

        money += totalServingsSold * price;
        iceCream -= totalServingsSold;
        syrup -= totalServingsSold;
        toppings -= totalServingsSold;
        UpdateUI();
    }

    void UpdateUI()
    {
        inventoryText.text = $"Ice Cream: {iceCream} \nSyrup: {syrup} \nToppings: {toppings}";
        moneyText.text = $"Money: ${money:F2}";
    }
}