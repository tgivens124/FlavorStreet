using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    
    public static float globalCurrentMoney;
    public static float globalStartingDayMoney;
    public static float price;
    public static int dayNumber;
    public static int iceCreamCount;
    public static int syrupCount;
    public static int toppingsCount;
    public static int customersServed;
    public static int globalIceCreamAmount;
    public static int globalSyrupAmount;
    public static int globalToppingsAmount;

    public static string currentWeather;

    public static List<string> customerFeedbackMessages = new List<string>();

    public void Start(){
        dayNumber = 0;
    }
}
