using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 movep2Input; // Exposed for GlassManager to access

    void Update()
    {
        // Get input from Arrow Keys
        movep2Input.x = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        movep2Input.y = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;

        
        // Only forward and backward movement for the player
        Vector3 moveDirection = new Vector3(0, 0, movep2Input.y).normalized;

        // Move in the local forward direction
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.Self); // Use Space.Self for local space movement
    }
}
