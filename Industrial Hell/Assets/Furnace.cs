using System;
using TMPro;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    float temperature = 0;
    public bool isCoalInside = false;
    public float gainTemperature = 0;
    public float lossTemperature = 0;
    [SerializeField] TextMeshProUGUI temperatureValueText;

    private void Update()
    {
        if (isCoalInside)
        {
            
            temperature += gainTemperature * Time.deltaTime;
        }

        if (temperature > 0)
        {
            temperature -= lossTemperature * Time.deltaTime;
        }
        else 
            temperature = 0;


        temperatureValueText.text = Convert.ToUInt32(temperature).ToString();
        Debug.Log(temperature);

    }




}
