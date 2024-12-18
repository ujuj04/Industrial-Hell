using System.Collections;
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

    [SerializeField] Button medicineDisabledButton;
    [SerializeField] Button medicineEnabledButton;
    public int medicinePriceValue = 40;
    public int medicineWellBeingValue = 25;
    private bool isMedicineActive = false;

    private int wellBeingValueTemp = 0;

    [SerializeField] GameObject popup;
    private Coroutine coroutinePopup;


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
                if (variableManager.WellBeingValue + foodWellBeingValue < 100)
                {
                    variableManager.WellBeingValue += foodWellBeingValue;
                }
                else
                {
                    wellBeingValueTemp = (variableManager.WellBeingValue + foodWellBeingValue) - 100;
                    variableManager.WellBeingValue = 100;
                }

                variableManager.MoneyCount -= foodPriceValue;
                foodEnabledButton.gameObject.SetActive(true);
                isFoodActive = true;
            }
            else
            {
                CreatePopup("Not Enough $");
            }
        }
        else
        {
            variableManager.WellBeingValue -= foodWellBeingValue;
            if (wellBeingValueTemp > 0)
            {
                variableManager.WellBeingValue += wellBeingValueTemp;
                wellBeingValueTemp = 0;
            }

            variableManager.MoneyCount += foodPriceValue;
            foodEnabledButton.gameObject.SetActive(false);
            isFoodActive = false;
        }

        UpdateUI();
    }

    public void BuyMedicine()
    {
        if (!isMedicineActive)
        {
            if (variableManager.MoneyCount - medicinePriceValue > 0)
            {
                if (variableManager.WellBeingValue + medicineWellBeingValue < 100)
                {
                    variableManager.WellBeingValue += medicineWellBeingValue;
                }
                else
                {
                    wellBeingValueTemp = (variableManager.WellBeingValue + medicineWellBeingValue) - 100;
                    variableManager.WellBeingValue = 100;
                }

                variableManager.MoneyCount -= medicinePriceValue;
                medicineEnabledButton.gameObject.SetActive(true);
                isMedicineActive = true;
            }
            else
            {
                CreatePopup("Not Enough $");
            }
        }
        else
        {
            variableManager.WellBeingValue -= medicineWellBeingValue;
            if (wellBeingValueTemp > 0)
            {
                variableManager.WellBeingValue += wellBeingValueTemp;
                wellBeingValueTemp = 0;
            }

            variableManager.MoneyCount += medicinePriceValue;
            medicineEnabledButton.gameObject.SetActive(false);
            isMedicineActive = false;
        }

        UpdateUI();
    }




    public void CreatePopup(string message)
    {
        if (coroutinePopup != null)
        {
            StopCoroutine(coroutinePopup);
        }

        coroutinePopup = StartCoroutine(ShowPopupCoroutine(message));
    }

    private IEnumerator ShowPopupCoroutine(string message)
    {
        popup.gameObject.SetActive(true);

        // Wait for 3 seconds
        yield return new WaitForSeconds(2);

        popup.gameObject.SetActive(false);
        coroutinePopup = null;
    }
}
