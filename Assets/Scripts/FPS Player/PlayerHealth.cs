using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour {

    // Syncs variable to the network
    [SyncVar]
    public float health = 100f;

    public void TakeDamage (float damage) {
        // If not active on the server
        if (!isServer) {
            return;
        }

        health -= damage;
        print ("DAMAGE RECEIVED");

        if (health <= 0f) {

        }
    }

} // PlayerHealth