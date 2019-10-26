using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmerController : MonoBehaviour {

	int StartPoint;
	public float swimSpeed = 1;

	void Awake () {
		StartPoint = Random.Range (-7, 7);
		Vector3 temp = transform.position;
		temp.x = StartPoint;
		temp.y = 4;
		transform.position = temp;

		Invoke ("MoveSwimmer", 1);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y <= -4) {
			Destroy (gameObject);
		}
	}

	private void MoveSwimmer()
	{
		Vector3 temp = transform.position;
		temp.y -= swimSpeed;
		transform.position = temp;



		Invoke ("MoveSwimmer", 2);
	}
}
