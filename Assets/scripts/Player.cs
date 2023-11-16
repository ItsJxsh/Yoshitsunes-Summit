using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 8f;
    public bool isGrounded;
    public bool isJumping;
    private bool facingRight = true;
    private Vector3 facingLeft; 
    public int health = 3;


    private Rigidbody2D body;
    private Vector2 axisMovement;

    int jumpForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        facingLeft = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector3(body.velocity.x, 0, transform.localScale.z);
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Game Over");
        }
        if (health <= 0)
        {
            ChangeToNextScene();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        body.velocity = new Vector3(axisMovement.x * speed, body.velocity.y, transform.localScale.z);
        CheckForFlipping();
    }

    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if (movingLeft && facingRight == true)
        {
            transform.localScale = facingLeft;
            facingRight = false;
        }

        if (movingRight && facingRight == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            facingRight = true;
        }
    }

    public void ChangeScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
        
    }
    public void ChangeToNextScene()
    {
        string nextSceneName = "Game Over";
        ChangeScene(nextSceneName);

    }
}

    