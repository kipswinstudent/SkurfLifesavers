using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepingScore : MonoBehaviour {

	public Text scoreTextP1;
	public Text scoreTextP2;

	public int P1Score;
	public int P2Score;

	void Start()
	{
		
	}

	void Update()
	{
		scoreTextP1.text = P1Score.ToString();
		scoreTextP2.text = P2Score.ToString();
	}


}
