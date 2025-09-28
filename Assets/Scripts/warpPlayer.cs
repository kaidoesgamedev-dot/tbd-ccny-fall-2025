using UnityEngine;

public class warpPlayer : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject ownerController;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector2 force)
    {
        if (rb != null) 
        {
            rb.angularVelocity = force;
        }
    }

    public void setOwner(GameObject Player)
    {
        ownerController = Player;
    }

    public GameObject getOwner() 
    {
        return ownerController;
    }
}

