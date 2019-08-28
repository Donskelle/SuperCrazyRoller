using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOutOfBounds : MonoBehaviour {
    public float threshold = -1.0f;

    Transform trans;

    void Start () {
        trans = GetComponent<Transform> ();
    }

    void FixedUpdate () {
        if (trans.position.y < threshold) {
            Destroy (gameObject);
        }
    }
}