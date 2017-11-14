using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour {
	float ct;
	TextMesh text;
	GameObject manager;
	RectTransform button;
	int score;
	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
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
			score = GameObject.Find ("GameManager").GetComponent<GameControl>().count;
			button.position = new Vector3 (330, 300, 0);
			text.transform.position = new Vector3 (0, 2, 0);
			text.color = Color.white;
			if (score >= 20) {
				text.text = "PLAYER 1 WINS";
			} else if(score < 20) {
				text.text = "PLAYER 2 WINS";
			}
			text.fontSize = 12;
			Time.timeScale = 0;

		}
	}
}