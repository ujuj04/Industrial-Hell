using UnityEngine;
using System.Collections;

public class WaterTank : MonoBehaviour
{
    [SerializeField] Boiler boiler;
    public float waterPumpTime;

    // Method to start pumping water
    public void PumpWater()
    {
        StartCoroutine(PumpWaterCoroutine());
    }

    // Coroutine to handle the water pumping duration
    private IEnumerator PumpWaterCoroutine()
    {
        // Temporarily increase the pressure loss
        float originalLossPressure = boiler.lossPressure;
        boiler.lossPressure = originalLossPressure * 10;

        // Wait for 5 seconds
        yield return new WaitForSeconds(waterPumpTime);

        // Reset the pressure loss to its original value
        boiler.lossPressure = originalLossPressure;
    }
}
