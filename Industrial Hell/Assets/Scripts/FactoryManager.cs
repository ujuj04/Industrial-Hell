using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;

public class FactoryManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float workRemainingTime;

    [SerializeField] TextMeshProUGUI efficiencyValueText;
    [SerializeField] RotatingWheel rotatingWheel;

    private void Update()
    {
        //timer
        if (workRemainingTime > 0)
        {
            workRemainingTime -= Time.deltaTime;
        }
        else
        {
            workRemainingTime = 0;
            EndDay();
        }

        int minutes = Mathf.FloorToInt(workRemainingTime / 60);
        int seconds = Mathf.FloorToInt(workRemainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        //energy today
        if (rotatingWheel!= null)
        {
            efficiencyValueText.text = ((int)rotatingWheel.totalEfficiencyForDay).ToString();

        }
        else
        {
            Debug.Log("wheel doesn't exist");
        }
    }

    public void EndDay()
    {
        SceneManager.LoadScene("EndDay");
    }
}
