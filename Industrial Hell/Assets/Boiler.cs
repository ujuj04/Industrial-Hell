using System;
using TMPro;
using UnityEngine;

public class Boiler : MonoBehaviour
{
    private float currentEfficiency;
    private float trackEffeciencyOverTime;
    public float gainEfficiency;
    public float lossEfficiency;
    public float minOptimalTemperature;
    public float maxOptimalTemperature;
    [SerializeField] Furnace furnace;

    [SerializeField] TextMeshProUGUI currentEfficiencyValue;


    private void Update()
    {
        if (furnace.temperature >= minOptimalTemperature && 
            furnace.temperature <= maxOptimalTemperature && 
            currentEfficiency < 100)
        {
            currentEfficiency += gainEfficiency * Time.deltaTime;
        }
        else
        {
            if (currentEfficiency > 0) 
            {
                currentEfficiency -= lossEfficiency * Time.deltaTime;
            }
            else
            {
                currentEfficiency = 0;
            }
        }

        currentEfficiencyValue.text = Convert.ToUInt32(currentEfficiency).ToString() + " %";
    }

}
