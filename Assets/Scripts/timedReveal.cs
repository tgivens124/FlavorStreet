using UnityEngine;
using System.Collections;

public class timedReveal : MonoBehaviour
{

    public float delay;
    public GameObject gameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        Invoke("activateObject", delay);    }

    private void activateObject()
    {
        gameObject.SetActive(true);
    }


}
