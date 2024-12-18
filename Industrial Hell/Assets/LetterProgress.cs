using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterProgress : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ProgressToNextSceneLetters()
    {
        if (SceneManager.GetActiveScene().name == "Letter0")
        {
            SceneManager.LoadScene("Level0");
        }
        else if (SceneManager.GetActiveScene().name == "Letter1")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (SceneManager.GetActiveScene().name == "Letter2")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (SceneManager.GetActiveScene().name == "Letter3")
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
