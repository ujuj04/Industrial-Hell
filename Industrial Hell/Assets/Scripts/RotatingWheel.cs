using System;
using System.Runtime.CompilerServices;
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
    private bool didShowBrokenGearInfo = false;

    [SerializeField] PlayerItems items;

    [SerializeField] Material normalGearMaterial;
    [SerializeField] Renderer gearMaterialReference;
    [SerializeField] Material brokenGearMaterial;
    [SerializeField] Material transparentGearMaterial;

    [SerializeField] HudController HUD;
    
    private float gearHP = 100;
    public float gearHPLoseRate;


    private void Update()
    {
        if (isGearAttached) 
        {
            if (gearHP > 0)
            {
                gearMaterialReference.material = normalGearMaterial;
            }
            else
            {
                gearMaterialReference.material = brokenGearMaterial;
            }

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
                    if (!didShowBrokenGearInfo)
                    {
                        HUD.CreatePopupUrgent("The gear is broken! Change it or suffer 5x efficiency penalties");
                        didShowBrokenGearInfo = true;
                    }
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
                currentEfficiency = 0;
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
                    HUD.CreatePopup("Gear attached!");
                    didShowBrokenGearInfo = false;
                }
                else
                {
                    HUD.CreatePopup("You don't have a gear to attach. Pick it up first!");
                }
            }
            //detaching
            else
            {
                isGearAttached = false;
                gearTransparent.SetActive(true);
                gearWorking.SetActive(false);
                HUD.CreatePopup("Gear dettached!");
            }
        }
        else
        {
            HUD.CreatePopup("Can't interact with gear if there is any pressure in the boiler!");
        }
    }
}
