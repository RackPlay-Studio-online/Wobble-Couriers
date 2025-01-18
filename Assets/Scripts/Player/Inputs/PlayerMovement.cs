using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput; // Exposed for GlassManager to access

    void Update()
    {
        // Get input from WASD keys
        moveInput.x = Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
        moveInput.y = Input.GetKey(KeyCode.W) ? 1 : Input.GetKey(KeyCode.S) ? -1 : 0;

        // Only forward and backward movement for the player
        Vector3 moveDirection = new Vector3(0, 0, moveInput.y).normalized;

        // Move in the local forward direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self); // Use Space.Self for local space movement
    }
}
