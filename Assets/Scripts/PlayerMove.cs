﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public float normalSpeed = 20.0f;
    public float dashSpeed = 40f;
    public float dashTimer = 0.5f;
    private bool isDashing = false;
	Transform groundCheck;
	private float overlapRadius = 0.2f;
	public LayerMask whatIsGround;
	private bool grounded = false;
	private bool jump = false;
	public float jumpForce = 600f;
	private bool doubleJump = false;
    private float speed;
	Animator anim;

    

	void Start()
	{
		groundCheck = transform.Find("Groundcheck");
		anim = GetComponent<Animator> ();
        speed = normalSpeed;
	}

	void Update() 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			jump = true;	
		}
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!isDashing)
            {
                StopCoroutine(Dash());
                StartCoroutine(Dash());
            }
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

    private IEnumerator Dash()
    {
        float timer = 0f;

        StartDash();
       
        while (timer < dashTimer)
        {
            timer += Time.deltaTime;
            yield return new WaitForSeconds(0);
        }
        StopDash();
    }

    private void StartDash()
    {
        speed = dashSpeed;
        isDashing = true;
    }

    private void StopDash()
    {
        speed = normalSpeed;
        isDashing = false;
    }
}
