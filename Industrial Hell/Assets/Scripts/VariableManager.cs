using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableManager : MonoBehaviour
{
    RotatingWheel rotatingWheel;

    public int EnergyCount = 0;

    public int MoneyCount = 0;

    public int WellBeingValue = 100;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3")
        {
            rotatingWheel = FindObjectOfType<RotatingWheel>();

            if (rotatingWheel != null )
            {
                EnergyCount = (int)rotatingWheel.totalEfficiencyForDay;
            }
        }

        if (WellBeingValue > 100)
        {
            WellBeingValue = 100;
        }
        else if (WellBeingValue < 0)
        {
            WellBeingValue = 0;
        }
    }
}
