using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float speed = 6.0f;
	Transform groundCheck;
	private float overlapRadius = 0.2f;
	public LayerMask whatIsGround;
	private bool grounded = false;
	private bool jump = false;
	public float jumpForce = 600f;
	private bool doubleJump = false;
	Animator anim;

	void Start()
	{
		groundCheck = transform.Find("Groundcheck");
		anim = GetComponent<Animator> ();
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			jump = true;	
		}
	}


	void FixedUpdate()
	{
        //get the rigidbody2d()
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();

		//check if grounded
		grounded = Physics2D.OverlapCircle (groundCheck.position, overlapRadius, whatIsGround);

		//reset double jump when on the ground
		if (grounded) 
		{
			doubleJump = false;
		}

		//testig if player can jump
		bool canJump = (grounded || !doubleJump);

		//set animetion
		anim.SetBool("Jumping", canJump && jump);

        if (jump && canJump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
            rigidbody2D.AddForce(new Vector2(0, jumpForce));

            if (!grounded)
            {
                doubleJump = true;
            }

        }
        jump = false;
    
		GetComponent<Rigidbody2D>().velocity = new Vector2 (speed, GetComponent<Rigidbody2D>().velocity.y);
	}
}
