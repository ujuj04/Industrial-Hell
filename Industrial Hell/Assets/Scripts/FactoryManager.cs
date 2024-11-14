using UnityEngine;
using TMPro;

public class FactoryManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float workRemainingTime;

    private void Update()
    {
        if (workRemainingTime > 0)
        {
            workRemainingTime -= Time.deltaTime;
        }
        else
        {
            workRemainingTime = 0;
            //call end work day event here later
        }

        int minutes = Mathf.FloorToInt(workRemainingTime / 60);
        int seconds = Mathf.FloorToInt(workRemainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
