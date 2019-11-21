using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerCanController : MonoBehaviour {

	public float startY;
	int startX;
	float landValue;
	int layerValue;
	public float fallSpeed;
    public int score;

	SpriteRenderer thisRenderer;
	Animator canAnim;
	public Sprite fullCan;
	public Sprite floatCan;
	public Sprite savedCan;
	public AudioSource splash;
	bool landed = false;
    bool saved = false;
    KeepingScore scoreScript;
    SpawnSwimmers countingScript;
    public GameObject[] startPoints; 

    int timeTilfade = 2;
    float fadeTimer;

	// Use this for initialization
	void Start () {
		thisRenderer = GetComponentInChildren <SpriteRenderer> ();
		canAnim = GetComponentInChildren<Animator> ();
        scoreScript = GameObject.Find("GameRunner").GetComponent<KeepingScore>();
        countingScript = GameObject.Find("GameRunner").GetComponent<SpawnSwimmers>();
        //thisRenderer.sprite = fullCan;
        //startX = Random.Range (0, startPoints.Length-1);
		landValue = Random.Range (-1.4f, 1.4f);

		//transform.position = startPoints[startX].transform.position;
	}

	// Update is called once per frame
	void Update () {
		
		if (!landed) {
			CheckIfLanded ();
			Vector3 fall = transform.position;
			fall.y -= fallSpeed;
			transform.position = fall;
		}

        if (Time.time > fadeTimer && saved) {
            Destroy(gameObject);
            countingScript.numberOfObjects--;
            countingScript.numberOfCans--;
        }
	}

	private void CheckIfLanded()
	{
		if (transform.position.y < landValue) {
			landed = true;
			thisRenderer.sprite = floatCan;
			canAnim.SetBool ("Floating", true);
			splash.Play ();
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!saved) {
            if (other.tag == "Ring")
            {
                Debug.Log("Can hit with ring!!");
                scoreScript.P1Score += score;
                thisRenderer.sprite = savedCan;
                fadeTimer = timeTilfade + Time.time;
                saved = true;
            }
            if (other.tag == "Ring2")
            {
                Debug.Log("Can hit with ring!!");
                scoreScript.P2Score += score;
                thisRenderer.sprite = savedCan;
                fadeTimer = timeTilfade + Time.time;
                saved = true;
            }
        }
        
    }
}
