﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {
	float ct;
	TextMesh text;
	GameObject manager;
	RectTransform button;
	// Use this for initialization
	void Start () {
		//a = GameObject.Find().
		text = GetComponent<TextMesh> ();
		manager = GameObject.Find ("GameManager");
		ct = 60;
		text.color = new Vector4(1,1,1,0.6f);
		button = GameObject.Find ("Button").GetComponent<RectTransform>();
	}

	// Update is called once per frame
	void Update () {
		ct -= Time.deltaTime; 
		text.text = ((int)ct).ToString ();
		text.color = new Color(1,1,1,0.1f+0.7f*(ct/45));
		if (ct <= 0) {
			button.position = new Vector3 (330, 300, 0);
			text.transform.position = new Vector3 (0, 2, 0);
			text.color = Color.white;
			text.text = "GAME OVER";
			text.fontSize = 15;
			Time.timeScale = 0;

		}
	}
}