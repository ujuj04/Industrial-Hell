using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    MeshRenderer objectMesh;
    Material saveMaterial;
    public Material highlightMaterial;
    public string message;

    public UnityEvent onInteraction;

    private void Start()
    {
        objectMesh = GetComponent<MeshRenderer>();
        saveMaterial = objectMesh.material;
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableMaterial()
    {
        objectMesh.material = saveMaterial;
    }

    public void EnableMaterial()
    {
        objectMesh.material = highlightMaterial;
    }

}
