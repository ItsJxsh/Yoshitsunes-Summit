using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeCollision : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

         if (collision.gameObject.name == "Permanent Tiles")
        {
            Destroy(gameObject);
        }

        if (collision.tag == "enemy")
        {
            collision.GetComponent<Health>().Damage(1);
            Destroy(gameObject);
        }


    }
}