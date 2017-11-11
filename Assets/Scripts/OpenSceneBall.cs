using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSceneBall : MonoBehaviour {
	Rigidbody2D rb;	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.AddTorque (100);
		rb.velocity = new Vector2 (Random.value, Random.value).normalized * 10;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.timeSinceLevelLoad% 5  < 1) {
			rb.AddRelativeForce (Vector2.one * 100);
		}
	}
}
