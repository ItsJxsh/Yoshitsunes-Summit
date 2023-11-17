using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    public void Damage(int amount)
    {
        this.health -= amount;
        if (health <= 0)
        {
            Debug.Log("I am Dead!");
        Destroy(gameObject);
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(this.gameObject);
    }
}
