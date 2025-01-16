using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;  // Assign player prefab in Inspector
    public Transform spawnPoint1, spawnPoint2;  // Set spawn positions
    public PropIK propIK;  // Reference to PropIK script attached to the glass object

    [SerializeField]
    private List<PlayerInput> players = new List<PlayerInput>();

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        players.Add(playerInput);
        playerInput.transform.SetParent(null);

        // Assign spawn positions
        if (players.Count == 1)
        {
            playerInput.transform.position = spawnPoint1.position;
            AssignHandIK(playerInput.gameObject, propIK.player1HandIK);
        }
        else if (players.Count == 2)
        {
            playerInput.transform.position = spawnPoint2.position;
            AssignHandIK(playerInput.gameObject, propIK.player2HandIK);
        }

        Debug.Log($"Player {players.Count} Joined with {playerInput.currentControlScheme}");
        Debug.Log($"Spawning Player {players.Count} at {playerInput.transform.position}");
    }

    void AssignHandIK(GameObject player, List<Transform> handTargets)
    {
        PlayerHandIK handIK = player.GetComponent<PlayerHandIK>();
        if (handIK != null && handTargets.Count >= 2)
        {
            handIK.handTargets = handTargets;
        }
    }
}