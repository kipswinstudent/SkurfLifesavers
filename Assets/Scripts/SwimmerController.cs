using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerController : MonoBehaviour {

	int StartPoint;
	float swimAngle;
	float terminus;
	public float swimSpeed = 1;
	public GameObject DrowningSwimmer;
	bool swimAngleNeg = true;
	Animator thisAnim;

	SpriteRenderer ThisSR;
	public float hitTimer;
	float timeTilFade;
	bool swimmerhit = false;

	void Start()
	{
		ThisSR = GetComponent<SpriteRenderer> ();
		thisAnim = GetComponent<Animator> ();
	}

	void Awake () {
		StartPoint = Random.Range (-5, 5);
		swimAngle = Random.Range (-1.0f, 1.0f);
		terminus = Random.Range (0.0f, 1.0f);
		if (swimAngle > 0) {
			Vector3 tempScale = transform.localScale;
			tempScale.x = -1;
			transform.localScale = tempScale;
			swimAngleNeg = false;
		}
		Vector3 temp = transform.position;
		temp.x = StartPoint;
		temp.y = -2;
		transform.position = temp;

		Invoke ("MoveSwimmer", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= terminus) {
			Instantiate (DrowningSwimmer, transform.position, Quaternion.identity);
			Destroy (gameObject);
		}

		if (transform.position.y > 0.48f) {
			ThisSR.sortingOrder = 1;
		} else if (transform.position.y > -0.6f) {
			ThisSR.sortingOrder = 3;
		} else if (transform.position.y > -1.4f) {
			ThisSR.sortingOrder = 5;
		}

		if (swimmerhit && Time.time > timeTilFade) {
			Destroy (gameObject);
		}
	}

	private void MoveSwimmer()
	{
		Vector3 temp = transform.position;
		temp.y += swimSpeed;
		temp.x += swimAngle;
		if (swimAngleNeg && temp.x < -4.7f) {
			temp.x = -4.7f;
			swimAngle = 0;
		}
		if (!swimAngleNeg && temp.x > 4.7f) {
			temp.x = 4.7f;
			swimAngle = 0;
		}
		transform.position = temp;
		if (!swimmerhit) {
			Invoke ("MoveSwimmer", 2);
		}

	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Ring") {
			thisAnim.SetBool ("Hit", true);
			swimmerhit = true;
			timeTilFade = Time.time + hitTimer;

		}
		//also need to work out a way to avoid overlapping swimmers and drowners
	}
}
