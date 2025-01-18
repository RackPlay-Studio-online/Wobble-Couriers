using UnityEngine;

public class GlassManager : MonoBehaviour
{
    public Transform player1; // Reference to Player 1
    public Transform player2; // Reference to Player 2
    public float rotationSpeed = 100f; // Speed of rotation

    private Vector2 player1Input;
    private Vector2 player2Input;

    private void Update()
    {
        // Get inputs from both players
        player1Input = player1.GetComponent<PlayerMovement>().moveInput;
        player2Input = player2.GetComponent<Player2Movement>().movep2Input;

        // Check if one player is giving rotation input
        if (player1Input.x != 0 && player2Input.x == 0)
        {
            RotateSystem(-player1Input.x);
        }
        else if (player2Input.x != 0 && player1Input.x == 0)
        {
            RotateSystem(player2Input.x);
        }

        // Keep the glass at the center of both players
        UpdateGlassPosition();
    }

    private void RotateSystem(float direction)
    {
        // Rotate around the glass's center
        transform.Rotate(Vector3.up, direction * rotationSpeed * Time.deltaTime);

        // Update the players' positions relative to the glass
        player1.RotateAround(transform.position, Vector3.up, direction * rotationSpeed * Time.deltaTime);
        player2.RotateAround(transform.position, Vector3.up, direction * rotationSpeed * Time.deltaTime);
    }

    private void UpdateGlassPosition()
    {
        // Set the glass at the midpoint of both players
        float x = (player1.position.x + player2.position.x) / 2;
        float z = (player1.position.z + player2.position.z) / 2;
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
