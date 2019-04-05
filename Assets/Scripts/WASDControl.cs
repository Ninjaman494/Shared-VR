using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

public class WASDControl : MonoBehaviour
{
    public GameObject cam;
    public TrackedPoseDriver poseDriver;
    public float sensitivity = 2f;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    void Start() {
        // Disable pose driver if not on Android
         if (Application.platform != RuntimePlatform.Android){
            poseDriver.enabled = false;
        }
    }


    // Update is called once per frame
    void Update() {
        if (axes == RotationAxes.MouseXAndY) {
            float rotationX = cam.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            //cam.transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            cam.transform.localRotation = Quaternion.Euler(-rotationY, 0, 0);
            transform.Rotate(new Vector3(0, rotationX, 0));
        } else if (axes == RotationAxes.MouseX) {
            cam.transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        } else {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);

            cam.transform.localEulerAngles = new Vector3(-rotationY, cam.transform.localEulerAngles.y, 0);
        }

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
