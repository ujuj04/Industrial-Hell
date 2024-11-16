using UnityEngine;

public class FurnaceDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    private bool isFurnaceDoorOpen = false;
    public void OpenOrCloseFurnaceDoor()
    {
        if (!isFurnaceDoorOpen)
        {
            isFurnaceDoorOpen = true;
            doorAnimator.Play("OpenFurnace", 0, 0.0f);
        }
        else
        {
            isFurnaceDoorOpen = false;
            doorAnimator.Play("CloseFurnace", 0, 0.0f);
        }
    }
}
