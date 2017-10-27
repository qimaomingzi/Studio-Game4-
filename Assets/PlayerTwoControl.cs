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
		if (rb2d.angularVelocity < 1000 && turn < 0) {
			rb2d.AddTorque (-torque * turn);
		} else if (rb2d.angularVelocity > -1000 && turn > 0) {
			rb2d.AddTorque (-torque * turn);
		}
		Debug.Log (rb2d.angularVelocity);

		if (Input.GetAxis("Vertical")> 0 && Mathf.Sqrt(rb2d.velocity.x*rb2d.velocity.x + rb2d.velocity.y *rb2d.velocity.y)<=20) {
			rb2d.angularVelocity = 0;
			rb2d.AddRelativeForce (Vector2.right* 10);
		}
		if (Input.GetKeyDown("down")) {
			rb2d.velocity = new Vector2(rb2d.velocity.x/3,rb2d.velocity.y/3);
		}
	}
}
