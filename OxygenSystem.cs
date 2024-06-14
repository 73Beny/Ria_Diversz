using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OxygenSystem : MonoBehaviour
{
    public float maxOxygen = 100f;   // Maximum oxygen capacity
    public float currentOxygen;     // Current oxygen level
    public float oxygenConsumptionRate = 1f;   // Rate at which oxygen is consumed per second
    public float oxygenReplenishRate = 0.5f;   // Rate at which oxygen replenishes per second


    //public Slider oxygenBar;        // Reference to the UI Slider representing the oxygen bar
    public Image oxygenBar;
    void Start()
    {
        currentOxygen = maxOxygen;  // Initialize current oxygen to maximum at start
    }

    void Update()
    {
        // Update oxygen level based on consumption and replenish rates
        currentOxygen -= oxygenConsumptionRate * Time.deltaTime;
        currentOxygen = Mathf.Clamp(currentOxygen, 0f, maxOxygen);  // Clamp current oxygen within 0 to maxOxygen

        // Update UI oxygen bar
        UpdateOxygenBar();
    }

    void UpdateOxygenBar()
    {
        currentOxygen -= oxygenConsumptionRate;
        //oxygenBar.value = currentOxygen / maxOxygen;  // Update UI slider value based on current oxygen
        oxygenBar.fillAmount = Mathf.Clamp(currentOxygen / maxOxygen, 0, 1);
        
    }

    public void ReplenishOxygen(float amount)
    {
        currentOxygen += amount;
        currentOxygen = Mathf.Clamp(currentOxygen, 0f, maxOxygen);  // Clamp current oxygen within 0 to maxOxygen

        // Update UI oxygen bar
        UpdateOxygenBar();
    }
}
