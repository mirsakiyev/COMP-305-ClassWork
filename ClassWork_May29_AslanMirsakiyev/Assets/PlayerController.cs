using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public float speed = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        print("Input.mousePosition:" + Input.mousePosition);
        float mx = Input.GetAxis("Horizontal");
        float mxr = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxis("Vertical");
        float myr = Input.GetAxisRaw("Vertical");

        print("mx: "+mx+ "mxr: "+mxr);
        print("my: "+my+ "myr: "+myr);

        Vector3 dir = new Vector3(mx, my,0);
        dir = dir.normalized;

        transform.position += dir*speed*Time.deltaTime;

	}
}
