using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1f;
    public float jumpScale = 10f;
    private Vector3 origPos;
    private bool grounded = true;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        this.origPos = this.transform.position;
        print("orig.pos:" + origPos);

        //rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        HandleInputs();

        ConstrainMovement();


	}

    void ConstrainMovement()
    {
        float newX = this.transform.position.x;
        float newY = this.transform.position.y;

        //if methods for newX
        if (newX<-8)
        {
            newX = 8;
            grounded = false;
        }

		if (newX > 8)
		{
			newX = 8;
			grounded = false;
		}


		//if methods for newY
		if (newY < 5)
		{
			newX = 5;
			grounded = false;
		}

		if (newX < -5)
		{
			newX = 5;
			grounded = false;
		}
    }

    void HandleInputs()
    {

        float mx = Input.GetAxis("Horizontal");
        //float my = Input.GetAxis("Vertical");

        if(mx!=0)
        {
            Vector3 movement = new Vector3(mx, 0, 0);
            Vector3 newPos = transform.position + movement;
            transform.position = newPos;
        }

        float mj=Input.GetAxis("Jump");

        if (mj!=0)
        {
            Vector2 rf = new Vector2(0, 1);
            grounded = false;
            //rb.AddRelativeForce(rf*jumpScale);
        }
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
        string tag = other.gameObject.tag;
        if (tag=="Deathline")
        {
            print("Player is dead");
            this.transform.position = origPos + new Vector3(0, 3, 0);
        }

        if (tag=="Platform")
        {
            grounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
	{

	}

	private void OnTriggerExit2D(Collider2D other)
	{

	}





}
