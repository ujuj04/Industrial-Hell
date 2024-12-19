using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckWhichLetterToUse : MonoBehaviour
{
    private int wellBeingValueRequiredCheck = 70;

    VariableManager variableManager;

    private void Start()
    {

        variableManager = FindObjectOfType<VariableManager>();

        if (SceneManager.GetActiveScene().name == "Letter1")
        {
            if (variableManager.WellBeingValue > wellBeingValueRequiredCheck) 
            {
                //Day1GoodLetter
            }
            else
            {
                //Day1BadLetter
            }
        }
    }
}
