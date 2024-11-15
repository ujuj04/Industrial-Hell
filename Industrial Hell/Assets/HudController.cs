using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    public static HudController instance;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] TMP_Text interactionText;

    public void EnableInteractionText(string text)
    {
        interactionText.text = text + " (LMB)";
        interactionText.gameObject.SetActive(true);
    }

    public void DisableInteractionText()
    {
        interactionText.gameObject.SetActive(false);
    }

}
