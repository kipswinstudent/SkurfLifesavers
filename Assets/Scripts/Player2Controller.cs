using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour {
    public float speed = 1.0f;
    [Header("Set Player Bounds")]
    public float Upper;
    public float Lower;
    public float Left;
    public float Right;

    bool checking = false;
	bool disableMovement = false;
	public float checkTimer2;
	float timer2;
	SpriteRenderer thisSR;
	bool buttonsPressed = false;

	public GameObject LifePreserver2;
	public GameObject chairRing;
	public Vector3 home;
	LifePreserverController RingScript;

	GameRunner gameScript;
	public GameObject GameRunner;

	void Start () {
		RingScript = LifePreserver2.GetComponent<LifePreserverController> ();
		thisSR = GetComponent<SpriteRenderer> ();
		gameScript = GameRunner.GetComponent<GameRunner> ();
	}

    void Update()
    {
		if (!gameScript.isGameOver) {
			if (!disableMovement) {
				if (Input.GetKey(KeyCode.L))
				{
					Vector3 temp = transform.position;
					temp.x += speed;
					transform.position = temp;
					buttonsPressed = true;
				}
				if (Input.GetKey(KeyCode.K))
				{
					Vector3 temp = transform.position;
					temp.y += speed;
					transform.position = temp;
					buttonsPressed = true;
				}
			}
		}


        if (transform.position.y > Upper)
        {
            Vector3 temp = transform.position;
            temp.y = Lower;
            transform.position = temp;
        }
        if (transform.position.x > Right)
        {
            Vector3 temp = transform.position;
            temp.x = Left;
            transform.position = temp;
        }
		if (!Input.GetKey(KeyCode.L) && !Input.GetKey(KeyCode.K) && buttonsPressed)
        {
			PrepareToThrow ();
        }
        else
        {
            checking = false;
        }
		if (checking && Time.time > timer2) {
			ThrowRing ();
		}
		CheckRing ();
	}

	void ThrowRing (){
		if (checking) {
			LifePreserver2.SetActive(true);
			chairRing.SetActive (false);
			RingScript.targetPos = transform.position;
			LifePreserver2.transform.position = RingScript.homePos;
			checking = false;
			disableMovement = true;
			thisSR.enabled = false;
		}
	}

	void PrepareToThrow()
	{
		if (!checking) {
			timer2 = checkTimer2 + Time.time;
			checking = true;
		}
	}

	void CheckRing()
	{
		if (RingScript.AtTarget) {
			//LifePreserver.transform.position = RingScript.homePos;
			RingScript.AtTarget = false;
			RingScript.hitSomething = false;
			LifePreserver2.SetActive (false);
			chairRing.SetActive (true);
			disableMovement = false;
			thisSR.enabled = true;
			//checking = false;
		}
	}
}