using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    FieldController cansFieldCtrl, roundsFieldCtrl;
    static int currentLevel = 1;
    int maxLevel = 3;
    static int currentHealth = 100;

    void Start () {
        GameObject cansField = GameObject.Find ("Health Field");
        if (cansField != null) {
            cansFieldCtrl = cansField.GetComponent<FieldController> ();
            cansFieldCtrl.SetValue (currentHealth);
        }
        GameObject roundsField = GameObject.Find ("Level Field");
        if (roundsField != null) {
            roundsFieldCtrl = roundsField.GetComponent<FieldController> ();
            roundsFieldCtrl.SetValue (currentLevel);
        }
    }

    public void CompleteLevel () {
        if (maxLevel == currentLevel) {
            SceneManager.LoadScene ("EndScreen");
        } else {
            SceneManager.LoadScene ("Level Success");
        }
    }

    public void LoadNextLevel () {
        currentLevel = currentLevel + 1;
        SceneManager.LoadScene (currentLevel);
    }

    public void LoseHealth (int value) {
        currentHealth -= value;
        if (currentHealth < 1) {
            SceneManager.LoadScene ("Wasted");
        }

        if (cansFieldCtrl != null) {
            cansFieldCtrl.SetValue (currentHealth);
        }
    }

    public void AddHealth (int value) {
        currentHealth += value;

        if (cansFieldCtrl != null) {
            cansFieldCtrl.SetValue (currentHealth);
        }
    }

    public void RestartLevel () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    public void StartGame () {
        currentLevel = 1;
        currentHealth = 100;
        SceneManager.LoadScene (currentLevel);
    }
}