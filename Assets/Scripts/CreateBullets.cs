using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBullets : MonoBehaviour {
    public GameObject bullet;
    public float shotsPerSeconds;
    public float shotDelay;

    Transform bulletPoint;
    Transform player;
    float shotCounter;
    bool hasWaited = false;

    // Use this for initialization
    void Start () {
        GameObject goPlayer = GameObject.Find ("Player");
        player = goPlayer.GetComponent<Transform> ();
        bulletPoint = GetComponent<Transform> ();

        StartCoroutine (StartTimer ());
    }

    // Update is called once per frame
    void Update () {
        if (hasWaited) {
            float probability = Time.deltaTime * shotsPerSeconds;
            if (Random.value < probability) {
                Fire ();
            }
        }
    }
    void Fire () {
        GameObject bulletClone = Instantiate (bullet, bulletPoint.position, bulletPoint.rotation);
        Rigidbody bulletRig = bulletClone.GetComponent<Rigidbody> ();
        bulletRig.velocity = (player.position - bulletPoint.position).normalized * 30;
    }

    IEnumerator StartTimer () {
        yield return new WaitForSeconds (shotDelay);
        hasWaited = true;
    }
}