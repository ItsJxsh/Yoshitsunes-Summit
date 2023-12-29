using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraFollowing : MonoBehaviour
{
    public Transform player;                // Reference to player position.
    public Vector3 camPosition;             // Position of the camera relative to the player.
    public float smoothSpeed = 0.125f;      // Smoothing factor for camera movement.

    private float lastMoveDirection = 0f;   // Float for horizontal offset hold.

    public float horizontalOffset = 0.75f;  // Offset to adjust the camera horizontally.
    public float verticalOffset = 2f;       // Offset to adjust the camera vertically.

    void LateUpdate()
    {
        if (player != null)     
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal"); 
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0)
            {
                lastMoveDirection = horizontalInput;    // Stores the last horizontal direction button.
            }

            Vector3 desiredPosition = player.position + camPosition;    // Calculates the desired camera position relative to the player.

            desiredPosition.x += lastMoveDirection * horizontalOffset;  // Adjusts camera based on horizontal direction buttons.
            desiredPosition.y += verticalInput * verticalOffset;        // Adjusts camera based on vertical direction buttons.

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;                      // Smoothly moves the camera towards the desired position.

            //(To freeze Z axis, not a good fix)
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);
        }
    }
}