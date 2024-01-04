using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMount : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == ("Permanent Tiles"))
            player.GetComponent<Player>().OnWall = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == ("Permanent Tiles"))
            player.GetComponent<Player>().OnWall = false;
    }

}
