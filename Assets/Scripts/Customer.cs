using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Customer : MonoBehaviour
{
    public enum Weather { Hot, Cold }
    public GameObject FloatingTextPrefab;
    public string currentWeather;
    public float purchaseProbability;
    public float feedbackRating;
    public SpriteRenderer spriteRenderer; // Reference to SpriteRenderer
    public float speed; // Speed of customer movement
    public Vector3 targetPosition; // Target position for customer movement
    private float delay; // Delay before the customer starts moving
    private bool isMoving = false; // Flag to check if the customer has started moving

    // Index of the customer in the array
    public int customerIndex;

    //price of ice cream set by player
    public float price;

    // Define arrays of sentences for feedback
    string[] insufficientIceCreamFeedback = {
        "Ice Cream: I was really craving more ice cream. This is just a tease!",
        "Ice Cream: Barely any ice cream in the bowl�did you run out?",
        "Ice Cream: Not enough ice cream to satisfy my sweet tooth!",
        "Ice Cream: I could really use a bigger serving of ice cream next time.",
        "Ice Cream: Why so little ice cream? I feel short-changed."
    };

    string[] tooMuchIceCreamFeedback = {
        "Ice Cream: Wow, that's a mountain of ice cream�this is a workout to finish!",
        "Ice Cream: There�s so much ice cream; could you tone it down?",
        "Ice Cream: Too much ice cream for me; it�s overwhelming!",
        "Ice Cream: It�s a bit excessive�I�d prefer a more balanced portion of ice cream.",
        "Ice Cream: I love ice cream, but this feels like an ice cream avalanche!"
    };

    string[] perfectIceCreamFeedback = {
    "Ice Cream: Perfect amount of ice cream, just right!\n",
    "Ice Cream: You nailed the ice cream portion this time.\n",
    "Ice Cream: I love how balanced the ice cream quantity is.\n",
    "Ice Cream: You�ve nailed the portion�just enough to make me happy!\n",
    "Ice Cream: This is exactly the ice cream amount I was hoping for!\n"
    };

    string[] insufficientSyrupFeedback = {
        "Syrup: Where's the syrup? This feels a bit dry.\n",
        "Syrup: Not enough syrup! I wanted it to drizzle with sweetness.\n",
        "Syrup: I could barely taste the syrup. Was it even there?\n",
        "Syrup: A little more syrup would have made this perfect.\n",
        "Syrup: You skimped on the syrup, and I�m feeling the lack of it.\n"
    };

    string[] tooMuchSyrupFeedback = {
        "Syrup: Whoa! That's way too much syrup�it�s overpowering.\n",
        "Syrup: I'm practically swimming in syrup here. Tone it down a bit!\n",
        "Syrup: It�s too sweet! Did you accidentally pour the entire bottle?\n",
        "Syrup: A little less syrup, and this would have been amazing.\n",
        "Syrup: This is drowning in syrup. Next time, go easier on it.\n"
    };

    string[] perfectSyrupFeedback = {
        "Syrup: Spot on with the syrup�just the right amount!\n",
        "Syrup: You nailed it! The syrup is balanced and delightful.\n",
        "Syrup: Perfect syrup drizzle. It enhances the flavors without overpowering.\n",
        "Syrup: This is exactly how syrup should be�sweet, but not too much!\n",
        "Syrup: Bravo! The syrup quantity is simply perfect.\n"
    };

    string[] insufficientToppingsFeedback = {
        "Toppings: Where are the toppings? This looks so plain!\n",
        "Toppings: I was expecting a party of toppings, but got a lonely sprinkle.\n",
        "Toppings: Barely any toppings�I feel cheated!\n",
        "Toppings: A little more flair would�ve made this truly special.\n",
        "Toppings: Toppings are scarce; I guess it's a minimalist dessert.\n"
    };

    string[] tooMuchToppingsFeedback = {
        "Toppings: Whoa, it�s overflowing with toppings! I can barely find the ice cream!\n",
        "Toppings: This mountain of toppings is overkill�it�s hard to enjoy.\n",
        "Toppings: Next time, maybe skip a topping or two. Less is more!\n",
        "Toppings: I love toppings, but this feels a bit excessive.\n",
        "Toppings: So many toppings, I don�t know where to start. A little overwhelming!\n"
    };

    string[] perfectToppingsFeedback = {
        "Toppings: You got it just right�the toppings are a perfect touch!\n",
        "Toppings: Balanced and beautiful! These toppings are exactly what I needed.\n",
        "Toppings: Not too little, not too much�the topping game is on point!\n",
        "Toppings: This feels crafted with care. The toppings add the perfect burst of flavor!\n",
        "Toppings: Absolutely perfect! The toppings are delightful without overshadowing the ice cream.\n"
    };

    // Dynamic array to store customer feedback
    //public static List<string> customerFeedbackMessages = new List<string>();

    void Start()
    {

        FloatingTextPrefab = Resources.Load("FloatingText") as GameObject;

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
        currentWeather = GlobalVariables.currentWeather;

        // Calculate purchase probability based on weather
        UpdatePurchaseProbability();

        // Set the target position to (X:-10.26, Y:-0.74)
        float Yoffset = Random.Range(-.4f, .3f);
        targetPosition = new Vector3(-10.26f, transform.position.y + Yoffset, 0);

        // Set a fixed delay based on the customer's index in the array
        speed = Random.Range(1.9f, 2.1f);
        float randomDelay = Random.Range(.8f, 1f);
        delay = customerIndex * randomDelay; // Adjust the multiplier as needed

        price = RecipeManager.currentPrice;
        GlobalVariables.globalCurrentMoney = IceCreamTruckManager.Instance.money;
   
    }

    void Update()
    {
        // Wait for the delay before starting the movement
        if (delay > 0)
        {
            delay -= Time.deltaTime;
            return;
        }
        price = RecipeManager.currentPrice;
        UpdatePurchaseProbability();


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

        GlobalVariables.globalCurrentMoney = IceCreamTruckManager.Instance.money;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Collision detected with: " + other.gameObject.name); // Log collision with any object

        if (other.CompareTag("IceCreamTruck"))
        {
            // Handle interaction with the ice cream truck
            //Debug.Log("Customer reached the ice cream truck!");
            // You can add logic here to handle the purchase or feedback process
            if(checkInventory() && Random.value <= purchaseProbability)
            {
                IceCreamTruckManager.Instance.totalServingsSold += 1;
                IceCreamTruckManager.Instance.money += price;
                LeaveFeedback(GlobalVariables.globalIceCreamAmount, GlobalVariables.globalSyrupAmount, GlobalVariables.globalToppingsAmount);//IceCreamTruckManager.Instance.iceCream, IceCreamTruckManager.Instance.syrup, IceCreamTruckManager.Instance.toppings);
                IceCreamTruckManager.Instance.iceCream -= GlobalVariables.globalIceCreamAmount;
                IceCreamTruckManager.Instance.syrup -= GlobalVariables.globalSyrupAmount;
                IceCreamTruckManager.Instance.toppings -= GlobalVariables.globalToppingsAmount;
                Invoke("StopThenWalk", 1.15f);
                GlobalVariables.customersServed++;
                if (FloatingTextPrefab != null){
                    StartCoroutine(ShowFloatingText(price, 0f));
                }

                GlobalVariables.iceCreamCount = IceCreamTruckManager.Instance.iceCream;
                GlobalVariables.syrupCount = IceCreamTruckManager.Instance.syrup;
                GlobalVariables.toppingsCount = IceCreamTruckManager.Instance.toppings;
            }
        }
    }
    bool checkInventory(){
        if( IceCreamTruckManager.Instance.iceCream - RecipeManager.iceCreamAmount < 0 ||
        IceCreamTruckManager.Instance.syrup - RecipeManager.syrupAmount < 0 ||
        IceCreamTruckManager.Instance.toppings - RecipeManager.toppingsAmount < 0){
            return false;
        } 
        return true;
    }

    void StopThenWalk() {
        delay = 2;
        isMoving = false;
    }

    public void UpdatePurchaseProbability()
    {
        if (currentWeather == "Hot")
        {
            purchaseProbability = 0.6f; 
        }
        else if (currentWeather == "Cold")
        {
            purchaseProbability = 0.3f; // 30% chance of buying ice cream
        }

        if (price >= 50f){
            purchaseProbability = 0f; 
        }
        if (price >= 30f){
            purchaseProbability = .01f; 
        }
        else if (price >= 20f){
            purchaseProbability = .10f; 
        }
        else if(price >= 13){
            purchaseProbability -= .10f;
        }
        else if(price <= 11){
            purchaseProbability += .20f;
        }
        Debug.Log("Price:" + price);
        Debug.Log("Probability:" + purchaseProbability);
    }

    public void LeaveFeedback(int iceCream, int syrup, int toppings)
    {
        // Simple feedback calculation based on ingredients
        feedbackRating = (iceCream + syrup + toppings) / 3.0f;
        string feedbackMessage = "";
        float tip;
        int iceCreamScore, syrupScore, toppingsScore;

        // Customer preferences (randomized)
        int preferredIceCream;                      // Ice Cream Amount range depends on weather
        if (currentWeather == "Hot")
        {
            preferredIceCream = Random.Range(4, 9); // 4 to 8 scoops for Hot weather
        }
        else if (currentWeather == "Cold")
        {
            preferredIceCream = Random.Range(2, 5); // 2 to 4 scoops for Cold weather
        }
        else
        {
            preferredIceCream = Random.Range(3, 7) + 2; // If it's a different weather, use the default random amount
        }

        int preferredSyrup = Random.Range(2, 6) + 2;
        int preferredToppings = Random.Range(1, 5) + 2;

        if (iceCream < preferredIceCream)
        {
            int diff = preferredIceCream - iceCream;
            feedbackMessage += insufficientIceCreamFeedback[Random.Range(0, insufficientIceCreamFeedback.Length)] + $" I needed {diff} more scoops! \n" + " ";
            iceCreamScore = 2;  //Low score for insufficient amount of ice cream
        }
        else if (iceCream > preferredIceCream + 2)
        {
            int diff = iceCream - preferredIceCream;
            feedbackMessage += tooMuchIceCreamFeedback[Random.Range(0, tooMuchIceCreamFeedback.Length)] + $" That's {diff} too many scoops. \n" + " ";
            iceCreamScore = 2;  //Low score for too much ice cream
        }
        else
        {
            feedbackMessage += perfectIceCreamFeedback[Random.Range(0, perfectIceCreamFeedback.Length)] + " ";
            iceCreamScore = 5;  //High score for perfect amount of ice cream
        }

        if (syrup < preferredSyrup)
        {
            feedbackMessage += insufficientSyrupFeedback[Random.Range(0, insufficientSyrupFeedback.Length)] + " ";
            syrupScore = 2; //Low score for insufficient amount of syrup
        }
        else if (syrup > preferredSyrup + 2)
        {
            feedbackMessage += tooMuchSyrupFeedback[Random.Range(0, tooMuchSyrupFeedback.Length)] + " ";
            syrupScore = 2; //Low score for too much syrup
        }
        else
        {
            feedbackMessage += perfectSyrupFeedback[Random.Range(0, perfectSyrupFeedback.Length)] + " ";
            syrupScore = 5; //High score for perfect amount of syrup
        }

        if (toppings < preferredToppings)
        {
            feedbackMessage += insufficientToppingsFeedback[Random.Range(0, insufficientToppingsFeedback.Length)] + " ";
            toppingsScore = 2; //Low score for insufficient amount of toppings
        }
        else if (toppings > preferredToppings + 2)
        {
            feedbackMessage += tooMuchToppingsFeedback[Random.Range(0, tooMuchToppingsFeedback.Length)] + " ";
            toppingsScore = 2; //Low score for too much toppings
        }
        else
        {
            feedbackMessage += perfectToppingsFeedback[Random.Range(0, perfectToppingsFeedback.Length)] + " ";
            toppingsScore = 5; //High score for perfect amount of toppings
        }

        // Calculate overall rating based on feedback
        feedbackRating = (iceCreamScore + syrupScore + toppingsScore) / 3.0f;

        // Finalize feedback message based on rating
        if (feedbackRating < 3)
        {
            feedbackMessage += "Overall, not very satisfied.";
            tip = price * 0.1f;
        }
        else if (feedbackRating < 5)
        {
            feedbackMessage += "Overall, somewhat satisfied.";
            tip = price * 0.25f;
        }
        else
        {
            feedbackMessage += "Overall, very satisfied!";
            tip = price * 0.6f;
        }

        // Display feedback and handle floating text
        Debug.Log("Customer Feedback: " + feedbackMessage);
        GlobalVariables.customerFeedbackMessages.Add(feedbackMessage);

        if (FloatingTextPrefab != null){
            StartCoroutine(ShowFloatingText(tip, .5f));
            IceCreamTruckManager.Instance.money += tip;
        }
    }

    IEnumerator ShowFloatingText(float payment, float delayTime){
        yield return new WaitForSeconds(delayTime);
        Vector3 textPosition = new Vector3(300, 200, 0);
        GameObject parentCanvas = GameObject.Find("Canvas");
        var currText = Instantiate(FloatingTextPrefab, textPosition, Quaternion.identity, parentCanvas.transform);
        currText.GetComponent<Text>().text = "+$" + payment;
    }
}