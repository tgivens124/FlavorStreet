using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScrollableTextWithMouse : MonoBehaviour
{
    public TextMeshProUGUI Content; // Reference to your Text component
    public float scrollSpeed = 50f; // Speed of scrolling
    private RectTransform textRect; // RectTransform of the text
    private float viewportHeight; // Height of the visible area (for clamping)
    private float contentHeight; // Total height of the content (text)

    void Start()
    {
        textRect = Content.GetComponent<RectTransform>();  

        // Check if reviews exist
        if (GlobalVariables.customerFeedbackMessages != null && GlobalVariables.customerFeedbackMessages.Count > 0)
        {
            Content.text = string.Join("\n\n", GlobalVariables.customerFeedbackMessages);
            // Adjust the text container size
            //textRect.sizeDelta = new Vector2(textRect.sizeDelta.x, contentHeight);
        }
        else
        {
            Content.text = "No customer reviews available yet!";
        }
    }

    void Update()
    {
        // Listen for mouse scroll input
        // float scroll = Input.GetAxis("Mouse ScrollWheel");

        // if (scroll != 0)
        // {
        //     // Adjust the position of the text based on scroll input
        //     textRect.anchoredPosition -= new Vector2(0, scroll * scrollSpeed);
        // }
    }
}
