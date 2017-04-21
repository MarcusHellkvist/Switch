using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rbody;

	public float moveSpeed;
	public float jumpHeight;
	private float moveVelocity;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	void Start () {
		rbody = GetComponent<Rigidbody2D>();		
	}

	void FixedUpdate (){
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	void Update () {

		if(grounded)
			doubleJumped = false;

		if(Input.GetKeyDown(KeyCode.Space) && grounded){
			Jump();
		}

		if(Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded){
			Jump();
			doubleJumped = true;
		}

		moveVelocity = 0f;

		if(Input.GetKey(KeyCode.RightArrow)){
			//rbody.velocity = new Vector2 (moveSpeed, rbody.velocity.y);
			moveVelocity = moveSpeed;
		}

		if(Input.GetKey(KeyCode.LeftArrow)){
			//rbody.velocity = new Vector2 (-moveSpeed, rbody.velocity.y);
			moveVelocity = -moveSpeed;
		}

		rbody.velocity = new Vector2(moveVelocity, rbody.velocity.y);
	}

	void Jump (){
		rbody.velocity = new Vector2 (rbody.velocity.x, jumpHeight);
	}
}
