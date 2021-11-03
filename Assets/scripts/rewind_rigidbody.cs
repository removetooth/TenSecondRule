using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind_rigidbody : MonoBehaviour
{
	
	public List<Vector3> rewind_pos = new List<Vector3>();
	public List<Vector2> rewind_velocity = new List<Vector2>();
	
	private StateManager stateManager;
	private Rigidbody2D rigidBody;
	
	private bool rewindLastFrame;
	
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		rigidBody = GetComponent<Rigidbody2D>();
		InvokeRepeating("DontDesync", 0f, 0.01f); //possible workaround for desync in fixedupdate
    }

    // Update is called once per frame
    void DontDesync()//FixedUpdate()
    {
		
		if(stateManager.rewind && !rewindLastFrame) {
			rigidBody.simulated = false;
		}
		else if(!stateManager.rewind && rewindLastFrame) {
			rigidBody.simulated = true;
		}
		rewindLastFrame = stateManager.rewind;
		
        if(!stateManager.rewind){
			rewind_pos.Add(transform.position);
			rewind_velocity.Add(rigidBody.velocity);
			if(rewind_pos.Count > stateManager.ticks) {rewind_pos.RemoveAt(0);}
			if(rewind_velocity.Count > stateManager.ticks) {rewind_velocity.RemoveAt(0);}
		}
		else
		{
			if(rewind_pos.Count > 0)
			{
				transform.position = rewind_pos[rewind_pos.Count-1];
				rigidBody.velocity = rewind_velocity[rewind_velocity.Count-1];
				rewind_pos.RemoveAt(rewind_pos.Count-1);
				rewind_velocity.RemoveAt(rewind_velocity.Count-1);
			}
		}
    }
}
