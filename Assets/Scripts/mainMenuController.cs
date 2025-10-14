using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    // Menu Controller uses TMP_Pro buttons
    // to trigger individual functions to load
    // from the scene manager in the build settings

    // Moving around any scenes in the manager means
    // coming back here to change everything
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void RetryGame()
    {
        SceneManager.LoadSceneAsync(4);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void OpenControls()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
