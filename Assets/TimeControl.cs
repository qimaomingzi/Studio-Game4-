using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeControl : MonoBehaviour {
	float ct;
	TextMesh text;
	GameObject manager;
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh> ();
		manager = GameObject.Find ("GameManager");
		ct = 45;
		text.color = new Vector4(1,1,1,0.6f);
	}

	// Update is called once per frame
	void Update () {
		ct -= Time.deltaTime; 
		text.text = ((int)ct).ToString ();
		text.color = new Color(1,1,1,0.1f+0.7f*(ct/45));
		if (ct <= 0) {
			Time.timeScale = 0;

		}
	}
}