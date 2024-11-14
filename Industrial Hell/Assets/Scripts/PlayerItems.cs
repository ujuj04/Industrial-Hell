using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    bool isCarryingCoal = false;
    int coalAmount = 0;

    public void PickupCoal()
    {
        coalAmount++;
        Debug.Log(coalAmount);
    }



}
