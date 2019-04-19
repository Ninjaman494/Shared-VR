using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// Script used to provide WASD and mouse controls when on PC.
/// Also has jump support.
///
/// author: Akash Eldo (axe1412)
public class FPSControl : MonoBehaviour {

    public GameObject cam;
    public float speed = 2f;
    public float sensitivity = 2f;
    public float jumpDistance = 5f;

    private float moveFB, moveLR, rotX, rotY, verticalVelocity;
    private CharacterController charCon;
    Animator anim;

    // Start is called before the first frame update
    void Start() {
        charCon = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -60f, 60f);

        Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);
        transform.Rotate(0,rotX,0);
        cam.transform.localRotation = Quaternion.Euler(rotY,0,0);

        movement = transform.rotation * movement;
        charCon.Move(movement * Time.deltaTime);

        if(charCon.isGrounded) {
            if(Input.GetButtonDown("Jump")) {
                verticalVelocity = jumpDistance;
            }
        }

        if(charCon.velocity.x != 0 || charCon.velocity.z != 0) {
            anim.SetFloat("Speed", 1);
        } else {
            anim.SetFloat("Speed", 0);
        }

    }

    void FixedUpdate() {
        if(!charCon.isGrounded) {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
            anim.SetBool("Jump", true);
        } else {
            anim.SetBool("Jump", false);
        }
    }
}
