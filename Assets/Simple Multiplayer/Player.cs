using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    public GameObject playerCamera;

    void Start() {
        if(isLocalPlayer == true) {
            playerCamera.SetActive(true);
        } else {
            playerCamera.SetActive(false);
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
