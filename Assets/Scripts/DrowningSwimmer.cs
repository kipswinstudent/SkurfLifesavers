using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrowningSwimmer : MonoBehaviour {

	public GameObject swimmerDrowning;
	public GameObject swimmerSaved;
	//public GameObject drowned;

	public float drowningTimer;
	float timeToDrown;
	bool saved = false;

	// Use this for initialization
	void Start () {
		timeToDrown = Time.time + drowningTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToDrown) {
			if (!saved) {
				//Destroy (gameObject); //do drowning animation
			}
			if (saved) {
				Destroy (gameObject);
				//also need to increment score
			}

		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Ring") {
			Debug.Log ("Hit with ring!!");
			swimmerDrowning.SetActive (false);
			swimmerSaved.SetActive (true);
			saved = true;
		}
	}


}
