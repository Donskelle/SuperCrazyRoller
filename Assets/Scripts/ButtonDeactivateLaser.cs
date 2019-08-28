using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDeactivateLaser : MonoBehaviour {
    public GameObject laser;
    Renderer mat;

    void Start () {
        mat = GetComponent<Renderer> ();
    }

    void OnCollisionEnter () {
        Destroy (laser);
        mat.material.SetColor ("_Color", Color.green);
    }
}