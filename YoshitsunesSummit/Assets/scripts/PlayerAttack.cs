using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private GameObject KnifeHitbox = default;

    private bool attacking = false;
    private float timeToAttack = 0.2f;
    private float timer = 0f;



    void start()
    {
        KnifeHitbox = transform.GetChild(0).gameObject;
    }

    void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
        if(attacking)
        {
            timer = Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                KnifeHitbox.SetActive(attacking);
            }
        }
    }
    void attack()
    {
        attacking = true;
        KnifeHitbox.SetActive(attacking);
    }
}


