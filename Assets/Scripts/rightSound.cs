
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightSound : MonoBehaviour {
	//this code is use for control the sound output for ball and stick collide
	Transform rightTrans;
	AudioSource hit;
	// Use this for initialization
	void Start () {
		rightTrans = GameObject.Find ("right").GetComponent<Transform> ();
		hit = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		transform.position = rightTrans.position;
		transform.localRotation = rightTrans.localRotation;
	}
	void OnTriggerEnter2D(Collider2D colliderThatHitMe){
		if (colliderThatHitMe.tag == "Player2") {
			hit.Play ();
		}
	}
}
