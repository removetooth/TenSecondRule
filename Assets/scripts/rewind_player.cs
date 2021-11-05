using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind_player : MonoBehaviour
{
	
	private StateManager stateManager;
	private bool rewindLastFrame = false;
	private Rigidbody2D playerRB;
	private SpriteRenderer spriteRenderer;
	private Animator playerAnims;
	private playercontroller playerController;
	
	public List<Vector3> rewind_pos = new List<Vector3>();
	public List<Vector2> rewind_velocity = new List<Vector2>();
	public List<Sprite> rewind_sprite = new List<Sprite>();
	public List<bool> rewind_flip = new List<bool>();
	public List<bool> rewind_dead = new List<bool>();
	public List<bool> rewind_jump = new List<bool>();
	
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		playerRB = GetComponent<Rigidbody2D>();
		playerAnims = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		playerController = GetComponent<playercontroller>();
		InvokeRepeating("DontDesync", 0f, 0.0166f); //possible workaround for desync in fixedupdate
		
    }

    void DontDesync()//FixedUpdate()
    {
		if(rewind_dead.Count > 0){
			if(rewind_dead[0]) {stateManager.gameOver = true;} // if player is dead for longer than their remaining rewind, game over
		}
		else
		{
			stateManager.gameOver = playerController.dead;
		}
		
        if(stateManager.rewind && !rewindLastFrame) {
			playerRB.simulated = false;
			playerAnims.enabled = false;
		}
		else if(!stateManager.rewind && rewindLastFrame) {
			playerRB.simulated = true;
			playerAnims.enabled = true;
		}
		rewindLastFrame = stateManager.rewind;
		
		if(!stateManager.rewind){
			rewind_pos.Add(transform.position);
			rewind_velocity.Add(playerRB.velocity);
			rewind_sprite.Add(spriteRenderer.sprite);
			rewind_flip.Add(spriteRenderer.flipX);
			rewind_dead.Add(playerController.dead);
			rewind_jump.Add(playerController.jumping);
			if(rewind_pos.Count > stateManager.ticks) {rewind_pos.RemoveAt(0);}
			if(rewind_velocity.Count > stateManager.ticks) {rewind_velocity.RemoveAt(0);}
			if(rewind_sprite.Count > stateManager.ticks) {rewind_sprite.RemoveAt(0);}
			if(rewind_flip.Count > stateManager.ticks) {rewind_flip.RemoveAt(0);}
			if(rewind_dead.Count > stateManager.ticks) {rewind_dead.RemoveAt(0);}
			if(rewind_jump.Count > stateManager.ticks) {rewind_jump.RemoveAt(0);}
		}
		else
		{
			if(rewind_pos.Count > 0)
			{
				transform.position = rewind_pos[rewind_pos.Count-1];
				playerRB.velocity = rewind_velocity[rewind_velocity.Count-1];
				spriteRenderer.sprite = rewind_sprite[rewind_sprite.Count-1];
				spriteRenderer.flipX = rewind_flip[rewind_flip.Count-1];
				playerController.dead = rewind_dead[rewind_dead.Count-1];
				playerController.jumping = rewind_jump[rewind_jump.Count-1];
				rewind_pos.RemoveAt(rewind_pos.Count-1);
				rewind_velocity.RemoveAt(rewind_velocity.Count-1);
				rewind_sprite.RemoveAt(rewind_sprite.Count-1);
				rewind_flip.RemoveAt(rewind_flip.Count-1);
				rewind_dead.RemoveAt(rewind_dead.Count-1);
				rewind_jump.RemoveAt(rewind_jump.Count-1);
			}
		}
    }

    public void PurgeRecords() {
        rewind_pos = new List<Vector3>();
	rewind_velocity = new List<Vector2>();
	rewind_sprite = new List<Sprite>();
	rewind_flip = new List<bool>();
	rewind_dead = new List<bool>();
	rewind_jump = new List<bool>();
    }
}