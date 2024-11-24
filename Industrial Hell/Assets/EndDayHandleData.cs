using TMPro;
using UnityEngine;

public class EndDayHandleData : MonoBehaviour
{
    VariableManager variableManager;

    [SerializeField] TextMeshProUGUI energyGeneratedText;
    [SerializeField] TextMeshProUGUI moneyEarnedText;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true;

        variableManager = FindObjectOfType<VariableManager>();

        if (variableManager != null )
        {
            energyGeneratedText.text = variableManager.EnergyCount.ToString();

            CalculateMoney();

            moneyEarnedText.text = variableManager.MoneyCount.ToString();
        }
    }

    private void CalculateMoney()
    {
        int tempMoney = variableManager.EnergyCount / 6;

        variableManager.MoneyCount += tempMoney;
    }
}
