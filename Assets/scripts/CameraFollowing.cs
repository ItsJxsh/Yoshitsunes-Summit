using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollowing : MonoBehaviour
{
    // Camera movement flow w/ player.
    public Transform player;                // Reference player position.
    private Vector3 camPosition;            // Position of camera relative to the player.
    public float smoothSpeed = 0.125f;      // Smoothing factor for camera movement.
    public float horizontalOffset = 0.75f;  // Offset to adjust the camera horizontally.
    public float verticalOffset = 2f;       // Offset to adjust the camera vertically.

    private float lastMoveDirection;

    // Square camera movement barrier points.
    public Vector2 minBoundary;     // Camera barrier XY coords, bottom left of scene.
    public Vector2 maxBoundary;     // Camera barrier XY coords, top right of scene.

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();   // Checks scene name to apply barriers.
         
        if (currentScene.name == "TutorialStage")
        {
            Vector2 minBoundary = new Vector2(5f, 4f);
            Vector2 maxBoundary = new Vector2(103f, 26f);
        }
        else if (currentScene.name == "TutorialStage2")
        {
            Vector2 minBoundary = new Vector2(0f, 5f);
            Vector2 maxBoundary = new Vector2(0f, 100f);
        }
    // //     SCREEN SIZE; CONVERSATIONS FOR LATER.
    //    float targetAspect = 16f / 9f; // Aspect ratio.
    //    float windowAspect = (float)Screen.width / Screen.height;
    //    float scaleHeight = windowAspect / targetAspect;
    //    Camera camera = GetComponent<Camera>();
    //    if (scaleHeight < 1.0f)
    //    {
    //        camera.orthographicSize = camera.orthographicSize / scaleHeight;
    //    }
    }

    void Update()               // Camera Offset
    {
        if (player != null)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0)
            {
                lastMoveDirection = horizontalInput;    // Stores the last horizontal direction button.
            }
            Vector3 desiredPosition = player.position + camPosition;            // Calculates the desired camera position relative to the player.

            desiredPosition.x += lastMoveDirection * horizontalOffset;          // Adjusts camera based on horizontal direction buttons.
            desiredPosition.y += verticalInput * verticalOffset;                // Adjusts camera based on vertical direction buttons.

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

            transform.position = smoothedPosition;      // Smoothly moves the camera towards the desired position.
            transform.position = new Vector3(transform.position.x, transform.position.y, -10f);     // To freeze Z axis cam movement, needs better fix.
            transform.position = new Vector3(Mathf.Clamp(smoothedPosition.x, minBoundary.x, maxBoundary.x),
                                             Mathf.Clamp(smoothedPosition.y, minBoundary.y, maxBoundary.y), transform.position.z);    // Keeps Camera within boundary points.
        }
    }
}
