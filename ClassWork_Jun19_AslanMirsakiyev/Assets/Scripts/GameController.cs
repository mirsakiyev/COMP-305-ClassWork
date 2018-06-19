using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    

    public GameObject[] prefabs = new GameObject[7];

    public float prefabDelay = 20;
    public float timeElapsedToNextPiece = 0; // seconds
    public Transform respawn;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        timeElapsedToNextPiece += Time.deltaTime;

        if (timeElapsedToNextPiece > prefabDelay)
        {

            int idx = Random.Range(0, prefabs.Length);
            GameObject newPrefab = prefabs[idx];
            Instantiate(newPrefab, respawn);
        }

    }
}
