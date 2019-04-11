using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using Photon.Pun;
using Photon.Realtime;

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
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            TrackedPoseDriver.enabled = false;
            cam.enabled = false;
            fpsControlScript.enabled = false;
        }
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
        }
        else
        {
            // Network player, receive data
            // Set PlayerParent to TrackedPoseDriver's coords
            transform.position = (Vector3)stream.ReceiveNext();
            Debug.Log("Updated position to " + transform.position);
        }
    }

    void Update()
    {
        /* if(photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if(Input.GetKey(KeyCode.D))
                    gameObject.transform.Translate(Vector3.right * Time.deltaTime * 3f);
            if(Input.GetKey(KeyCode.A))
                    gameObject.transform.Translate(Vector3.left * Time.deltaTime * 3f);
            if(Input.GetKey(KeyCode.S))
                    gameObject.transform.Translate(Vector3.back * Time.deltaTime * 3f);
            if(Input.GetKey(KeyCode.W))
                    gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 3f);
        } */
    }
}
