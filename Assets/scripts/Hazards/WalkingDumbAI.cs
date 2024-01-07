using UnityEngine;

public class WalkingDumbAI : MonoBehaviour
{
    public float movementSpeed = 2f;
    public LayerMask wallLayer;

    private Rigidbody2D rb;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isFacingRight)  // Movement.
        {
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
        }
        bool isBlockedByWall = CheckWall(); // CheckWall activation.
        if (isBlockedByWall)
        {
            Flip();
        }
    }

    bool CheckWall() // Checks for wall collision.
    {
        Vector2 position = transform.position;
        Vector2 direction = isFacingRight ? Vector2.right : Vector2.left;
        Vector2 wallCheckOffset = position + direction * 0.2f; // Offset to enemy size.
        RaycastHit2D hit = Physics2D.Raycast(wallCheckOffset, direction, 0.3f, wallLayer);
        return hit.collider != null;
    }

    void Flip() // Flip the enemy's scale on the x-axis to change direction.
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)  // Flip if colliding with another enemy.
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Flip();
        }
    }
}
