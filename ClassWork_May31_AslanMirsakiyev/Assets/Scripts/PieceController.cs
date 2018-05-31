using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceController : MonoBehaviour {
    public float speed=2f;
    public GameController gameController;

    // Use this for initialization
    void Start () {
        gameController = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position -= new Vector3(0, speed * Time.deltaTime);  
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag) ;
        gameController.NextPiece();
    }
}
