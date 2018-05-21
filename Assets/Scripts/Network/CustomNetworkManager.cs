using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

    private bool firstPlayerJoined;

    // Only called when Auto Create Player is enabled
    public override void OnServerAddPlayer (NetworkConnection conn, short playerControllerId) {
        // playerPrefab is a variable from the Network Manager
        GameObject playerObj = Instantiate (playerPrefab, Vector3.zero, Quaternion.identity);

        // Does not need NetworkManager
        List<Transform> spawnPositions = NetworkManager.singleton.startPositions;

        // Stop Players from spawning in same position
        if (!firstPlayerJoined) {
            firstPlayerJoined = true;
            playerObj.transform.position = spawnPositions[0].position;
        } else {
            playerObj.transform.position = spawnPositions[1].position;
        }

        // Add player to the server
        NetworkServer.AddPlayerForConnection (conn, playerObj, playerControllerId);
    }

    void SetPortAndAddress () {
        // Does not need NetworkManager
        NetworkManager.singleton.networkAddress = "localhost";
        NetworkManager.singleton.networkPort = 7777;
    }

    public void HostGame () {
        SetPortAndAddress ();
        // Does not need NetworkManager
        NetworkManager.singleton.StartHost ();
    }

    public void JoinGame () {
        SetPortAndAddress ();
        // Does not need NetworkManager
        NetworkManager.singleton.StartClient ();
    }

} // CustomNetworkManager