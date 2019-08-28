using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    GameManager gm;

    void Start () {
        GameObject cansField = GameObject.Find ("GameManager");
        if (cansField != null) {
            gm = cansField.GetComponent<GameManager> ();
        }
    }

    public void PlayGame () {
        gm.StartGame ();
    }

    public void ExitGame () {
        Application.Quit ();
    }

    public void LoadNextLevel () {
        gm.LoadNextLevel ();
    }
}