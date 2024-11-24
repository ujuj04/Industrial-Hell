using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTutorial : MonoBehaviour
{
    public string levelName = "";
    public void FinishTutorial()
    {
        SceneManager.LoadScene(levelName);
    }
}
