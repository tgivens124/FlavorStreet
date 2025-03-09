using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour
{
    public enum Weather { Hot, Cold }

    public Weather currentWeather;
    public float purchaseProbability;
    public float feedbackRating;
    public SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    public float speed; // Speed of customer movement
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

        // Add a BoxCollider2D component for collision detection
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;

        // Add a Rigidbody2D component for physics interactions
        Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
        rb.isKinematic = true; // Set to kinematic as we are controlling movement manually

        // Set the sortingOrder to 3
        spriteRenderer.sortingOrder = 4;

        // Set initial weather (this can be managed by another script or manager)
        currentWeather = Weather.Hot;

        // Calculate purchase probability based on weather
        UpdatePurchaseProbability();

        // Set the target position to (X:-10.26, Y:-0.74)
        float Yoffset = Random.Range(-.4f, .3f);
        targetPosition = new Vector3(-10.26f, transform.position.y + Yoffset, 0);

        // Set a fixed delay based on the customer's index in the array
        speed = Random.Range(1.9f, 2.1f);
        float randomDelay = Random.Range(.8f, 1f);
        delay = customerIndex * randomDelay; // Adjust the multiplier as needed
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

            // If the customer reaches the target position, stop moving
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name); // Log collision with any object

        if (other.CompareTag("IceCreamTruck"))
        {
            // Handle interaction with the ice cream truck
            Debug.Log("Customer reached the ice cream truck!");
            // You can add logic here to handle the purchase or feedback process
            if(Random.value <= purchaseProbability)
            {
                IceCreamTruckManager.Instance.totalServingsSold += 1;
                IceCreamTruckManager.Instance.money += IceCreamTruckManager.Instance.price;
                LeaveFeedback(IceCreamTruckManager.Instance.iceCream, IceCreamTruckManager.Instance.syrup, IceCreamTruckManager.Instance.toppings);
                IceCreamTruckManager.Instance.iceCream -= 1;
                IceCreamTruckManager.Instance.syrup -= 1;
                IceCreamTruckManager.Instance.toppings -= 1;
                Invoke("StopThenWalk", 1.15f);
                //StartCoroutine(StopThenWalk(2f));

            }
        }
    }

    void StopThenWalk() {
        delay = 2;
        isMoving = false;
    }

    public void UpdatePurchaseProbability()
    {
        if (currentWeather == Weather.Hot)
        {
            purchaseProbability = 0.7f; // 80% chance of buying ice cream
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