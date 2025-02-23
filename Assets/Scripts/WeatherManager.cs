using UnityEngine;
using UnityEngine.UI;

public class WeatherManager : MonoBehaviour
{
    public enum Weather { Hot, Cold }
    public Weather currentWeather;
    public Text temperatureText; // Reference to the temperature Text component

    void Start()
    {
        // Initialize weather (you can start with any weather condition)
        SetRandomWeather();
    }

    void SetRandomWeather()
    {
        // Randomly set weather to Hot or Cold for simplicity
        currentWeather = (Random.value > 0.5f) ? Weather.Hot : Weather.Cold;
        UpdateTemperatureText();
    }

    public void UpdateWeather()
    {
        // Randomly update the weather for a new day
        SetRandomWeather();
    }

    void UpdateTemperatureText()
    {
        if (currentWeather == Weather.Hot)
        {
            temperatureText.text = "Temperature: Hot (30°C)";
        }
        else if (currentWeather == Weather.Cold)
        {
            temperatureText.text = "Temperature: Cold (10°C)";
        }
    }
}