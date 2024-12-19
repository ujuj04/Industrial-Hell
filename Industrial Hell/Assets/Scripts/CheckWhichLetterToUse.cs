using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CheckWhichLetterToUse : MonoBehaviour
{
    private int wellBeingValueRequiredCheck = 70;

    [SerializeField] Image letterImage;

    public Sprite day2Good; 
    public Sprite day2Bad; 
    public Sprite day3Good; 
    public Sprite day3Bad; 
    public Sprite day4Good; 
    public Sprite day4Bad; 

    VariableManager variableManager;

    private void Start()
    {

        variableManager = FindObjectOfType<VariableManager>();

        if (SceneManager.GetActiveScene().name == "Letter2")
        {
            if (variableManager.WellBeingValue > wellBeingValueRequiredCheck) 
            {
                letterImage.sprite = day2Good;
                Debug.Log("good day 2");
            }
            else
            {
                letterImage.sprite = day2Bad;
                Debug.Log("bad day 2");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Letter3")
        {
            if (variableManager.WellBeingValue > wellBeingValueRequiredCheck)
            {
                letterImage.sprite = day3Good;
                Debug.Log("good day 3");
            }
            else
            {
                letterImage.sprite = day3Bad;
                Debug.Log("bad day 3");
            }
        }
        else if (SceneManager.GetActiveScene().name == "Letter4")
        {
            if (variableManager.WellBeingValue > wellBeingValueRequiredCheck)
            {
                letterImage.sprite = day4Good;
                Debug.Log("good day 4");
            }
            else
            {
                letterImage.sprite = day4Bad;
                Debug.Log("bad day 4");
            }
        }
    }
}
