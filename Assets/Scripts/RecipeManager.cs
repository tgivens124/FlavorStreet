using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeManager : MonoBehaviour
{
    [Header("Sliders")]
    public Slider iceCreamSlider;
    public Slider syrupSlider;
    public Slider toppingsSlider;

    [Header("Value Display")]
    public TMP_Text iceCreamText;
    public TMP_Text syrupText;
    public TMP_Text toppingsText;

    [Header("Price Input")]
    public TMP_InputField priceInput;

    public static int iceCreamAmount;
    public static int syrupAmount;
    public static int toppingsAmount;
    public static float currentPrice;

    void Start()
    {
        LimitSlidersByInventory();

        iceCreamSlider.onValueChanged.AddListener(UpdateIceCreamAmount);
        syrupSlider.onValueChanged.AddListener(UpdateSyrupAmount);
        toppingsSlider.onValueChanged.AddListener(UpdateToppingsAmount);
        priceInput.onValueChanged.AddListener(UpdatePrice);

        UpdateIceCreamAmount(iceCreamSlider.value);
        UpdateSyrupAmount(syrupSlider.value);
        UpdateToppingsAmount(toppingsSlider.value);
        UpdatePrice(priceInput.text);
    }

    public void LimitSlidersByInventory()
    {
        iceCreamSlider.maxValue = GlobalVariables.iceCreamCount;
        syrupSlider.maxValue = GlobalVariables.syrupCount;
        toppingsSlider.maxValue = GlobalVariables.toppingsCount;
    }

    void UpdateIceCreamAmount(float value)
    {
        iceCreamAmount = Mathf.RoundToInt(value);
        iceCreamText.text = iceCreamAmount.ToString();
        GlobalVariables.globalIceCreamAmount = iceCreamAmount;
    }

    void UpdateSyrupAmount(float value)
    {
        syrupAmount = Mathf.RoundToInt(value);
        syrupText.text = syrupAmount.ToString();
        GlobalVariables.globalSyrupAmount = syrupAmount;
    }

    void UpdateToppingsAmount(float value)
    {
        toppingsAmount = Mathf.RoundToInt(value);
        toppingsText.text = toppingsAmount.ToString();
        GlobalVariables.globalToppingsAmount = toppingsAmount;
    }

    void UpdatePrice(string text)
    {
        float price;
        if (float.TryParse(text, out price))
        {
            currentPrice = price;
        }
    }
}
