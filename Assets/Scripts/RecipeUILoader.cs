using UnityEngine;

public class RecipeUIManager : MonoBehaviour
{
    public GameObject recipePanel;

    void Start()
    {
        ShowRecipeUI();
    }

    void Update()
    {
        if (recipePanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            HideRecipeUI();
        }
    }

    public void ShowRecipeUI()
    {
        recipePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideRecipeUI()
    {
        recipePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
