using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public static bool followCamera = false;
    public Vector3 offsetPosition;
    public float rotationSmoothTime = .12f;
    public float dstFromTarget = 15;

    Vector3 velocity = Vector3.zero;
    Transform target;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;
    float yaw;

    void Start () {
        GameObject pl = GameObject.Find ("Player");
        target = pl.GetComponent<Transform> ();
    }

    void LateUpdate () {
        if (Input.GetKeyDown (KeyCode.C)) {
            followCamera = !followCamera;
        }

        if (!followCamera) {
            Vector3 desiredPosition = target.position + offsetPosition;
            Vector3 smoothedPosition = Vector3.SmoothDamp (transform.position, desiredPosition, ref velocity, 0.3F);
            transform.position = smoothedPosition;
            transform.eulerAngles = Vector3.zero;

            transform.LookAt (target);
        } else {
            // Quelle 3
            yaw += Input.GetAxis ("Mouse X") * 10;

            currentRotation = Vector3.SmoothDamp (currentRotation, new Vector3 (30, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
            transform.eulerAngles = currentRotation;

            transform.position = target.position - transform.forward * dstFromTarget;
        }
    }
}