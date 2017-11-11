using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStick : MonoBehaviour {
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (2.5f + Mathf.Sin (Time.timeSinceLevelLoad*3) * 0.3f, 2.46f, 0);
	}
}
