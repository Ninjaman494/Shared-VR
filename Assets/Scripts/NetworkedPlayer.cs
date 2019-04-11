using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedPlayer : MonoBehaviourPunCallbacks
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
