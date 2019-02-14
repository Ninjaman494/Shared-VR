using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SpatialTracking;

public class PlayerScript : NetworkBehaviour {

    public GameObject playerCamera;
    public TrackedPoseDriver poseDriver;

    void Start() {
        if(isLocalPlayer == true) {
            playerCamera.SetActive(true);
            poseDriver.enabled = true;
        } else {
            playerCamera.SetActive(false);
            poseDriver.enabled = false;
        }
    }

    void Update() {
        if(isLocalPlayer == true) {
            if(Input.GetKey(KeyCode.D)) {
                this.transform.Translate(Vector3.right * Time.deltaTime * 3f);
            }
            if(Input.GetKey(KeyCode.A)) {
                this.transform.Translate(Vector3.left * Time.deltaTime * 3f);
            }
            if(Input.GetKey(KeyCode.S)) {
                this.transform.Translate(Vector3.back * Time.deltaTime * 3f);
            }
            if(Input.GetKey(KeyCode.W)) {
                this.transform.Translate(Vector3.forward * Time.deltaTime * 3f);
            }
        }
    }
}
