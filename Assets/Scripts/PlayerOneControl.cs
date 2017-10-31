using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneControl : MonoBehaviour {
	Rigidbody2D[] rb;
	SpriteRenderer[] sr;
	bool isLeft = true;
	// Use this for initialization
	void Start () {
		rb = GetComponentsInChildren<Rigidbody2D> ();
		sr = GetComponentsInChildren<SpriteRenderer> ();
		sr [0].color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () {
		if (isLeft) {
			if (Input.GetAxis ("Stick") > 0) {
				rb [0].velocity = new Vector2 (0, 5);
			} else if (Input.GetAxis ("Stick") < 0){
				rb [0].velocity = new Vector2 (0, -5);
			}
		}
		if (!isLeft) {
			if (Input.GetAxis ("Stick") > 0) {
				rb [1].velocity = new Vector2 (0, 5);
			} else if (Input.GetAxis ("Stick") < 0){
				rb [1].velocity = new Vector2 (0, -5);
			}
		}
		if (Input.GetKeyDown ("a")) {
			isLeft = true;
			sr [0].color = Color.gray;
			sr [1].color = Color.white;
		}
		if (Input.GetKeyDown ("d")) {
			isLeft = false;
			sr [1].color = Color.gray;
			sr [0].color = Color.white;
		}

	}
}
