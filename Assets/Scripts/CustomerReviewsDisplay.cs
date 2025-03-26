using TMPro;
using UnityEngine;
using UnityEngine.UI; // Or TMPro if using TextMeshPro

public class CustomerReviewsDisplay : MonoBehaviour
{
    // Reference to a UI Text or TextMeshProUGUI element for displaying reviews
    public TextMeshProUGUI reviewText; // Or public TextMeshProUGUI reviewText;

    void Start()
    {
        // Check if the global feedback list is not empty
        if (GlobalVariables.customerFeedbackMessages != null && GlobalVariables.customerFeedbackMessages.Count > 0)
        {
            // Combine all reviews into a single string with line breaks
            string allReviews = string.Join("\n\n", GlobalVariables.customerFeedbackMessages);

            // Display the reviews on the UI element
            reviewText.text = allReviews;
        }
        else
        {
            // Display a fallback message if no reviews are available
            reviewText.text = "No customer reviews available yet!";
        }
    }
}
