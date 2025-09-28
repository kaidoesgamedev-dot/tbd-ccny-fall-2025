using UnityEngine;

public class spawnPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject playerPrefab;
    public Transform spawnPoint;
    void Start()
    {
        spawnInPlayer();
    }

    // Update is called once per frame
    void spawnInPlayer ()
    {
        if(playerPrefab != null && spawnPoint != null)
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Player prefab or spawn point not set!");
        }
    }
}
