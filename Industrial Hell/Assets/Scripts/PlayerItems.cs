using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [System.NonSerialized] public bool isCarryingItem = false;
    [System.NonSerialized] public bool isCarryingCoal = false;
    [System.NonSerialized] public bool isCarryingGear = false;
    int coalAmount = 0;
    [SerializeField] Furnace furnaceRef;
    [SerializeField] HudController HUD;
    [SerializeField] PlayerMovementAdvanced playerMovement;

    public KeyCode dropItemKey = KeyCode.L;

    private void Update()
    {
        if (Input.GetKey(dropItemKey))
        {
            isCarryingItem = false;
            isCarryingGear = false;
            isCarryingCoal = false; 
            coalAmount = 0;
            HUD.CreatePopup("Item dropped");
        }
        if (isCarryingItem)
        {
            playerMovement.walkSpeed = playerMovement.walkSpeedHalved;
            playerMovement.sprintSpeed = playerMovement.sprintSpeedHalved;
        }
        else
        {
            playerMovement.walkSpeed = playerMovement.walkSpeedSaved;
            playerMovement.sprintSpeed = playerMovement.sprintSpeedSaved;
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
            HUD.CreatePopup("Picked up coal");
        }
        else
        {
            HUD.CreatePopup("Can't hold more");
        }
    }

    public void PickUpGear()
    {
        if (!isCarryingItem)
        {
            isCarryingGear = true;
            isCarryingItem = true;
            HUD.CreatePopup("Picked up gear");
        }
        else
        {
            HUD.CreatePopup("Can't hold more");
        }
    }

    public void PutCoalInFurnace()
    {
        if (isCarryingCoal)
        {
            coalAmount--;
            furnaceRef.TurnCoalIntoTemperature();
            HUD.CreatePopup("You put coal inside. Temperature starts increasing.");

            if (coalAmount == 0)
            {
                isCarryingCoal = false;
                isCarryingItem = false;
            }
        }
        else
        {
            HUD.CreatePopup("You don't have coal to put inside. Pick it up first!");
        }

    }
}
