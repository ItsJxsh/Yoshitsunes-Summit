using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class specialPlatforms : MonoBehaviour
{
    public GameObject player;


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        player.GetComponent<Player>().jumpsremaining = 1;
    }
}
