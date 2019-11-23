using System.Collections;
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
		Vector3 temp = transform.position;
		if (temp.x > 5.5f) {
			temp.x = 5.5f;
			transform.position = temp;
		}
		if (temp.x < -5.5f) {
			temp.x = -5.5f;
			transform.position = temp;
		}
    }
	
	// Update is called once per frame
	void Update () {
		if (Time.time > timeToDrown) {
            countingScript.numberOfObjects -= 1;
            if (!saved) {
				Destroy (gameObject); //do drowning animation
                scoreScript.P1Score -= 500;
                scoreScript.P2Score -= 500;
			}
			if (saved) {
				Destroy (gameObject);
                
			}

		}

	}

	void OnTriggerEnter2D (Collider2D other)
	{
        if (!saved) {
            if (other.tag == "Ring")
            {
                Debug.Log("Hit with ring!!");
                swimmerDrowning.SetActive(false);
                scoreScript.P1Score += score;
                swimmerSaved.SetActive(true);
                saved = true;
            }
            if (other.tag == "Ring2")
            {
                Debug.Log("Hit with ring!!");
                swimmerDrowning.SetActive(false);
                scoreScript.P2Score += score;
                swimmerSaved.SetActive(true);
                saved = true;
            }
        }
        
	}


}
