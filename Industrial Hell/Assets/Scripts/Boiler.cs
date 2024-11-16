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
            furnace.temperature <= maxOptimalTemperature && 
            pressure < 100)
        {
            pressure += gainPressure * Time.deltaTime;
        }
        else
        {
            if (pressure > 0)
            {
                pressure -= lossPressure * Time.deltaTime;
            }
            else
            {
                pressure = 0;
            }
        }

        currentPressureValue.text = Convert.ToUInt32(pressure).ToString();
    }

}
