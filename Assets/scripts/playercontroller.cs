﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
	private Rigidbody2D playerRB;
	private Animator playerAnims;
	private SpriteRenderer spriteRenderer;
	private OnGroundDetect playerFeetTrigger;
	public ParticleSystem deathParticle;
	public StateManager stateManager;
	
	public float jumpForce = 10.0f;
	public float moveSpeed = 15.0f;
	public float sprintSpeed = 20.0f;
	public float coyoteTime = 0.3f;
	//public float gravityModifier;
	
	private float speedThisFrame;
	
	public bool onGround;
	public bool jumping;
	public bool dead = false;
	
	private bool deadLastFrame;
	
	public KeyCode jump, left, right, jumpAlt, leftAlt, rightAlt, sprint;//, rewind, rewindAlt;
	
	// FOR REWIND: suspend RB simulation and player controller. log dead, position, velocity, current frame, current animation, onGround, jumping.
	
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
		playerAnims = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		playerFeetTrigger = GameObject.Find("player_feet").GetComponent<OnGroundDetect>();
		Debug.Log(Physics2D.gravity);
		//Physics2D.gravity *= gravityModifier;
		onGround = false;
		jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
		if(!deadLastFrame && dead)
		{
			Debug.Log("dead");
			deadLastFrame = true;
			deathParticle.Play();
			playerRB.simulated = false;
			spriteRenderer.enabled = false;
		}
		else if(deadLastFrame && !dead)
		{
			deadLastFrame = false;
			playerRB.simulated = true;
			spriteRenderer.enabled = true;
		}
			
		if(!dead && !stateManager.rewind){
			if(Input.GetKey(sprint) && (Input.GetKey(left) || Input.GetKey(leftAlt) || Input.GetKey(right) || Input.GetKey(rightAlt))) { speedThisFrame = sprintSpeed; 
			playerAnims.SetInteger("walk_mode", 2);}
			else if (Input.GetKey(left) || Input.GetKey(leftAlt) || Input.GetKey(right) || Input.GetKey(rightAlt)) { speedThisFrame = moveSpeed; 
			playerAnims.SetInteger("walk_mode", 1); }
			else { playerAnims.SetInteger("walk_mode", 0); }
			
			if((onGround || (Time.time - playerFeetTrigger.coyoteTime <= coyoteTime && !jumping)) && (Input.GetKeyDown(jump) || Input.GetKeyDown(jumpAlt))) {
				playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
				playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
				onGround = false;
				jumping = true;
			}
			
			if((Input.GetKeyUp(jump) || Input.GetKeyUp(jumpAlt)) && jumping)
			{
				playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y*0.5f);
			}
			
			playerRB.velocity = new Vector2(0, playerRB.velocity.y);
			
			if(Input.GetKey(left) || Input.GetKey(leftAlt)) {
				//transform.Translate(Vector2.left * Time.deltaTime * speedThisFrame);
				playerRB.AddForce(new Vector2(-speedThisFrame, 0), ForceMode2D.Impulse);
				spriteRenderer.flipX = true;
			}
			
			if(Input.GetKey(right) || Input.GetKey(rightAlt)) {
				//transform.Translate(Vector2.right * Time.deltaTime * speedThisFrame);
				playerRB.AddForce(new Vector2(speedThisFrame, 0), ForceMode2D.Impulse);
				spriteRenderer.flipX = false;
			}
			
			if(!onGround && !stateManager.rewind) // things to do in the air when not rewinding
			{
				if(jumping)
				{
					playerAnims.SetBool("jumping", true);
				}
				if (playerRB.velocity.y < 0) {
						jumping = false; 
						playerAnims.SetBool("jumping", false);
				}
				playerAnims.SetBool("on_ground", false);
			}
			
			else if(!stateManager.rewind) // things to do on the ground when not rewinding
			{
				if(jumping && playerRB.velocity.y <= 0)
				{
					/*
					note to self: FIX YOUR FUCKING DATA STRUCTURES.
					it makes no sense to have a grounded bool and 
					a jumping bool and count the player as falling
					when neither are true. the player cannot be jumping
					and on the ground at the same time, so this only leaves
					3 grounded/ungrounded states, which you could EASILY
					pack into an int or a short (0 being grounded, 1 being
					jumping, and 2 being falling). that way you don't have
					to keep track of two different bool values for up to
					600 frames straight. also this would solve the short
					hop ledge issue where the player is counted as both
					jumping and on the ground and you wouldn't have to
					write this stupid rule.
					*/
					jumping = false;
					playerAnims.SetBool("on_ground", true);
					playerAnims.SetBool("jumping", false);
				}
			}
			
			if(!stateManager.rewind)
			{
				playerAnims.SetBool("jumping", jumping); //fuck it
			}
			
		}
    }
	
	void FixedUpdate()
	{
		playerFeetTrigger.jumping = jumping;
		onGround = playerFeetTrigger.onGround;
		playerAnims.SetBool("on_ground", playerFeetTrigger.onGround);
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("hazard") && !stateManager.rewind)
		{
			dead = true;
		}
	}
}