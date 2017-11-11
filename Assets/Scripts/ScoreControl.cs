using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreControl : MonoBehaviour {
	GameObject manager;
	AudioSource audio;
	public bool isHit = false;
	// Use this for initialization
	void Start () {
		manager = GameObject.Find ("GameManager");
		this.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0);
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D colliderThatHitMe){
		if (colliderThatHitMe.tag == "Player2") { //check to see if the colliding object had the tag 'Ball'
			audio.Play();
			if (isHit == false) {
				isHit = true;
				this.GetComponent<SpriteRenderer> ().color = Color.gray;
				manager.SendMessage ("WallHit");
			}
		}
	}
}
