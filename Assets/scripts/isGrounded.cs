using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{

    public GameObject player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == ("Permanent Tiles"))
        player.GetComponent<Player>().jumpsremaining = 2;
    }

}
