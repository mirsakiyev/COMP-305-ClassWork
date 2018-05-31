using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Dictionary<string, GameObject> pieces = new Dictionary<string, GameObject>();
    private string[] keys={"O","I","J"};
    private GameObject currentGO;


    public void NextPiece()
    {
		currentKey = keys[Random.Range(0, keys.Length)];
		currentGO = pieces[currentKey];
		Instantiate(currentGO, new Vector3(0, 12, 0), Quaternion.identity);

    }
    private string currentKey;

    public GameObject tetrisOPrefab;
    // [][]
    // [][]

    public GameObject tetrisIPrefab;
	// []
    // []
    // []
    // []

	public GameObject tetrisJPrefab;
    //   []
    //   []
    //   []
    // [][]


	// Use this for initialization
	void Start () {
		pieces["O"] = tetrisOPrefab;
        pieces["I"] = tetrisIPrefab;
        pieces["J"] = tetrisJPrefab;
        NextPiece();
     

        //pieces["L"] = tetrisLPrefab;
        //pieces["S"] = tetrisSPrefab;
        //pieces["Z"] = tetrisZPrefab;
        //pieces["T"] = tetrisTPrefab;

	}
	
	// Update is called once per frame
	void Update () {
        //yield return new WaitForSeconds(5);
	}
}
