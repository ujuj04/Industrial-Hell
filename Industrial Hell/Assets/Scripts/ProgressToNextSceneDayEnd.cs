using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressToNextSceneDayEndScript : MonoBehaviour
{
    public void ProgressToNextSceneDayEnd()
    {
        // no EndDay0, because there is no management in tutorial

        if (SceneManager.GetActiveScene().name == "EndDay1")
        {
            SceneManager.LoadScene("Letter2");
        }
        else if (SceneManager.GetActiveScene().name == "EndDay2")
        {
            SceneManager.LoadScene("Letter3");
        }
        else if (SceneManager.GetActiveScene().name == "EndDay3")
        {
            SceneManager.LoadScene("Letter4");
        }
    }
}
