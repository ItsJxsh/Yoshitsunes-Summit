using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PolygonCollider2D hitbox;


    void start()
    {
        hitbox = transform.Find("KnifeHitbox").GetComponent<PolygonCollider2D>();
    }

    void update()
    {
        if (Input.GetKeyDown(KeyCode.E));
        {
            Invoke("ActivateHitbox", 0.2f); // Activate hitbox after 0.2 seconds.
            Invoke("DeactivateHitbox", 0.4f); // Deactivate hitbox after 0.4 seconds.
        }
    }

    void ActivateHitbox()
    {
        hitbox.gameObject.SetActive(true);
    }

    void DeactivateHitbox()
    {
       hitbox.gameObject.SetActive(false);
    }
}


