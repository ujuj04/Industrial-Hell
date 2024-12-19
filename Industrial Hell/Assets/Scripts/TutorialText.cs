using UnityEngine;
using TMPro;

public class FactoryThemeText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textComponent;

    void Start()
    {
        // Set the text with refined formatting
        textComponent.text = "<size=24><b>TUTORIAL DAY</b></size>\n\n" +
                             "<i>Dear Worker,</i>\n\n" +
                             "Today is your tutorial day. You'll learn how to operate the steam engine on your left.\n\n" +
                             "WASD to move, Mouse for rotation and interaction, Shift to Run.\n\n" +
                             "<u>Key points to learn:</u>\n" +
                             "1. <b>Goal</b>: Generate as much <b>ENERGY</b> as possible.\n" +
                             "2. <b>Furnace Temperature</b>: Ensure the <b>FURNACE</b> temperature is within the correct range. Check the <b>BOILER</b> for today's range values.\n" +
                             "3. <b>Pressure and Energy</b>: When the <b>BOILER</b> generates <b>PRESSURE</b>, the <b>GEAR</b> will start working, producing <b>ENERGY</b> for the entire factory.\n" +
                             "4. <b>Resources</b>: Find <b>COAL</b> and new <b>GEARS</b> around the room.\n\n" +
                             "Whenever you feel ready to start your actual shift, press the button on the side to begin your first official working day.\n\n" +
                             "<i>Good luck, and happy learning!</i>";
    }
}
    