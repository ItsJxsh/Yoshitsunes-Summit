using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private float speed = 0.0f;
    private float minSpeed = 6.0f;
    private float maxSpeed = 8.0f;
    private float acceleration = 2.0f;
    public bool isJumping;
    public int jumpsremaining = 2;
    public bool OnWall = false;
    private bool facingRight = true;
    private Vector3 facingLeft; 
    public int health = 3;
    public GameObject background;
    public int coinCounter;

    public bool sliding = false;
    private Rigidbody2D body;
    private Vector2 axisMovement;

    int jumpForce = 20;

    // Start is called before the first frame update
    void Start()
    {
        speed = minSpeed;
        body = GetComponent<Rigidbody2D>();
        facingLeft = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    
    }

    // Update is called once per frame
    void Update()
    {
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && jumpsremaining > 0)
        {
            body.velocity = new Vector3(body.velocity.x, 0, transform.localScale.z);
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsremaining--;
        }

        if (health <= 0)
        {
            ChangeToNextScene();
        }

        if (OnWall && axisMovement.x != 0)
        {
            body.velocity = new Vector3(body.velocity.x, -1, transform.localScale.z);
            jumpsremaining = 1;
            sliding = true;
        }
        else
        {
            sliding = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && sliding && facingRight)
        {
            body.velocity = new Vector2( -10, 3);
            Debug.Log("wall jump left");
        }
        if (Input.GetKeyDown(KeyCode.Space) && sliding && !facingRight)
        {
            body.velocity = new Vector2( 10, 3);
            Debug.Log("wall jump right");
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (axisMovement.x !=0)
        {
            speed = Mathf.Min(speed + acceleration * Time.deltaTime, maxSpeed);
        }

        else
        {
            speed = Mathf.Max(speed - acceleration * Time.deltaTime, minSpeed);
        }

        body.velocity = new Vector3(axisMovement.x * speed, body.velocity.y, transform.localScale.z);

        CheckForFlipping();
    }

    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if (movingLeft && facingRight == true)
        {
            background.transform.localScale = new Vector3(-background.transform.localScale.x, background.transform.localScale.y, background.transform.localScale.z); ;
            transform.localScale = facingLeft;
            facingRight = false;
        }

        if (movingRight && facingRight == false)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            background.transform.localScale = new Vector3(-background.transform.localScale.x, background.transform.localScale.y, background.transform.localScale.z); ;
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

    public void TakeDamage(int amount)
    {
        this.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        health -= amount;
        StartCoroutine(waiter());
        if (health <= 0)
        {
            ChangeToNextScene();
        }
    }

    IEnumerator waiter()
    {

        yield return new WaitForSeconds(0.05f);
        this.GetComponent<Renderer>().material.color = Color.white;
    }
}

    