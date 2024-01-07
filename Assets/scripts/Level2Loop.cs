using UnityEngine;

public class Level2Loop : MonoBehaviour
{
    private float levelWidth;

    void Start()
    {
        Camera mainCamera = Camera.main;    // Sets loop width via Camera size.
        if (mainCamera != null)
        {
            levelWidth = mainCamera.ViewportToWorldPoint(new Vector3(1, 0)).x - mainCamera.ViewportToWorldPoint(new Vector3(0, 0)).x;
        }
    }

    void Update()
    {
        LoopOnEdges();
    }
    void LoopOnEdges()  // Checks which side the object moves off-screen.
    {
        if (transform.position.x > levelWidth / 2 + 0.6f)
        {
            TeleportToOppositeEdge(-levelWidth / 2 - 0.6f);
        }
        else if (transform.position.x < -levelWidth / 2 - 0.6f)
        {
            TeleportToOppositeEdge(levelWidth / 2 + 0.6f);
        }
    }
    void TeleportToOppositeEdge(float targetX)  // Teleports object to the other side.
    {
        Vector3 newPosition = transform.position;
        newPosition.x = targetX;
        transform.position = newPosition;
    }
}
