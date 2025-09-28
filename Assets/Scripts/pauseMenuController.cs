using UnityEngine;

public class pauseMenuController : MonoBehaviour
{
    public GameObject pausePanel;
    private bool pausedGame;
    void Awake()
    {
        Time.timeScale = 1f;
        pausedGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && pausedGame == false)
        {
            Debug.Log("You Are Pressing P Right Now");
            pauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && pausedGame == true)
        {
            Debug.Log("We are P-ing At The Same Time");
            resumeGame();
        }
    }

    void pauseGame() 
    {
        pausePanel.SetActive(true);
        pausedGame = true;
        Time.timeScale = 0f;
        
    }

    void resumeGame()
    {
        pausePanel.SetActive(false);
        pausedGame = false;
        Time.timeScale = 1f;
    }
}
