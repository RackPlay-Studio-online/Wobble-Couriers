using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject player1; // Pre-placed Player 1 object
    public GameObject player2; // Pre-placed Player 2 object

    private int playersJoined = 0; // Track the number of players joined

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        if (playersJoined == 0) // First player joins
        {
            AssignControlToPlayer(playerInput, player1);
        }
        else if (playersJoined == 1) // Second player joins
        {
            AssignControlToPlayer(playerInput, player2);
        }
        else
        {
            Debug.LogWarning("Max players already joined!");
        }
    }

    private void AssignControlToPlayer(PlayerInput playerInput, GameObject targetPlayer)
    {
        // Assign the control to the target player
        playerInput.transform.SetParent(targetPlayer.transform);
        playerInput.transform.localPosition = Vector3.zero;
        playerInput.transform.localRotation = Quaternion.identity;

        PlayerInput targetInput = targetPlayer.GetComponent<PlayerInput>();
        if (targetInput != null)
        {
            targetInput.SwitchCurrentControlScheme(playerInput.currentControlScheme, playerInput.devices.ToArray());
        }

        Debug.Log($"Player {playersJoined + 1} assigned to {targetPlayer.name} with {playerInput.currentControlScheme}");
        playersJoined++;
    }
}