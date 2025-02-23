/*using UnityEngine;

public class Customer : MonoBehaviour
{
    public enum Weather { Hot, Cold }

    public Weather currentWeather;
    public float purchaseProbability;
    public float feedbackRating;
    public SpriteRenderer spriteRenderer; // Reference to SpriteRenderer

    void Start()
    {
        // Check if a SpriteRenderer component is already present
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            // Add a SpriteRenderer component if not already present
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        // Set initial weather (this can be managed by another script or manager)
        currentWeather = Weather.Hot;

        // Calculate purchase probability based on weather
        UpdatePurchaseProbability();
    }

    public void UpdatePurchaseProbability()
    {
        if (currentWeather == Weather.Hot)
        {
            purchaseProbability = 0.8f; // 80% chance of buying ice cream
        }
        else if (currentWeather == Weather.Cold)
        {
            purchaseProbability = 0.3f; // 30% chance of buying ice cream
        }
    }

    public void LeaveFeedback(int iceCream, int syrup, int toppings)
    {
        // Simple feedback calculation based on ingredients
        feedbackRating = (iceCream + syrup + toppings) / 3.0f;

        if (feedbackRating < 5)
        {
            Debug.Log("Customer Feedback: Not enough ingredients, lower rating.");
        }
        else
        {
            Debug.Log("Customer Feedback: Satisfied with the ice cream.");
        }
    }
}*/
using UnityEngine;

public class Customer : MonoBehaviour
{
    public enum Weather { Hot, Cold }

    public Weather currentWeather;
    public float purchaseProbability;
    public float feedbackRating;
    public SpriteRenderer spriteRenderer; // Reference to SpriteRenderer

    void Start()
    {
        // Check if a SpriteRenderer component is already present
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            // Add a SpriteRenderer component if not already present
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        // Set the sortingOrder to 2
        spriteRenderer.sortingOrder = 3;

        // Set initial weather (this can be managed by another script or manager)
        currentWeather = Weather.Hot;

        // Calculate purchase probability based on weather
        UpdatePurchaseProbability();
    }

    public void UpdatePurchaseProbability()
    {
        if (currentWeather == Weather.Hot)
        {
            purchaseProbability = 0.8f; // 80% chance of buying ice cream
        }
        else if (currentWeather == Weather.Cold)
        {
            purchaseProbability = 0.3f; // 30% chance of buying ice cream
        }
    }

    public void LeaveFeedback(int iceCream, int syrup, int toppings)
    {
        // Simple feedback calculation based on ingredients
        feedbackRating = (iceCream + syrup + toppings) / 3.0f;

        if (feedbackRating < 5)
        {
            Debug.Log("Customer Feedback: Not enough ingredients, lower rating.");
        }
        else
        {
            Debug.Log("Customer Feedback: Satisfied with the ice cream.");
        }
    }
}