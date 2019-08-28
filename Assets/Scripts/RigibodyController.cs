using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigibodyController : MonoBehaviour {
    public static bool followCamera = false;
    public float speed = 15.0f;
    public float jumpSpeed = 2.0f;

    Rigidbody rb;
    bool isGrounded;
    int countConnected;
    Transform cam;
    Vector3 storDir;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        isGrounded = true;
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update () {
        // change camera 
        if (Input.GetKeyDown (KeyCode.C)) {
            followCamera = !followCamera;
        }

        if (isGrounded) {
            float moveHorizontal = Input.GetAxis ("Horizontal");
            float moveVertical = Input.GetAxis ("Vertical");
            storDir = cam.right;

            if (Input.GetButton ("Jump")) {
                rb.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
            }

            if (followCamera) {
                rb.AddForce (((storDir * moveHorizontal) + (cam.forward * moveVertical)) * speed);
            } else {
                Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

                rb.AddForce (movement * speed);
            }
        }
    }

    void OnCollisionEnter (Collision theCollision) {
        if (theCollision.gameObject.tag == "Board") {
            isGrounded = true;
            countConnected += 1;
        }
    }

    void OnCollisionExit (Collision theCollision) {
        if (theCollision.gameObject.tag == "Board") {
            countConnected -= 1;
            if (countConnected == 0)
                isGrounded = false;
        }
    }
}