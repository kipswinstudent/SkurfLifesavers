using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerCanController : MonoBehaviour {

	public float startY;
	float startX;
	float landValue;
	int layerValue;
	public float fallSpeed;
    public int score;

	SpriteRenderer thisRenderer;
	Animator canAnim;
	public Sprite fullCan;
	public Sprite floatCan;
	public Sprite savedCan;
	bool landed = false;
    KeepingScore scoreScript;

	// Use this for initialization
	void Start () {
		thisRenderer = GetComponentInChildren <SpriteRenderer> ();
		canAnim = GetComponentInChildren<Animator> ();
        scoreScript = GameObject.Find("GameRunner").GetComponent<KeepingScore>();
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ring")
        {
            Debug.Log("Can hit with ring!!");
            scoreScript.P1Score += score;
			thisRenderer.sprite = savedCan;

        }
        if (other.tag == "Ring2")
        {
            Debug.Log("Can hit with ring!!");
            scoreScript.P2Score += score;
			thisRenderer.sprite = savedCan;
        }
    }
}
