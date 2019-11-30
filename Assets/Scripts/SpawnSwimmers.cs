using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwimmers : MonoBehaviour {

	public GameObject swimmer;
    public GameObject BeerCan;
    public int numberOfObjects;
    public int numberOfCans;

	public GameObject[] swimmerSpawn;
	public GameObject[] CanSpawn;

	Vector3 swimmerStart;
	Vector3 canStart; 
    

    // Use this for initialization
    void Start () {
		Invoke ("SpawnSwimmer", 2);
        Invoke("SpawnCan", 15);
	}
	
	// Update is called once per frame
	void Update () {
       
	}

	private void SpawnSwimmer()
	{
		
		if (numberOfObjects <= 4)
        {
			swimmerStart = swimmerSpawn [Random.Range (0, swimmerSpawn.Length)].transform.position;
			Instantiate(swimmer, swimmerStart, Quaternion.identity);
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
				canStart = CanSpawn [Random.Range (0, CanSpawn.Length)].transform.position;
				Instantiate(BeerCan, canStart, Quaternion.identity);
                numberOfObjects += 1;
                numberOfCans += 1;
            }
            
        }

		Invoke("SpawnCan", Random.Range(12, 17));
    }
}
