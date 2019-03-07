using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;
using Photon.Pun;
using Photon.Realtime;

public class NetworkedPlayer : MonoBehaviourPunCallbacks
{
    public Camera camera;
    public TrackedPoseDriver TrackedPoseDriver;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Debug.Log("photonView: " + photonView);
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            TrackedPoseDriver.enabled = false;
            camera.enabled = false;
        }
        else
        {
            TrackedPoseDriver.enabled = true;
            camera.enabled = true;
        }

    }

    void Update()
    {
        if(photonView.IsMine == true && PhotonNetwork.IsConnected == true)
        {
            if(Input.GetKey(KeyCode.D))
                    gameObject.transform.Translate(Vector3.right * Time.deltaTime * 3f);
            if(Input.GetKey(KeyCode.A))
                    gameObject.transform.Translate(Vector3.left * Time.deltaTime * 3f);
            if(Input.GetKey(KeyCode.S))
                    gameObject.transform.Translate(Vector3.back * Time.deltaTime * 3f);
            if(Input.GetKey(KeyCode.W))
                    gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 3f);
        }
    }
}
