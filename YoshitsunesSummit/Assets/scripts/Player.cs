using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    public int health = 3;
    public int score = 0;
    public float speed = 10.0f;
    Rigidbody2D rb; 
    public float jumpForce = 15;
    float velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float dt = Time.deltaTime;
        float horizontal = Input.GetAxisRaw("Horizontal");


        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }

    }

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
