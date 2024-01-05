using UnityEngine;
using System.Collections;

public class PlatformOneWay : MonoBehaviour
{
    private Collider2D platform;
    public GameObject player;

    void Start()
    {
        platform = GetComponent<Collider2D>();
    }
    void Update()
    {
        bool pressingDown = Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.Space);
        if (IsPlayerAbovePlatform())
        {
            platform.enabled = true;

            if (pressingDown)
            {
                platform.enabled = false;
            }
        }
        else
        {
            platform.enabled = false;
        }
    }
    bool IsPlayerAbovePlatform()
    {
        return transform.position.y < player.transform.position.y - 0.8f;
    }
}
