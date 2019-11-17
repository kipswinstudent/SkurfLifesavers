using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwimmers : MonoBehaviour {

	public GameObject swimmer;
    public GameObject BeerCan;
    public int numberOfObjects;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnSwimmer", 2);
        Invoke("SpawnCan", 15);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(numberOfObjects + " objects");
	}

	private void SpawnSwimmer()
	{
        if (numberOfObjects <= 4)
        {
            Instantiate(swimmer);
            numberOfObjects += 1;
        }
                
		Invoke ("SpawnSwimmer", 6);
	}

    private void SpawnCan()
    {
        if (numberOfObjects <= 4)
        {
            Instantiate(BeerCan);
            numberOfObjects += 1;
        }

        Invoke("SpawnCan", 15);
    }
}
