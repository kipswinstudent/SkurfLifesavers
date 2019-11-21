using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {

    SwimmerController parentScript;

	void Start () {
        parentScript = GetComponentInParent<SwimmerController>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Loot")
        {
            parentScript.FlipDirection();  
        }
    }

}
