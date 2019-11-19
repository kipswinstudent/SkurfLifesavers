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

	public GameObject gameScreen;
	public GameObject GOScreen;
	public Text P1Final;
	public Text P2Final;
	public Text winner;
	KeepingScore scoreScript;

	public AudioSource beachSounds;

	bool pressA = false;
	bool pressS = false;
	bool pressK = false;
	bool pressL = false;

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
			if(Input.GetKeyDown(KeyCode.A)){
				pressA = true;
			}
			if(Input.GetKeyDown(KeyCode.S)){
				pressS = true;
			}
			if(Input.GetKeyDown(KeyCode.K)){
				pressK = true;
			}
			if(Input.GetKeyDown(KeyCode.L)){
				pressL = true;
			}

			if (pressA && pressS && pressK && pressL) {
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
		if (Input.anyKeyDown) {
			SceneManager.LoadScene(0);
		}
	}
}
