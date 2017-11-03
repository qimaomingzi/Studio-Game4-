using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour {
	Rigidbody2D rb2d;
	public float torque;
	public float MaxSpeed;
	int STR = 100;
	float SkillTime = 0;
	float Cooldown = 5;
	bool BulletTime = false;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		float speed;
		float turn = Input.GetAxis("Horizontal");
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


		Cooldown = Mathf.Min (5, Cooldown += Time.deltaTime);
	}

}
