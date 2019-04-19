using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

/// Script used to provide WASD and mouse controls when running on PC.
/// This script is similiar to FPSControl except that has been adjusted
/// to not interfere with the VR/AR code when running on Android. This script
/// also simplified and doesn't use a Character Controller or Animator
///
/// author: Akash Eldo (axe1412)
public class VRFPSControl : MonoBehaviour {
    public GameObject head;
    public float sensitivity = 2f;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;
    float startingY = 1.125F;

    void Update() {
        // Don't use input if on Android, TrackPoseDriver will take care
        // of movement
        if(Application.platform == RuntimePlatform.Android) {
            return;
        }

        // Maintain head position. Disabled for Windows because it doesn't
        // seem to work properly on this platform
        if (Application.platform != RuntimePlatform.WindowsPlayer)
        {
            head.transform.Translate(new Vector3(0, startingY, 0));
        }

        // Mouse movement
        float rotationX = head.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
        head.transform.localRotation = Quaternion.Euler(-rotationY, 0, 0);
        transform.Rotate(new Vector3(0, rotationX, 0));

        // WASD movement
        if(Input.GetKey(KeyCode.D)) {
                Debug.Log("D");
                gameObject.transform.Translate(Vector3.right * Time.deltaTime * 3f);
        } if(Input.GetKey(KeyCode.A)) {
                gameObject.transform.Translate(Vector3.left * Time.deltaTime * 3f);
        } if(Input.GetKey(KeyCode.S)) {
                gameObject.transform.Translate(Vector3.back * Time.deltaTime * 3f);
        } if(Input.GetKey(KeyCode.W)) {
                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 3f);
        }
    }
}
