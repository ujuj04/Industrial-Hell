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
    [SerializeField] private GameObject gearTransparent;
    [SerializeField] private GameObject gearWorking;
    //[SerializeField] private Transform gearTransform;
    private bool isGearAttached = false;

    [SerializeField] PlayerItems items;

    [SerializeField] Material normalGearMaterial;
    [SerializeField] Material transparentGearMaterial;

    [SerializeField] MeshRenderer meshRenderer;
    
    private float gearHP = 100;
    public float gearHPLoseRate;


    private void Update()
    {
        if (isGearAttached) 
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

                gearWorking.transform.Rotate(rotation * currentEfficiency * Time.deltaTime);
                gearTransparent.transform.Rotate(rotation * currentEfficiency * Time.deltaTime);

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

    public void AttachOrDetachGear()
    {
        if(boiler.pressure == 0)
        {
            //attaching gear
            if (!isGearAttached)
            {
                if (items.isCarryingGear)
                {
                    isGearAttached = true;
                    items.isCarryingGear = false;
                    items.isCarryingItem = false;
                    gearHP = 100;
                    gearTransparent.SetActive(false);
                    gearWorking.SetActive(true);
                    Debug.Log("gear attached");
                }
                else
                {
                    Debug.Log("take gear before trying to place it");
                }
            }
            //detaching
            else
            {
                isGearAttached = false;
                gearTransparent.SetActive(true);
                gearWorking.SetActive(false);
                Debug.Log("gear dettached");
            }
        }
        else
        {
            Debug.Log("Can't interact with gear while it's moving");
        }
    }
}
