using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour {
	GameObject manager;
	AudioSource audio;
	public bool isHit = false;
	ParticleSystem splash;
	GameObject ps;
	Transform p2;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameManager");
		splash = GameObject.Find ("Splash").GetComponent<ParticleSystem> ();
		ps = GameObject.Find ("Splash");
		p2 = GameObject.Find ("Player2").GetComponent<Transform> ();
		this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D colliderThatHitMe){
		if (colliderThatHitMe.tag == "Player2") { //check to see if the colliding object had the tag 'Ball'
			audio.Play();
			if (colliderThatHitMe.name == "Player2") {
				if (this.name == "ScoreZone1") {
					ps.transform.position = new Vector3 (5.43f, p2.position.y, 0);
					ps.transform.localEulerAngles = new Vector3 (0, -90, 0);   
				} else if (this.name == "ScoreZone2") {
					ps.transform.position = new Vector3 (p2.position.x, -5.43f, 0);
					ps.transform.localEulerAngles = new Vector3 (-90, -90, 0); 
				} else if (this.name == "ScoreZone3") {
					ps.transform.position = new Vector3 (p2.position.x, 5.43f, 0);
					ps.transform.localEulerAngles = new Vector3 (90, -90, 0); 
				} else if (this.name == "ScoreZone4") {
					ps.transform.position = new Vector3 (-5.43f, p2.position.y, 0);
					ps.transform.localEulerAngles = new Vector3 (0, 90, 0); 
				}
				splash.Play ();
			}
			if (isHit == false) {
				isHit = true;
				this.GetComponent<SpriteRenderer> ().color = Color.gray;
				manager.SendMessage ("WallHit");
			}
		}
	}
}
