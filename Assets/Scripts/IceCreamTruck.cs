using UnityEngine;

public class IceCreamTruck : MonoBehaviour
{
    void Start()
    {
        // Add a BoxCollider2D component for collision detection if not already present
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }
        collider.isTrigger = true;

        // Add a Rigidbody2D component for physics interactions if not already present
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }
        rb.isKinematic = true; // Set to kinematic as we are not using physics to move the truck

        gameObject.tag = "IceCreamTruck"; // Set the tag to "IceCreamTruck"
    }
}

