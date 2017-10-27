using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoControl : MonoBehaviour {
	Rigidbody2D rb2d;
	public float torque;
	float ForceX;
	float ForceY;
	const float AngelToRadian= 180/Mathf.PI;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		float turn = Input.GetAxis("Horizontal");
		rb2d.AddTorque(-torque * turn);
		ForceX = Mathf.Cos (transform.localEulerAngles);
		ForceY = Mathf.Sin (transform.localRotation.z*Mathf.PI);
		Debug.Log (ForceX + "   " + transform.localRotation.z*Mathf.PI);

		if (Input.GetAxis("Vertical")> 0) {
			rb2d.AddForce (new Vector2 (ForceX, ForceY)* 10);
		}
		if (Input.GetAxis ("Vertical") < 0) {
			rb2d.angularVelocity = 0;
			rb2d.velocity = Vector2.zero;
		}
	}
}
