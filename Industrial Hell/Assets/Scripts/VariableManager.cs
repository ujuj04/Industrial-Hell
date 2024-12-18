using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableManager : MonoBehaviour
{
    RotatingWheel rotatingWheel;

    [NonSerialized] public int EnergyCount = 0;

    [NonSerialized] public int MoneyCount = 0;

    [NonSerialized] public int WellBeingValue = 100;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            rotatingWheel = FindObjectOfType<RotatingWheel>();

            if (rotatingWheel != null )
            {
                EnergyCount = (int)rotatingWheel.totalEfficiencyForDay;
            }
        }
    }
}
