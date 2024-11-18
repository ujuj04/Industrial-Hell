using System;
using TMPro;
using UnityEngine;

public class RotatingWheel : MonoBehaviour
{
    [System.NonSerialized] public float currentEfficiency;
    [System.NonSerialized] public float totalEfficiencyForDay;

    [System.NonSerialized] public float efficiencyTransferRateCurrent;
    public float efficiencyTransferRateWorkingGear;
    public float efficiencyTransferRateBrokenGear;

    [SerializeField] Boiler boiler;
    [SerializeField] TextMeshProUGUI currentEfficiencyValue;

    [SerializeField] private Vector3 rotation;
    [SerializeField] private Transform gear;

    private float gearHP = 100;
    private float gearHPLoseRate = 4;

    private void Update()
    {
        if (boiler.pressure > 0)
        {
            if (gearHP > 0)
            {
                efficiencyTransferRateCurrent = efficiencyTransferRateWorkingGear;
                Debug.Log("efficiencyTransferRate " + efficiencyTransferRateCurrent);
            }
            else
            {
                efficiencyTransferRateCurrent = efficiencyTransferRateBrokenGear;
            }
            currentEfficiency = boiler.pressure / efficiencyTransferRateCurrent;
            totalEfficiencyForDay += currentEfficiency * Time.deltaTime;

            gear.Rotate(rotation * currentEfficiency * Time.deltaTime);

            gearHP -= gearHPLoseRate * Time.deltaTime;
            Debug.Log("gearHP " + gearHP);
        }
        else
        {
            boiler.pressure = 0;
        }

        currentEfficiencyValue.text = Convert.ToUInt32(currentEfficiency).ToString();
    }
}
