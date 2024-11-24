using UnityEngine;
using System.Collections;

public class WaterTank : MonoBehaviour
{
    [SerializeField] Boiler boiler;
    public float waterPumpTime;
    [SerializeField] HudController HUD;

    [SerializeField] private Animator valveAnimator;

    private Coroutine pumpCoroutine; // Reference to the active coroutine
    private float originalLossPressure; // Store the original loss pressure

    void Start()
    {
        // Initialize the original loss pressure
        originalLossPressure = boiler.lossPressure;
    }

    // Method to start pumping water
    public void PumpWater()
    {
        // Set the trigger to start the animation
        valveAnimator.SetTrigger("ValveRotate");

        if (pumpCoroutine != null)
        {
            StopCoroutine(pumpCoroutine);
            boiler.lossPressure = originalLossPressure; // Reset to original loss pressure
        }

        // Start the coroutine
        pumpCoroutine = StartCoroutine(PumpWaterCoroutine());
        HUD.CreatePopup("Water poured into Boiler. Pressure will be removed soon.");
    }

    // Coroutine to handle the water pumping duration
    private IEnumerator PumpWaterCoroutine()
    {
        // Temporarily increase the pressure loss
        boiler.lossPressure = originalLossPressure * 10;

        // Wait for the specified water pump time
        yield return new WaitForSeconds(waterPumpTime);

        // Reset the pressure loss to its original value
        boiler.lossPressure = originalLossPressure;

        pumpCoroutine = null; // Reset the coroutine reference
    }
}
