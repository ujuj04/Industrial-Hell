using TMPro;
using UnityEngine;

public class EndingStory : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;

    VariableManager variableManager;
    private void Start()
    {
        variableManager = FindObjectOfType<VariableManager>();
        
        if (variableManager.WellBeingValue < 70)
        {
            //bad ending
            textComponent.text = "After a grueling day at work, you return home, hoping to bring some holiday cheer to your family. But as you step through the door, the chilling silence greets you, and you discover that your loved ones have perished. How could you have worked so hard and missed their silent cries for help? Now, with your family gone, you’re left to ponder: what was the purpose of all those long hours? What meaning can life hold without them?";
        }
        else
        {
            //good ending
            textComponent.text = "Your family is grateful for your dedication and hard work; they are healthy and will survive the winter. However, as you lie in silence, having succumbed to exhaustion, you can’t help but wonder if your relentless efforts were worth the sacrifice of your own life. With one final, labored breath, you slip away, leaving behind a legacy of struggle and unanswered questions.";
        }
    }


}
