using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerCanController : MonoBehaviour {

	public float startY;
	float startX;
	float landValue;
	int layerValue;
	public float fallSpeed;

	SpriteRenderer thisRenderer;
	Animator canAnim;
	public Sprite fullCan;
	public Sprite floatCan;
	bool landed = false;

	// Use this for initialization
	void Start () {
		thisRenderer = GetComponentInChildren <SpriteRenderer> ();
		canAnim = GetComponentInChildren<Animator> ();
		//thisRenderer.sprite = fullCan;
		startX = Random.Range (-5.0f, 5.0f);
		landValue = Random.Range (-1.4f, 1.4f);

		Vector3 temp = transform.position;
		temp.x = startX;
		temp.y = startY;
		transform.position = temp;
	}



	// Update is called once per frame
	void Update () {
		
		if (!landed) {
			CheckIfLanded ();
			Vector3 fall = transform.position;
			fall.y -= fallSpeed;
			transform.position = fall;
		}
	}

	private void CheckIfLanded()
	{
		if (transform.position.y < landValue) {
			landed = true;
			thisRenderer.sprite = floatCan;
			canAnim.SetBool ("Floating", true);
		}
	}
}
