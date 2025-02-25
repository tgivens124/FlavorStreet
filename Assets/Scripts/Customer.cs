/*using UnityEngine;

public class Customer : MonoBehaviour
{
    public enum Weather { Hot, Cold }

    public Weather currentWeather;
    public float purchaseProbability;
    public float feedbackRating;
    public SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    public float speed = 2.0f; // Speed of customer movement
    public Vector3 targetPosition; // Target position for customer movement
    private float delay; // Delay before the customer starts moving
    private bool isMoving = false; // Flag to check if the customer has started moving

    void Start()
    {
        // Check if a SpriteRenderer component is already present
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            // Add a SpriteRenderer component if not already present
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        // Set the sortingOrder to 3
        spriteRenderer.sortingOrder = 3;

        // Set initial weather (this can be managed by another script or manager)
        currentWeather = Weather.Hot;

        // Calculate purchase probability based on weather
        UpdatePurchaseProbability();

        // Set the target position to (X:-10.26, Y:-0.74)
        targetPosition = new Vector3(-10.26f, transform.position.y, 0);

        // Set a random delay for each customer to start moving
        delay = Random.Range(0.0f, 10.0f); // Adjust the range as needed
    }

    void Update()
    {
        // Wait for the delay before starting the movement
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }

        // Start moving the customer after the delay
        isMoving = true;

        // Move the customer towards the target position
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
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
    public float speed = 2.0f; // Speed of customer movement
    public Vector3 targetPosition; // Target position for customer movement
    private float delay; // Delay before the customer starts moving
    private bool isMoving = false; // Flag to check if the customer has started moving

    // Index of the customer in the array
    public int customerIndex;

    void Start()
    {
        // Check if a SpriteRenderer component is already present
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            // Add a SpriteRenderer component if not already present
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        // Set the sortingOrder to 3
        spriteRenderer.sortingOrder = 3;

        // Set initial weather (this can be managed by another script or manager)
        currentWeather = Weather.Hot;

        // Calculate purchase probability based on weather
        UpdatePurchaseProbability();

        // Set the target position to (X:-10.26, Y:-0.74)
        targetPosition = new Vector3(-10.26f, transform.position.y, 0);

        // Set a fixed delay based on the customer's index in the array
        delay = customerIndex * 1.0f; // Adjust the multiplier as needed
    }

    void Update()
    {
        // Wait for the delay before starting the movement
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }

        // Start moving the customer after the delay
        isMoving = true;

        // Move the customer towards the target position
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
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