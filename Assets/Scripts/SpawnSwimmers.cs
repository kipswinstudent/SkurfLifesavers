using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwimmers : MonoBehaviour {

	public GameObject swimmer;
    public GameObject BeerCan;
    public int numberOfObjects;
    public int numberOfCans;
    

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
                
		Invoke ("SpawnSwimmer", Random.Range(4, 7));
	}

    private void SpawnCan()
    {
        if (numberOfObjects <= 4)
        {
            if (numberOfCans <= 2)
            {
                Instantiate(BeerCan);
                numberOfObjects += 1;
                numberOfCans += 1;
            }
            
        }

		Invoke("SpawnCan", Random.Range(12, 17));
    }
}
