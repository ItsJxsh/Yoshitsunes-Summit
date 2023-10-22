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
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }
}
