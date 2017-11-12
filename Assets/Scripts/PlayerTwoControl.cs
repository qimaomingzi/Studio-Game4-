using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTwoControl : MonoBehaviour {
	Rigidbody2D rb2d;
	public Text cd1;
	public Text cd2;
	public float torque;
	public float MaxSpeed;
	int STR = 100;
	float SkillTime = 0;
	float SkillTime2 = 0;
	float Cooldown = 5;
	float Cooldown2 = 3;
	bool BulletTime = false;
	bool Shake = false;
	public GameObject P2Dupe;
	GameObject shadow;
	GameObject Skill1;
	GameObject Skill2;
	Vector3 CurrentPosition = Vector3.zero;
	AudioSource dupeSound;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		dupeSound = GameObject.Find ("Dupe").GetComponent<AudioSource> ();
		CurrentPosition = transform.position;
		Skill2 = GameObject.Find ("Dupe");
		Skill1 = GameObject.Find ("BulletTime");
		torque = 100;
		MaxSpeed = 10;
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
			Skill1.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.25f);
		}
		if (BulletTime) {
			Cooldown = 0;
			Time.timeScale = 0.3f;
			Debug.Log (SkillTime);
			SkillTime += Time.deltaTime;
			if (SkillTime >= 1) {
				Time.timeScale = 1;
				BulletTime = false;

				torque /= 3;
				STR /= 3;
			}
		}

		//Second Skill Shake ball
		if (Input.GetKeyDown ("k") && Cooldown2 == 3) {
			Shake = true;
			dupeSound.Play ();
			SkillTime2 = 0;
			shadow = Instantiate (P2Dupe,new Vector2(Random.Range(-4,4),Random.Range(-4,4)),Quaternion.identity) as GameObject;
			shadow.transform.localScale = transform.localScale;
			shadow.GetComponent<Rigidbody2D> ().velocity = rb2d.velocity;
			shadow.GetComponent<Rigidbody2D> ().angularVelocity = rb2d.angularVelocity;
			Skill2.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.25f);
		}
		if (Shake) {
			Cooldown2 = 0;
			SkillTime2 += Time.deltaTime;
			shadow.transform.localScale = transform.localScale;
			if (SkillTime2 >= 5) {
				Shake = false;
				if (Random.value <= 0.5f) {
					GameObject.Destroy (shadow);
				} else {
					this.transform.position = shadow.transform.position;
					this.transform.localRotation = shadow.transform.localRotation;
					rb2d.velocity = shadow.GetComponent<Rigidbody2D> ().velocity;
					rb2d.angularVelocity = shadow.GetComponent<Rigidbody2D> ().angularVelocity;
					GameObject.Destroy (shadow);
				}
			}
		}

		if (Cooldown == 5) {
			Skill1.GetComponent<SpriteRenderer> ().color = Color.white;
		}
		if (Cooldown2 == 3) {
			Skill2.GetComponent<SpriteRenderer> ().color = Color.white;
		}

		Cooldown = Mathf.Min (5, Cooldown += Time.deltaTime);
		cd1.text = (5-(int)Cooldown).ToString();
		Cooldown2 = Mathf.Min (3, Cooldown2 += Time.deltaTime);
		cd2.text = (3-(int)Cooldown2).ToString();
	}

}
