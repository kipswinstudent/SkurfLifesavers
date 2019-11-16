﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrowningSwimmer : MonoBehaviour {

	public GameObject swimmerDrowning;
	public GameObject swimmerSaved;
	//public GameObject drowned;
	KeepingScore scoreScript;
    SpawnSwimmers countingScript;
	public int score;

	public float drowningTimer;
	float timeToDrown;
	bool saved = false;


	// Use this for initialization
	void Start () {
		timeToDrown = Time.time + drowningTimer;
		scoreScript = GameObject.Find ("GameRunner").GetComponent<KeepingScore> ();
        countingScript = GameObject.Find("GameRunner").GetComponent<SpawnSwimmers>();

    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToDrown) {
			if (!saved) {
				//Destroy (gameObject); //do drowning animation
			}
			if (saved) {
				Destroy (gameObject);
                countingScript.numberOfObjects -= 1;
			}

		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Ring") {
			Debug.Log ("Hit with ring!!");
			swimmerDrowning.SetActive (false);
			scoreScript.P1Score += score;
			swimmerSaved.SetActive (true);
			saved = true;
		}
		if (other.tag == "Ring2") {
			Debug.Log ("Hit with ring!!");
			swimmerDrowning.SetActive (false);
			scoreScript.P2Score += score;
			swimmerSaved.SetActive (true);
			saved = true;
		}
	}


}
