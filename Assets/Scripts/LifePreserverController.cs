using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePreserverController : MonoBehaviour {

	public GameObject target;
	public float ringSpeed = 0.2f;
	public Vector3 targetPos;
	public Vector3 homePos;
	public bool AtTarget = false;

	CircleCollider2D circleC;


	// Use this for initialization
	void Start () {
		circleC = GetComponent<CircleCollider2D> ();
		//targetPos = target.transform.position;
		//homePos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, targetPos) < 0.001f) {
			AtTarget = true;
		} else {
			transform.position = Vector3.MoveTowards (transform.position, targetPos, ringSpeed);
		}

		if (Vector3.Distance (transform.position, targetPos) < 0.1f) {
			circleC.enabled = true;
		} else {
			circleC.enabled = false;
		}
	}
}
