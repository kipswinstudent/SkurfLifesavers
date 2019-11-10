using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 1.0f;
	[Header ("Set Player Bounds")]
	public float Upper;
	public float Lower;
	public float Left;
	public float Right;

	bool checking = false;
	bool disableMovement = false;
	public float checkTimer;
	float timer;
	SpriteRenderer thisSR;

	public GameObject LifePreserver;
	public Vector3 home;
	LifePreserverController RingScript;

	// Use this for initialization
	void Start () {
		RingScript = LifePreserver.GetComponent<LifePreserverController> ();
		thisSR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!disableMovement) {
			if (Input.GetKey (KeyCode.A)) {
				Vector3 temp = transform.position;
				temp.x -= speed;
				transform.position = temp;
			}
			if (Input.GetKey (KeyCode.S)) {
				Vector3 temp = transform.position;
				temp.y += speed;
				transform.position = temp;
			}
		}
			
		if (transform.position.y > Upper) {
			Vector3 temp = transform.position;
			temp.y = Lower;
			transform.position = temp;
		}
		if (transform.position.x < Left) {
			Vector3 temp = transform.position;
			temp.x = Right;
			transform.position = temp;
		}
		if (!Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.S)) {
			
			PrepareToThrow ();


			//Invoke ("ThrowRing", 2);
			//probably need to rewrite this as a coroutine
			//switch off player icon ONCE THROWING RING
			//then disable ring and return control and start count over

		} else {
			checking = false;
		}
		if (checking && Time.time > timer) {
			ThrowRing ();
		}
		CheckRing ();
	}

	void ThrowRing (){
		if (checking) {
			LifePreserver.SetActive(true);
			RingScript.targetPos = transform.position;
			LifePreserver.transform.position = RingScript.homePos;
			checking = false;
			disableMovement = true;
			thisSR.enabled = false;
		}
	}

	void PrepareToThrow()
	{
		if (!checking) {
			timer = checkTimer + Time.time;
			checking = true;
		}
	}

	void CheckRing()
	{
		if (RingScript.AtTarget) {
			//LifePreserver.transform.position = RingScript.homePos;
			RingScript.AtTarget = false;
			LifePreserver.SetActive (false);
			disableMovement = false;
			thisSR.enabled = true;
			//checking = false;
		}
	}
}
