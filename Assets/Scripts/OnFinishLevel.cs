using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnFinishLevel : MonoBehaviour {
    public GameManager gameManager;

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Player") {
            gameManager.CompleteLevel ();
        }
    }
}