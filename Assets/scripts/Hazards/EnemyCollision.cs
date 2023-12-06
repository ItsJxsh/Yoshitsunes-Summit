using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null && Mathf.Abs(player.transform.position.x - transform.position.x) <= 2 && Mathf.Abs(player.transform.position.y - transform.position.y) <= 2)
            {
                player.TakeDamage(damageAmount);
            }
        }
    }
}
