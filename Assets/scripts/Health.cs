using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 3;

    public void Damage(int amount)
    {
        this.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        this.health -= amount;
        StartCoroutine(waiter());
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

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(0.05f);
        this.GetComponent<Renderer>().material.color = Color.white;
    }
}