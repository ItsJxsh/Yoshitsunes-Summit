using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class SpawnKnife
{

    public static GameObject CreateKnife(GameObject Player, GameObject knifePrefab)
    {

        Vector3 knifeDirection = new Vector3(Player.transform.localScale.x, 0f, 0f);

        GameObject knife = GameObject.Instantiate(knifePrefab, Player.transform.position + knifeDirection, Quaternion.identity);
        knife.GetComponent<Rigidbody2D>().velocity = knifeDirection * 18.0f;

        return knife;

    }

}

