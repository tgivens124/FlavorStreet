using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneName; // The name of the next scene to load

    void Start()
    {
        // Start the coroutine to wait for one minute
        StartCoroutine(LoadSceneAfterDelay(30f)); // Delay of 60 seconds (1 minute)
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        GameObject persistentManager = GameObject.Find("Game Manager");
        Destroy(persistentManager);
        // Load the next scene
        SceneManager.LoadScene(nextSceneName);
    }
}
