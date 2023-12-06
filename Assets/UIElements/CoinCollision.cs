using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public AudioSource myFx;
    public AudioClip CoinSound;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player")
        {
            collider.GetComponent<Player>().coinCounter++;
            myFx.PlayOneShot(CoinSound);
            Destroy(gameObject);
        }
    }
}
