using System;
using TMPro;
using UnityEngine;

public class RotatingWheel : MonoBehaviour
{
    [System.NonSerialized] public float currentEfficiency;
    [System.NonSerialized] public float efficiencyOverTime;

    public float efficiencyTransferRate;

    [SerializeField] Boiler boiler;
    [SerializeField] TextMeshProUGUI currentEfficiencyValue;

    [SerializeField] private Vector3 rotation;
    [SerializeField] private Transform wheel;

    private void Update()
    {
        if (boiler.pressure > 0)
        {
            currentEfficiency = boiler.pressure / efficiencyTransferRate;
            
            wheel.Rotate(rotation * boiler.pressure * Time.deltaTime);
        }
        else
        {
            boiler.pressure = 0;
        }

        currentEfficiencyValue.text = Convert.ToUInt32(currentEfficiency).ToString();
    }
}
