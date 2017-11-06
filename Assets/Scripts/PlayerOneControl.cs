using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneControl : MonoBehaviour {
	Rigidbody2D[] rb;
	SpriteRenderer[] sr;
	Transform tr;
	Transform trShadow;
	public float MaxSpeed;
	float Cooldown =  10;
	float Cooldown2 = 8;
	float SkillTime = 0;
	float SkillTime2 =0;
	bool Stretch = false;
	bool Grow = false;
	bool isLeft = true;

	// Use this for initialization
	void Start () {
		rb = GetComponentsInChildren<Rigidbody2D> ();
		sr = GetComponentsInChildren<SpriteRenderer> ();
		trShadow = GameObject.Find ("Player2Shadow").GetComponent<Transform> ();
		tr = GameObject.Find ("Player2").GetComponent<Transform> ();
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
		//P1 first skill stretch
		if (Input.GetButtonDown ("P1Skill1") && Cooldown == 10) {
			Stretch = true;
			Debug.Log (SkillTime);
			SkillTime = 0;

		}
		if (Stretch) {
			Cooldown = 0;
			SkillTime += Time.deltaTime;
			rb [0].drag = 6;
			rb [1].drag = 6;
			if (SkillTime <= 1) {
				transform.localScale = new Vector3(1,transform.localScale.y+ Time.deltaTime,1);
			} else if (SkillTime >= 3.5f && SkillTime <4) {
				transform.localScale = new Vector3(1,transform.localScale.y- 2*Time.deltaTime,1);

			} else if (SkillTime >= 4) {
				Stretch = false;

				transform.localScale = Vector3.one;
				rb [0].drag = 3;
				rb [1].drag = 3;

			}
		}
		//P1 second skill blow
		if (Input.GetButtonDown ("P1Skill2") && Cooldown2 == 8) {
			Grow = true;
			SkillTime2 = 0;
		}
		if (Grow) {
			Cooldown2 = 0;
			SkillTime2 += Time.deltaTime;
			if (SkillTime2 <= 1) {
				tr.localScale = new Vector3(tr.localScale.x+Time.deltaTime*2,tr.localScale.y+ Time.deltaTime*2,1);
				trShadow.localScale = new Vector3(tr.localScale.x+Time.deltaTime*2,tr.localScale.y+ Time.deltaTime*2,1);
			} else if (SkillTime2 >= 4 && SkillTime2 <6) {
				tr.localScale = new Vector3(tr.localScale.x-Time.deltaTime,tr.localScale.y- Time.deltaTime,1);
				trShadow.localScale = new Vector3(tr.localScale.x-Time.deltaTime,tr.localScale.y- Time.deltaTime,1);
			} else if (SkillTime2 >= 6) {
				Grow = false;

				tr.localScale = new Vector3(0.5f,0.5f,1);
				trShadow.localScale = new Vector3(0.5f,0.5f,1);
			}
		}
		Cooldown = Mathf.Min (10, Cooldown += Time.deltaTime);
		Cooldown2 = Mathf.Min (8, Cooldown2 += Time.deltaTime);

	}

}
