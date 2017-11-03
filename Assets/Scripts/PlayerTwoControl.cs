using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoControl : MonoBehaviour {
	Rigidbody2D rb2d;
	public float torque;
	public float MaxSpeed;
	int STR = 100;
	float SkillTime = 0;
	float SkillTime2 = 0;
	float Cooldown = 5;
	float Cooldown2 = 3;
	bool BulletTime = false;
	bool Shake = false;
	GameObject shadow;
	Vector3 CurrentPosition = Vector3.zero;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		CurrentPosition = transform.position;
		shadow = GameObject.Find ("Player2Shadow");
	}

	// Update is called once per frame
	void Update () {
		float speed;
		float turn = Input.GetAxis("Horizontal");
		CurrentPosition = transform.position;
		if (rb2d.angularVelocity < 1500 && turn < 0) {
			rb2d.AddTorque (-torque * turn);
		} else if (rb2d.angularVelocity > -1500 && turn > 0) {
			rb2d.AddTorque (-torque * turn);
		}
		speed = Mathf.Sqrt (rb2d.velocity.x * rb2d.velocity.x + rb2d.velocity.y * rb2d.velocity.y);
		if (Input.GetAxis("Vertical")> 0) {
			rb2d.angularVelocity = 0;
			rb2d.AddRelativeForce (Vector2.right* STR);

		}
		if (Input.GetKeyDown("down")) {
			rb2d.velocity = new Vector2(rb2d.velocity.x/5,rb2d.velocity.y/5);
		}
		if (speed > MaxSpeed) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x / speed * MaxSpeed, rb2d.velocity.y / speed * MaxSpeed);
		}

		//First Skill Bullet time
		if (Input.GetButtonDown ("P2Skill1") && Cooldown == 5) {
			BulletTime = true;
			SkillTime = 0;
			torque *= 3;
			STR *= 3;
		}
		if (BulletTime) {
			Time.timeScale = 0.3f;
			Debug.Log (SkillTime);
			SkillTime += Time.deltaTime;
			if (SkillTime >= 1) {
				Time.timeScale = 1;
				BulletTime = false;
				Cooldown = 0;
				torque /= 3;
				STR /= 3;
			}
		}

		//Second Skill Shake ball
		if (Input.GetKeyDown ("k") && Cooldown2 == 3) {
			Debug.Log ("in");
			Shake = true;
			SkillTime2 = 0;
			shadow.transform.position = transform.position;
			shadow.transform.localRotation = transform.localRotation;
			shadow.GetComponent<Rigidbody2D> ().velocity = rb2d.velocity;
			shadow.GetComponent<Rigidbody2D> ().angularVelocity = rb2d.angularVelocity;
		}
		if (Shake) {
			Debug.Log ("running");
			transform.position = new Vector3(Mathf.Max(-9,Mathf.Min(shadow.transform.position.x+Random.value*2-1,9)),
											 Mathf.Max(-4,Mathf.Min(shadow.transform.position.y+Random.value*2-1,4)),
										     0);

			SkillTime2 += Time.deltaTime;
			if (SkillTime2 >= 1) {
				Shake = false;
				Cooldown2 = 0;
				this.transform.position = shadow.transform.position;
				this.transform.localRotation = shadow.transform.localRotation;
				rb2d.velocity = shadow.GetComponent<Rigidbody2D> ().velocity;
				rb2d.angularVelocity = shadow.GetComponent<Rigidbody2D> ().angularVelocity;
			}
		}

		Cooldown = Mathf.Min (5, Cooldown += Time.deltaTime);
		Cooldown2 = Mathf.Min (3, Cooldown2 += Time.deltaTime);
	}

}
