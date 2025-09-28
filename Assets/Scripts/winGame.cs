using UnityEngine;
using UnityEngine.SceneManagement;

public class winGame : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync(3);
        }

    }
}
