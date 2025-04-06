using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadToInventory : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnityEngine.UI.Button btn = GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(LoadInventoryScreen);
    }

    void LoadInventoryScreen()
    {
        Debug.Log("button click recognized");

        GlobalVariables.globalMoney = MarketManagerScript.getMoney();

        Debug.Log("money: " + GlobalVariables.globalMoney);
        Debug.Log("syrup: " + GlobalVariables.syrupCount);
        Debug.Log("ice cream: " + GlobalVariables.iceCreamCount);
        Debug.Log("toppings: " + GlobalVariables.toppingsCount);


        GameObject persistentManager = GameObject.Find("Game Manager");
        Destroy(persistentManager);
        SceneManager.LoadScene(0);
    }

}
