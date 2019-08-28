using UnityEngine;
using UnityEngine.UI;

public class FieldController : MonoBehaviour {
	Text textComp;

	void Awake () {
		textComp = GetComponent<Text> ();
	}

	public void SetValue (int value) {
		textComp.text = value.ToString ();
	}

	public void SetValue (string value) {
		textComp.text = value;
	}
}