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

        //GlobalVariables.globalCurrentMoney = MarketManagerScript.getMoney();

        Debug.Log("money: " + GlobalVariables.globalCurrentMoney);
        Debug.Log("syrup: " + GlobalVariables.syrupCount);
        Debug.Log("ice cream: " + GlobalVariables.iceCreamCount);
        Debug.Log("toppings: " + GlobalVariables.toppingsCount);


        GameObject persistentManager = GameObject.Find("Game Manager");
        Destroy(persistentManager);
        if (GlobalVariables.globalCurrentMoney >= 500){
            SceneManager.LoadScene("EndGame");
        }
        else{
            SceneManager.LoadScene("SampleScene");
        }
        
    }

}
