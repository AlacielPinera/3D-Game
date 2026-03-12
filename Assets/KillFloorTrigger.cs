using UnityEngine;

public class KillFloorTrigger : MonoBehaviour
{
    public Transform spawnPoint; // Drag your 'SpawnPoint' GameObject here in the Inspector

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Teleport the player to the spawn point
            other.transform.position = spawnPoint.position;

            // Reset player velocity if they have a Rigidbody
            Rigidbody playerRb = other.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
            }
        }
    }
}

