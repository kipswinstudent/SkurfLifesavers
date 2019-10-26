using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwimmers : MonoBehaviour {

	public GameObject swimmer;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnSwimmer", 6);
	}
	
	// Update is called once per frame
	void Update () {
		

	}

	private void SpawnSwimmer()
	{
		Instantiate (swimmer);
		Invoke ("SpawnSwimmer", 6);
	}
}
