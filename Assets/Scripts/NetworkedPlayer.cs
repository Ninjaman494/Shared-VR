using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using Photon.Pun;
using Photon.Realtime;

/// Handles all network related operations needed for the player character.
/// NetworkedPlayer disables/enables scripts, sends updated character position
/// to the server, and updates the position based on what was recieved from the
/// server.
///
/// author: Akash Eldo (axe1412)
public class NetworkedPlayer : MonoBehaviourPunCallbacks, IPunObservable
{
    public Camera cam;
    public TrackedPoseDriver TrackedPoseDriver;
    public VRFPSControl fpsControlScript;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // If this is the other(networked) player
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            TrackedPoseDriver.enabled = false;
            cam.enabled = false;
            fpsControlScript.enabled = false;
        }
        // If this is the local player
        else
        {
            TrackedPoseDriver.enabled = true;
            cam.enabled = true;
            fpsControlScript.enabled = true;
        }
        Debug.Log("photonView: " + photonView.IsMine + ", " + TrackedPoseDriver.enabled);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting && TrackedPoseDriver.enabled)
        {
            // We own this player: send the others our data
            // Send Player object's position, as updated by TrackedPoseDriver
            stream.SendNext(TrackedPoseDriver.gameObject.transform.position);
            Debug.Log("Sending position");
        }
        else if (!stream.IsWriting)
        {
            // Network player, receive data
            // Set PlayerParent to TrackedPoseDriver's coords
            transform.position = (Vector3)stream.ReceiveNext();
            Debug.Log("Updated position to " + transform.position);
        }
    }
}
