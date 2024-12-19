using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class FactoryManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float workRemainingTime;

    [SerializeField] TextMeshProUGUI efficiencyValueText;
    [SerializeField] RotatingWheel rotatingWheel;

    [SerializeField] Boiler boiler;

    [SerializeField] HudController HUD;

    public Color originalColorOfLights;

    private bool isAlarmOn = false;
    private bool wasAlarmPlayed = false;

    public int timeToPlayAlarmOnLevel3 = 90;

    public float alarmTimerDuration = 30f;  

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

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (workRemainingTime <= timeToPlayAlarmOnLevel3 && !wasAlarmPlayed && !isAlarmOn)
            {
                AlarmEvent();
            }

            if (isAlarmOn)
            {
                if(boiler.pressure <= 0)
                {
                    EndAlarm();
                }
            }
        }

        

    }

    public void EndDay()
    {
        //no if for Level0, because plaeyrs presses button to progress to next level

        if (SceneManager.GetActiveScene().name == "Level1")
        {
            SceneManager.LoadScene("EndDay1");
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            SceneManager.LoadScene("EndDay2");
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            SceneManager.LoadScene("EndDay3");
        }
    }


    private void AlarmEvent()
    {
        StartCoroutine(StartAlarmTimer());

        HUD.CreatePopupUrgent("ALARM, GAS LEAK!!! REDUCE THE PRESSURE TO 0 IMMEDIATELY!");

        GameObject[] lights = GameObject.FindGameObjectsWithTag("LightsAlarm");

        foreach (GameObject lightObject in lights)
        {

            Debug.Log("found lights");
            Light lightComponent = lightObject.GetComponent<Light>();

            if (lightComponent != null && lightComponent.type == LightType.Point) 
            { 
                lightComponent.color = Color.red;
            }
        }

        isAlarmOn = true;
    }

    private void EndAlarm()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("LightsAlarm");

        foreach (GameObject lightObject in lights)
        {

            Debug.Log("found lights");
            Light lightComponent = lightObject.GetComponent<Light>();

            if (lightComponent != null && lightComponent.type == LightType.Point)
            {
                lightComponent.color = originalColorOfLights;
            }
        }
        isAlarmOn = false;

        wasAlarmPlayed = true;
    }

    IEnumerator StartAlarmTimer()
    {
        yield return new WaitForSeconds(alarmTimerDuration);

        OnAlarmtimerComplete();
    }

    private void OnAlarmtimerComplete()
    {
        if (isAlarmOn)
        {
            //load bad ending
            Debug.Log("bad ending");
        }
    }

}
