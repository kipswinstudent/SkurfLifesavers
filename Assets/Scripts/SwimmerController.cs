using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerController : MonoBehaviour {

	int StartPoint;
	float swimAngle;
	float terminus;
	public float swimSpeed = 1;
	public GameObject DrowningSwimmer;


	SpriteRenderer ThisSR;

	void Start()
	{
		ThisSR = GetComponent<SpriteRenderer> ();
	}

	void Awake () {
		StartPoint = Random.Range (-5, 5);
		swimAngle = Random.Range (-1.0f, 1.0f);
		terminus = Random.Range (0.0f, 1.0f);
		if (swimAngle > 0) {
			Vector3 tempScale = transform.localScale;
			tempScale.x = -1;
			transform.localScale = tempScale;
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
	}

	private void MoveSwimmer()
	{
		Vector3 temp = transform.position;
		temp.y += swimSpeed;
		temp.x += swimAngle;
		transform.position = temp;

		Invoke ("MoveSwimmer", 2);
	}
}
