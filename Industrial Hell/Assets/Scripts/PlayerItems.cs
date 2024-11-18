using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [System.NonSerialized] public bool isCarryingItem = false;
    [System.NonSerialized] public bool isCarryingCoal = false;
    [System.NonSerialized] public bool isCarryingGear = false;
    int coalAmount = 0;
    [SerializeField] Furnace furnaceRef;
    
    public KeyCode dropItemKey = KeyCode.L;

    private void Update()
    {
        if (Input.GetKey(dropItemKey))
        {
            isCarryingItem = false;
            isCarryingGear = false;
            isCarryingCoal = false; 
            coalAmount = 0;
        }
    }



    public void PickupCoal()
    {
        if (!isCarryingItem)
        {
            isCarryingCoal = true;
            isCarryingItem = true;
            coalAmount++;
            Debug.Log(coalAmount);
        }
        else
        {
            Debug.Log("Can't hold more");
            //add hint that you can't hold more items
        }
    }

    public void PickUpGear()
    {
        if (!isCarryingItem)
        {
            isCarryingGear = true;
            isCarryingItem = true;
            Debug.Log("Took Gear");
        }
        else
        {
            Debug.Log("Can't hold more");
            //add hint that you can't hold more items
        }
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
                isCarryingItem = false;
            }
        }
        else
        {
            Debug.Log("You don't have coal to put inside");
            //add hint that you can't put coal until you hold it
        }

    }
}
