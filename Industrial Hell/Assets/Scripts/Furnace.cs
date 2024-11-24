using System;
using TMPro;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    [System.NonSerialized] public float temperature = 0;
    private bool isCoalInside = false;
    public float gainTemperature = 0;
    public float lossTemperature = 0;
    [SerializeField] TextMeshProUGUI temperatureValueText;
    [SerializeField] TextMeshProUGUI remainingCoalValueText;
    private float coalRemainingInside = 0f;
    public float giveCoalAmount = 10f;

    [SerializeField] HudController HUD;

    [SerializeField] private Animator leverAnimator;

    private void Update()
    {
        if (coalRemainingInside > 0)
        {
            isCoalInside = true;
        }
        else
        {
            coalRemainingInside = 0;
            isCoalInside = false;
        }

        if (coalRemainingInside > 0)
        {
            coalRemainingInside -= 1f * Time.deltaTime;
        }

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
        remainingCoalValueText.text = Convert.ToUInt32(coalRemainingInside).ToString();
    }


    public void TurnCoalIntoTemperature()
    {
        coalRemainingInside += giveCoalAmount;
    }

    public void EmptyFurnace()
    {
        leverAnimator.SetTrigger("LeverRotate");
        coalRemainingInside = 0f;
        HUD.CreatePopup("You emptied the furnace, there is now no coal inside!");
    }
}
