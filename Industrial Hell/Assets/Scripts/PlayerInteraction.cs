using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInteraction : MonoBehaviour
{
    public float playerReach;
    Interactable currentInteractable;
    [SerializeField] Camera playerCam;

    private void Update()
    {
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.Mouse0) && currentInteractable != null) 
        {
            currentInteractable.Interact();
        }
    }

    void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        if (Physics.Raycast(ray, out hit, playerReach)) 
        {
            if (hit.collider.tag == "Interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    currentInteractable.DisableMaterial();
                }
                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }
                else
                {
                    DisableCurrentInteractable();
                }
            }
            else
            {
                DisableCurrentInteractable();
            }
        }
        else
        {
            DisableCurrentInteractable();
        }
        
    }

    void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableMaterial();
        HudController.instance.EnableInteractionText(currentInteractable.message);
    }
    void DisableCurrentInteractable()
    {
        HudController.instance.DisableInteractionText();
        if (currentInteractable)
        {
            currentInteractable.DisableMaterial();
            currentInteractable = null;
        }
    }
}
