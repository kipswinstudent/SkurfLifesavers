using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRunner : MonoBehaviour {

	public float idleTimer;
	public float GameTime;
	float timeTilQuit;
	float gameOverTime; 

	public Text timerText;

	bool isGameOver = false;

	// Use this for initialization
	void Start () {
		gameOverTime = Time.time + GameTime;
		timeTilQuit = Time.time + idleTimer;
		StartCoroutine ("Countdown");
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			timeTilQuit = Time.time + idleTimer;
		}

		int min = Mathf.FloorToInt (GameTime / 60);
		int sec = Mathf.FloorToInt (GameTime % 60);
        if (sec < 10) {
            timerText.text = (min + ":0" + sec);
        }
        else {
            timerText.text = (min + ":" + sec);
        }
        

		if (Time.time > timeTilQuit) {
			SceneManager.LoadScene (0);
		}

		if (Time.time > gameOverTime) {
			DoGameOver ();
		}

		if (isGameOver) {
			if (Input.anyKeyDown) {
				SceneManager.LoadScene (0);
			}
		}
	}

	IEnumerator Countdown(){
		while (true) {
			yield return new WaitForSeconds (1);
			GameTime--;
		}
	}

	private void DoGameOver()
	{
        //switch time off
        //press any button to go back to main menu
        //make a score screen come up
        SceneManager.LoadScene(0);
	}
}
