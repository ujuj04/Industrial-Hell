using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    bool isCarryingCoal = false;
    int coalAmount = 0;
    [SerializeField] Furnace furnaceRef;

    public void PickupCoal()
    {
        isCarryingCoal = true;
        coalAmount++;
        Debug.Log(coalAmount);
    }

    public void PutCoalInFurnace()
    {
        if (isCarryingCoal)
        {
            coalAmount--;
            furnaceRef.TurnCoalIntoTemperature();
            Debug.Log(coalAmount); 
            
            if (coalAmount == 0)
            {
                isCarryingCoal = false;
            }
        }
        else
        {
            Debug.Log("You don't have coal to put inside");
        }
        
    }
}
