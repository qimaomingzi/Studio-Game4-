using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOneControl : MonoBehaviour {
	Rigidbody2D[] rb;
	SpriteRenderer[] sr;
	Transform tr;
	Transform trShadow;
	Transform[] t;
	public Text cd1;
	public Text cd2;
	public float MaxSpeed;
	float Cooldown =  6;
	float Cooldown2 = 10;
	float SkillTime = 0;
	float SkillTime2 =0;
	float RotateTime = 0;
	float RotateAngle = 0.5f;
	char direction = 'n';
	bool Stretch = false;
	bool Grow = false;
	bool canMove;
	bool isVertical = false;
	bool notRotating = true;
	GameObject Skill1;
	GameObject Skill2;
	AudioSource stretchSound;
	AudioSource growSound;

	// Use this for initialization
	void Start () {
		rb = GetComponentsInChildren<Rigidbody2D> ();
		sr = GetComponentsInChildren<SpriteRenderer> ();
		t = GetComponentsInChildren<Transform> ();
		//trShadow = GameObject.Find ("Player2Shadow").GetComponent<Transform> ();
		tr = GameObject.Find ("Player2").GetComponent<Transform> ();
		canMove = true;
		Skill1 = GameObject.Find ("Stretch");
		Skill2 = GameObject.Find ("Grow");
		stretchSound = GameObject.Find("Stretch").GetComponent<AudioSource> ();
		growSound = GameObject.Find ("Grow").GetComponent<AudioSource> ();

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (canMove) {
			if (isVertical) {
				if (Input.GetAxis ("Stick2") > 0) {
					rb [0].AddForce (Vector2.left * 400);
					rb [0].velocity = new Vector2 (Mathf.Min (rb [0].velocity.x, 20),0);
					rb [1].AddForce (Vector2.left * 400);
					rb [1].velocity = new Vector2 (Mathf.Min (rb [1].velocity.x, 20),0);
				} else if (Input.GetAxis ("Stick2") < 0) {
					rb [0].AddForce (Vector2.right * 400);
					rb [0].velocity = new Vector2 (Mathf.Max (rb [0].velocity.x, -20),0);
					rb [1].AddForce (Vector2.right * 400);
					rb [1].velocity = new Vector2 (Mathf.Max (rb [1].velocity.x, -20),0);
				}
				if (Mathf.Abs (rb [0].velocity.x) > MaxSpeed) {
					rb [0].velocity = new Vector2 ( rb [0].velocity.x / Mathf.Abs (rb [0].velocity.x) * MaxSpeed,0);
					rb [1].velocity = new Vector2 ( rb [1].velocity.x / Mathf.Abs (rb [1].velocity.x) * MaxSpeed,0);
				}
			} else {
				if (Input.GetAxis ("Stick") > 0) {
					rb [0].AddForce (Vector2.up * 400);
					rb [0].velocity = new Vector2 (0, Mathf.Min (rb [0].velocity.y, 20));
					rb [1].AddForce (Vector2.up * 400);
					rb [1].velocity = new Vector2 (0, Mathf.Min (rb [1].velocity.y, 20));
				} else if (Input.GetAxis ("Stick") < 0) {
					rb [0].AddForce (Vector2.down * 400);
					rb [0].velocity = new Vector2 (0, Mathf.Max (rb [0].velocity.y, -20));
					rb [1].AddForce (Vector2.down * 400);
					rb [1].velocity = new Vector2 (0, Mathf.Max (rb [1].velocity.y, -20));
				}
				if (Mathf.Abs (rb [0].velocity.y) > MaxSpeed) {
					rb [0].velocity = new Vector2 (0, rb [0].velocity.y / Mathf.Abs (rb [0].velocity.y) * MaxSpeed);
					rb [1].velocity = new Vector2 (0, rb [1].velocity.y / Mathf.Abs (rb [1].velocity.y) * MaxSpeed);
				}
			}
		}
		if (Input.GetKeyDown ("space") && notRotating) {
			direction = 'l';
			canMove = false;
			notRotating = false;
			rb [0].velocity = Vector2.zero;
			rb [1].velocity = Vector2.zero;
			if (isVertical) {
				t [1].position = new Vector3 (0, 4.8f, 0);
				t [2].position = new Vector3 (0, -4.8f, 0);
			} else {
				t [1].position = new Vector3 (-4.8f,0, 0);
				t [2].position = new Vector3 (4.8f, 0, 0);
			}

		}
		if (direction == 'l') {
			
			RotateTime += Time.deltaTime;
			if (RotateTime <= RotateAngle) {
				transform.localEulerAngles = Vector3.forward * 90 * RotateTime / 0.5f;
			}
			if (RotateTime > RotateAngle) {
				direction = 'n';
				RotateAngle += 0.5f;
				canMove = true;
				notRotating = true;
				isVertical = !isVertical;
				if (isVertical) {
					rb [0].constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
					rb [1].constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
				} else {
					rb [0].constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
					rb [1].constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
				}
			}

		}


		//P1 first skill stretch
		if (Input.GetButtonDown ("P1Skill1") && Cooldown == 6) {
			Stretch = true;
			stretchSound.Play ();
			Debug.Log (SkillTime);
			SkillTime = 0;
			Skill1.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.25f);

		}
		if (Stretch) {
			Cooldown = 0;
			SkillTime += Time.deltaTime;
			rb [0].drag = 6;
			rb [1].drag = 6;
			if (SkillTime <= 0.5f) {
				transform.localScale = new Vector3(1,transform.localScale.y+ Time.deltaTime*1.6f,1);
			} else if (SkillTime >= 3.25f && SkillTime <3.5f) {
				transform.localScale = new Vector3(1,transform.localScale.y- 2*Time.deltaTime*1.6f,1);

			} else if (SkillTime >= 3.5f) {
				Stretch = false;

				transform.localScale = Vector3.one;
				rb [0].drag = 3;
				rb [1].drag = 3;

			}
		}
		//P1 second skill blow
		if (Input.GetButtonDown ("P1Skill2") && Cooldown2 == 10) {
			Grow = true;
			growSound.Play ();
			SkillTime2 = 0;
			Skill2.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.25f);
		}
		if (Grow) {
			Cooldown2 = 0;
			SkillTime2 += Time.deltaTime;
			if (SkillTime2 <= 1) {
				tr.localScale = new Vector3(tr.localScale.x+Time.deltaTime*2,tr.localScale.y+ Time.deltaTime*2,1);
				//trShadow.localScale = new Vector3(tr.localScale.x+Time.deltaTime*2,tr.localScale.y+ Time.deltaTime*2,1);
			} else if (SkillTime2 >= 4 && SkillTime2 <6) {
				tr.localScale = new Vector3(tr.localScale.x-Time.deltaTime,tr.localScale.y- Time.deltaTime,1);
				//trShadow.localScale = new Vector3(tr.localScale.x-Time.deltaTime,tr.localScale.y- Time.deltaTime,1);
			} else if (SkillTime2 >= 6) {
				Grow = false;
				tr.localScale = new Vector3(0.5f,0.5f,1);
				//trShadow.localScale = new Vector3(0.5f,0.5f,1);
			}
		}
		Cooldown = Mathf.Min (6, Cooldown += Time.deltaTime);
		cd1.text = (6-(int)Cooldown).ToString();
		Cooldown2 = Mathf.Min (10, Cooldown2 += Time.deltaTime);
		cd2.text = (10-(int)Cooldown2).ToString();
		if (Cooldown == 5) {
			Skill1.GetComponent<SpriteRenderer> ().color = Color.white;
		}
		if (Cooldown2 == 10) {
			Skill2.GetComponent<SpriteRenderer> ().color = Color.white;
		}

	}

}
