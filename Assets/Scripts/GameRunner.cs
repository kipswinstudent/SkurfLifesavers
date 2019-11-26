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

	public bool isGameOver = false;

	public GameObject gameScreen;
	public GameObject GOScreen;
	public Text P1Final;
	public Text P2Final;
	public Text winner;
	KeepingScore scoreScript;

	public AudioSource beachSounds;


	// Use this for initialization
	void Start () {
		gameOverTime = Time.time + GameTime;
		timeTilQuit = Time.time + idleTimer;
		StartCoroutine ("Countdown");
		Time.timeScale = 1;
		scoreScript = GetComponent<KeepingScore> ();
		beachSounds.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isGameOver) {
			if (Input.anyKeyDown) {
				timeTilQuit = Time.time + idleTimer;
			}
			if (Time.time > timeTilQuit) {
				SceneManager.LoadScene (0);
			}
		}


		int min = Mathf.FloorToInt (GameTime / 60);
		int sec = Mathf.FloorToInt (GameTime % 60);
        if (sec < 10) {
            timerText.text = (min + ":0" + sec);
        }
        else {
            timerText.text = (min + ":" + sec);
        }
        
		if (Time.time > gameOverTime && !isGameOver) {
			DoGameOver ();
		}

		if (isGameOver) {
			if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.K) && Input.GetKey(KeyCode.L)) {
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
		Time.timeScale = 0;
        //switch time off
        isGameOver = true;
		GOScreen.SetActive(true);
		gameScreen.SetActive (false);
		P1Final.text = scoreScript.P1Score.ToString();
		P2Final.text = scoreScript.P2Score.ToString();
		if (scoreScript.P1Score > scoreScript.P2Score) {
			winner.text = "Player 1 wins!!";
		} 
		if (scoreScript.P1Score < scoreScript.P2Score){
			winner.text = "Player 2 wins!!";
		}
		if (scoreScript.P1Score == scoreScript.P2Score) {
			winner.text = "it's a draw!!";
		}

	}
}
