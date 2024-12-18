using UnityEngine;

public class CloseGame : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void CloseGameEvent()
    {
        Application.Quit();
    }
}
