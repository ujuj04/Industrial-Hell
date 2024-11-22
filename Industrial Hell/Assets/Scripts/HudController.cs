using UnityEngine;
using TMPro;
using System.Collections;

public class HudController : MonoBehaviour
{
    public static HudController instance;
    [SerializeField] PlayerItems items;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;
    [SerializeField] TMP_Text carryingTextItem;
    [SerializeField] TMP_Text carryingText1;
    [SerializeField] TMP_Text carryingText2;

    [SerializeField] TMP_Text popupText;
    [SerializeField] TMP_Text popupTextUrgent;
    private Coroutine coroutinePopup;
    private Coroutine coroutinePopupUrgent;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (LMB)";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (items.isCarryingItem)
        {
            carryingText1.gameObject.SetActive(true);
            carryingText2.gameObject.SetActive(true);
            
            if (items.isCarryingCoal)
            {
                carryingTextItem.gameObject.SetActive(true);
                carryingTextItem.text = "Coal";
            }
            else if (items.isCarryingGear)
            {
                carryingTextItem.gameObject.SetActive(true);
                carryingTextItem.text = "Mechanical Gear";
            }
        }
        else
        {
            carryingText1.gameObject.SetActive(false); 
            carryingText2.gameObject.SetActive(false);
            carryingTextItem.gameObject.SetActive(false);
        }
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
        popupText.gameObject.SetActive(true);
        popupText.text = message;

        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        popupText.gameObject.SetActive(false);
        coroutinePopup = null;
    }

    public void CreatePopupUrgent(string message)
    {
        if (coroutinePopupUrgent != null)
        { 
            StopCoroutine(coroutinePopupUrgent);
        }
        coroutinePopupUrgent = StartCoroutine(ShowPopupUrgentCoroutine(message));
    }

    private IEnumerator ShowPopupUrgentCoroutine(string message)
    {
        popupTextUrgent.gameObject.SetActive(true);
        popupTextUrgent.text = message;

        // Wait for 10 seconds
        yield return new WaitForSeconds(6);

        popupTextUrgent.gameObject.SetActive(false);
        coroutinePopupUrgent = null;
    }
}

