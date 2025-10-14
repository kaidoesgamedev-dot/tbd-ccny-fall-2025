using UnityEngine;

public class pauseMenuController : MonoBehaviour
{   
    public GameObject pausePanel; // defines gameobject for pause panel;
    private bool pausedGame; // boolean for determining pause state

    // on awake, sets pause to false and timescale to standard speed
    void Awake()
    {
        Time.timeScale = 1f;
        pausedGame = false;
    }

    // Update is called once per frame
    // When pressing P and pauseGame is in different states
    // runs either pauseGame() or resumeGame().
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

    // Sets the pause panel to active
    // sets boolean to true 
    // sets timescale to 0
    void pauseGame() 
    {
        pausePanel.SetActive(true);
        pausedGame = true;
        Time.timeScale = 0f;
        
    }

    // Sets pause panel to inactive
    // sets boolean to false
    // set timescale to 1 
    void resumeGame()
    {
        pausePanel.SetActive(false);
        pausedGame = false;
        Time.timeScale = 1f;
    }
}
