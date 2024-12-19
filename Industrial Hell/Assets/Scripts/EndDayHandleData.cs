using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndDayHandleData : MonoBehaviour
{
    VariableManager variableManager;

    [SerializeField] TextMeshProUGUI energyGeneratedText;
    [SerializeField] TextMeshProUGUI exchangeRateText;
    [SerializeField] TextMeshProUGUI moneyEarnedText;
    [SerializeField] TextMeshProUGUI moneyTotalText;

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

    [SerializeField] Button amenitiesDisabledButton;
    [SerializeField] Button amenitiesEnabledButton;
    public int amenitiesPriceValue = 40;
    public int amenitiesWellBeingValue = 25;
    private bool isAmenitiesActive = false;

    [SerializeField] Button clothingDisabledButton;
    [SerializeField] Button clothingEnabledButton;
    public int clothingPriceValue = 40;
    public int clothingWellBeingValue = 25;
    private bool isClothingActive = false;

    private int wellBeingValueTemp = 0;

    [SerializeField] GameObject popup;
    private Coroutine coroutinePopup;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        variableManager = FindObjectOfType<VariableManager>();

        exchangeRateText.text = exchangeRate.exchnageRateValue.ToString() + " energy = 1$";

        //reduce well being every day by 25
        variableManager.WellBeingValue -= 40;
        if (variableManager.WellBeingValue < 0)
        {
            variableManager.WellBeingValue = 0;
        }

        CalculateMoney();

        UpdateUI();
    }


    private void UpdateUI()
    {
        if (variableManager != null)
        {
            wellBeingValue.text = variableManager.WellBeingValue.ToString() + "%";
            wellBeingMeter.fillAmount = variableManager.WellBeingValue / 100f;

            energyGeneratedText.text = variableManager.EnergyCount.ToString();

            moneyEarnedText.text = (variableManager.EnergyCount / exchangeRate.exchnageRateValue).ToString();

            moneyTotalText.text = variableManager.MoneyCount.ToString();
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

    public void BuyAmenities()
    {
        if (!isAmenitiesActive)
        {
            if (variableManager.MoneyCount - amenitiesPriceValue > 0)
            {
                if (variableManager.WellBeingValue + amenitiesWellBeingValue < 100)
                {
                    variableManager.WellBeingValue += amenitiesWellBeingValue;
                }
                else
                {
                    wellBeingValueTemp = (variableManager.WellBeingValue + amenitiesWellBeingValue) - 100;
                    variableManager.WellBeingValue = 100;
                }

                variableManager.MoneyCount -= amenitiesPriceValue;
                amenitiesEnabledButton.gameObject.SetActive(true);
                isAmenitiesActive = true;
            }
            else
            {
                CreatePopup("Not Enough $");
            }
        }
        else
        {
            variableManager.WellBeingValue -= amenitiesWellBeingValue;
            if (wellBeingValueTemp > 0)
            {
                variableManager.WellBeingValue += wellBeingValueTemp;
                wellBeingValueTemp = 0;
            }

            variableManager.MoneyCount += amenitiesPriceValue;
            amenitiesEnabledButton.gameObject.SetActive(false);
            isAmenitiesActive = false;
        }

        UpdateUI();
    }

    public void BuyClothing()
    {
        if (!isClothingActive)
        {
            if (variableManager.MoneyCount - clothingPriceValue > 0)
            {
                if (variableManager.WellBeingValue + clothingWellBeingValue < 100)
                {
                    variableManager.WellBeingValue += clothingWellBeingValue;
                }
                else
                {
                    wellBeingValueTemp = (variableManager.WellBeingValue + clothingWellBeingValue) - 100;
                    variableManager.WellBeingValue = 100;
                }

                variableManager.MoneyCount -= clothingPriceValue;
                clothingEnabledButton.gameObject.SetActive(true);
                isClothingActive = true;
            }
            else
            {
                CreatePopup("Not Enough $");
            }
        }
        else
        {
            variableManager.WellBeingValue -= clothingWellBeingValue;
            if (wellBeingValueTemp > 0)
            {
                variableManager.WellBeingValue += wellBeingValueTemp;
                wellBeingValueTemp = 0;
            }

            variableManager.MoneyCount += clothingPriceValue;
            clothingEnabledButton.gameObject.SetActive(false);
            isClothingActive = false;
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
