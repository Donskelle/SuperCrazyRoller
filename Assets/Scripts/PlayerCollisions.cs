using System.Collections;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour {
    GameManager gm;

    void Start () {
        GameObject go = GameObject.Find ("GameManager");
        if (go != null) {
            gm = go.GetComponent<GameManager> ();
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.tag == "Heal") {
            gm.AddHealth (30);
            Destroy (other.gameObject);
        }
    }

    void OnCollisionEnter (Collision collisionInfo) {
        foreach (ContactPoint contact in collisionInfo.contacts) {
            if (contact.otherCollider.tag == "Collision") {
                gm.LoseHealth (15);
            } else if (contact.otherCollider.tag == "Lava") {
                gm.LoseHealth (30);
            } else if (contact.otherCollider.tag == "MovingEnemy" || contact.otherCollider.tag == "Bullet") {
                gm.LoseHealth (50);
            }
        }
    }
}