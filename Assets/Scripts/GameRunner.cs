using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRunner : MonoBehaviour {

    public GameObject StartMenu;
    public GameObject PauseScreen;

    bool startActive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startActive)
        {
            if (Input.anyKeyDown)
            {
                StartMenu.SetActive(false);
                //and start the game
            }
        }
	}
}
