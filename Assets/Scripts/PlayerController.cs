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


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
			Debug.Log ("Checking for loot!");
			checking = true;
		} else {
			checking = false;
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (checking) {
			if (other.tag == "Loot") {
				Destroy(other.gameObject);
				Debug.Log ("Picked up a loot!");	
				//collect that loot
			}
		}
	}
}
