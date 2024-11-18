using UnityEngine;
using TMPro;

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
        }
        else
        {
            carryingText1.gameObject.SetActive(false); 
            carryingText2.gameObject.SetActive(false);
        }


        if (items.isCarryingCoal)
        {
            carryingTextItem.gameObject.SetActive(true);
            carryingTextItem.text = "Coal";
        }
        else
        {
            carryingTextItem.gameObject.SetActive(false);
        }
    }

}
