using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {
	public Text score;
	int count;
	GameObject scoreZone1;
	GameObject scoreZone2;
	GameObject scoreZone3;
	GameObject scoreZone4;
	// Use this for initialization
	void Start () {
		count = 0;
		scoreZone1 = GameObject.Find ("ScoreZone1");
		scoreZone2 = GameObject.Find ("ScoreZone2");
		scoreZone3 = GameObject.Find ("ScoreZone3");
		scoreZone4 = GameObject.Find ("ScoreZone4");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void WallHit(){
		count++;
		if (count % 4 == 0) {
			score.text = (count / 4).ToString();
			scoreZone1.GetComponent<SpriteRenderer> ().color = Color.clear;
			scoreZone1.GetComponent<ScoreControl> ().isHit = false;

			scoreZone2.GetComponent<SpriteRenderer> ().color = Color.clear;
			scoreZone2.GetComponent<ScoreControl> ().isHit = false;

			scoreZone3.GetComponent<SpriteRenderer> ().color = Color.clear;
			scoreZone3.GetComponent<ScoreControl> ().isHit = false;

			scoreZone4.GetComponent<SpriteRenderer> ().color = Color.clear;
			scoreZone4.GetComponent<ScoreControl> ().isHit = false;

		}
	}
	public void ResetGame(){
		SceneManager.LoadScene ("OpenScene");
	}
	public void EnterGame(){
		SceneManager.LoadScene ("StartScene");
	}
}
