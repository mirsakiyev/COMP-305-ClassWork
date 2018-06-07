using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 1f;
    public float jumpScale = 10f;
    public float moveX = 0f;

    private Vector3 origPos;
    private bool grounded = true;
    private bool isJumping = true;

    private Rigidbody rb;

    private LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    public float ceilingCheckRadius = 0.1f;

    private Transform groundCheck;
    private Transform ceilingCheck;

    private void Awake()
    {
        groundCheck = GameObject.Find("GroundCheck").transform;
        ceilingCheck = GameObject.Find("CeilingCheck").transform;
        rb = this.GetComponent<Rigidbody2D>();
        origPos = this.transform.position;
    }

	// Use this for initialization
	void Start () {

        this.origPos = this.transform.position;
        print("orig.pos:" + origPos);

        //rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update () {

        if (grounded)
        {
			HandleInputs();
			Move();
        }


        //ConstrainMovement();

	}

    private void FixedUpdate()
    {
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position,
                                                            groundCheckRadius,
                                                            groundLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject!=this.gameObject)
            {
                grounded = true;
            }
        }
    }


	private void Move()
	{
		if (moveX != 0)
		{
			Vector3 newPos = transform.position + new Vector3(moveX, 0, 0); ;
			transform.position = newPos;
            grounded = false;
		}


		if (grounded && isJumping)
		{
			Vector2 rf = new Vector2(moveX, 10);
			grounded = false;
			rb.AddRelativeForce(rf * jumpScale);
			//rb.velocity = rf;
		}
        /*
		else
		{
			//Vector2 rf = new Vector2(moveX, 0);
			//grounded = true;
			//rb.AddRelativeForce(rf*jumpScale);
			//rb.velocity = rf;
		}*/
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
        if (grounded)
        {
            moveX = Input.GetAxis("Horizontal");
        }

        if (grounded && !isJumping)
        {
			float mj = Input.GetAxis("Jump");
			if (mj != 0 && !isJumping)
			{
				isJumping = true;
			}
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
