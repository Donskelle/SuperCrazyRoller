using UnityEngine;

public class PlayerFalling : MonoBehaviour {
    public float threshold;

    GameManager gm;

    void Start () {
        GameObject go = GameObject.Find ("GameManager");
        if (go != null) {
            gm = go.GetComponent<GameManager> ();
        }
    }

    void FixedUpdate () {
        if (transform.position.y < threshold) {
            gm.LoseHealth (100);
        }
    }
}