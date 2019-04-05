using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;

    void Awake()
    {
        // #Critical this makes sure we can use PhotonNetwork.LoadLevel() on
        // the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN.");
        Connect();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log(string.Format("OnJoinedRoom() called by PUN. Now this client is in {0}.",PhotonNetwork.CurrentRoom.Name));
        // In a room, spawn a character for the local player. it gets synced by
        // using PhotonNetwork.Instantiate
        Debug.Log("Spawning player");
        Vector3 spawnLoc = new Vector3(Random.Range(-3.0f, 3.0f),0.797f,Random.Range(-3.0f, 3.0f));
        PhotonNetwork.Instantiate(this.playerPrefab.name, spawnLoc, Quaternion.identity, 0);
    }

    public override void OnPlayerEnteredRoom( Player other  )
    {
        Debug.Log( "OnPlayerEnteredRoom() "); // not seen if you're the player connecting
    }

    void Connect()
    {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected)
        {
            // #Critical Join the room or create if it doesn't exist
            RoomOptions roomOptions = new RoomOptions();
            PhotonNetwork.JoinOrCreateRoom("global room", roomOptions, TypedLobby.Default);
        }
        else
        {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.GameVersion = "1.0";
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
