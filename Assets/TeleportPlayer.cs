using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Attempt to get the PlayerMovement component from the collider
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        // Check if the component was found
        if (playerMovement != null)
        {
            // Call the teleport method if the component is present
            playerMovement.TeleportPlayer();
        }
    }
}
