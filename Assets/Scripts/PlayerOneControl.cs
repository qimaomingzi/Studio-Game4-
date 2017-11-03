using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneControl : MonoBehaviour {
	Rigidbody2D[] rb;
	SpriteRenderer[] sr;
	public float MaxSpeed;
	bool isLeft = true;

	// Use this for initialization
	void Start () {
		rb = GetComponentsInChildren<Rigidbody2D> ();
		sr = GetComponentsInChildren<SpriteRenderer> ();
		sr [1].color = Color.gray;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isLeft) {
			if (Input.GetAxis ("Stick") > 0) {
				rb [0].AddForce (Vector2.up * 400);
				rb [0].velocity = new Vector2(0,Mathf.Min (rb [0].velocity.y, 20));
			} else if (Input.GetAxis ("Stick") < 0){
				rb [0].AddForce (Vector2.down * 400);
				rb [0].velocity = new Vector2 (0, Mathf.Max (rb [0].velocity.y, -20));
			}
			if (Mathf.Abs (rb [0].velocity.y) > MaxSpeed) {
				rb [0].velocity = new Vector2(0, rb [0].velocity.y/Mathf.Abs (rb [0].velocity.y)*MaxSpeed);
			}
		}
		if (!isLeft) {
			if (Input.GetAxis ("Stick") > 0) {
				rb [1].AddForce (Vector2.up * 400);
				rb [1].velocity = new Vector2(0,Mathf.Min (rb [1].velocity.y, 20));
			} else if (Input.GetAxis ("Stick") < 0){
				rb [1].AddForce (Vector2.down * 400);
				rb [1].velocity = new Vector2 (0, Mathf.Max (rb [1].velocity.y, -20));
			}
			if (Mathf.Abs (rb [1].velocity.y) > MaxSpeed) {
				rb [1].velocity = new Vector2(0, rb [1].velocity.y/Mathf.Abs (rb [1].velocity.y) *MaxSpeed );
			}
		}
		if (Input.GetKeyDown ("a")) {
			isLeft = true;
			sr [1].color = Color.gray;
			sr [0].color = Color.white;
			rb [1].velocity *= 0.2f;

		}
		if (Input.GetKeyDown ("d")) {
			isLeft = false;
			sr [0].color = Color.gray;
			sr [1].color = Color.white;
			rb [0].velocity *= 0.2f;
		}

	}

}
