using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
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
