using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDayHandleData : MonoBehaviour
{
    VariableManager variableManager;

    [SerializeField] TextMeshProUGUI energyGeneratedText;
    [SerializeField] TextMeshProUGUI moneyEarnedText;

    [SerializeField] ExchangeRate exchangeRate;

    [SerializeField] TextMeshProUGUI wellBeingValue;
    [SerializeField] Image wellBeingMeter;

    [SerializeField] Button foodDisabledButton;
    [SerializeField] Button foodEnabledButton;
    public int foodPriceValue = 25;
    public int foodWellBeingValue = 20;
    private bool isFoodActive = false;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        variableManager = FindObjectOfType<VariableManager>();

        UpdateUI();
        
    }


    private void UpdateUI()
    {
        if (variableManager != null)
        {
            wellBeingValue.text = variableManager.WellBeingValue.ToString();
            wellBeingMeter.fillAmount = variableManager.WellBeingValue / 100f;
            Debug.Log(variableManager.WellBeingValue / 100f);

            energyGeneratedText.text = variableManager.EnergyCount.ToString();

            CalculateMoney();

            moneyEarnedText.text = variableManager.MoneyCount.ToString();
        }
    }

    private void CalculateMoney()
    {
        int tempMoney = variableManager.EnergyCount / exchangeRate.exchnageRateValue;

        variableManager.MoneyCount += tempMoney;
    }

    public void BuyFood()
    {
        if (!isFoodActive)
        {
            if (variableManager.MoneyCount - foodPriceValue > 0)
            {
                variableManager.WellBeingValue += foodWellBeingValue;
                variableManager.MoneyCount -= foodPriceValue;
                foodEnabledButton.gameObject.SetActive(true);
                isFoodActive = true;
            }
            else
            {
                Debug.Log("not enough money");
            }
        }
        else
        {
            variableManager.WellBeingValue -= foodWellBeingValue;
            variableManager.MoneyCount += foodPriceValue;
            foodEnabledButton.gameObject.SetActive(false);
            isFoodActive = false;
        }

        UpdateUI();
    }
}
