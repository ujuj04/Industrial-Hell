using System;
using TMPro;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    [System.NonSerialized] public float pressure;
    public float gainPressure;
    public float lossPressure;
    public float minOptimalTemperature;
    public float maxOptimalTemperature;
    [SerializeField] Furnace furnace;

    [SerializeField] TextMeshProUGUI currentPressureValue;


    private void Update()
    {
        if (furnace.temperature >= minOptimalTemperature &&
            furnace.temperature <= maxOptimalTemperature)
        {
            pressure += gainPressure * Time.deltaTime;
        }

        // Ensure pressure does not drop below 0
        pressure = Math.Max(pressure - lossPressure * Time.deltaTime, 0);

        // Check and limit the pressure value within UInt32 range
        if (pressure > UInt32.MaxValue)
        {
            pressure = UInt32.MaxValue;
        }

        // Log the pressure value for debugging
        Debug.Log("Current Pressure: " + pressure);

        currentPressureValue.text = ((uint)pressure).ToString();
    }

}
