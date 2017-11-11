
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftSound : MonoBehaviour {
	//this code is use for control the sound output for ball and stick collide
	Transform leftTrans;
	AudioSource hit;
	// Use this for initialization
	void Start () {
		leftTrans = GameObject.Find ("left").GetComponent<Transform> ();
		hit = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = leftTrans.position;
		transform.localRotation = leftTrans.localRotation;
	}
	void OnTriggerEnter2D(Collider2D colliderThatHitMe){
		if (colliderThatHitMe.tag == "Player2") {
			hit.Play ();
		}
	}
}
