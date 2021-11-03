﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_button : MonoBehaviour
{
	
	// FOR REWIND: log state and current animation.
	
	private Animator anims;
	public bool state;
	public bool permanent;
	public bool pushableByPlayer;
	public GameObject target_obj;
	private logic_lerp target;
	private StateManager stateManager;
	
	public bool pushedByCrate;
	public bool pushedByPlayer;
	
    // Start is called before the first frame update
    void Start()
    {
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        anims = GetComponent<Animator>();
		state = false;
		target = target_obj.GetComponent<logic_lerp>();
		target.state = false;
    }

    // Update is called once per frame
    void Update()
    {
		state = (pushedByCrate || pushedByPlayer);
        anims.SetBool("state", state);
		target.state = state;
    }
	
	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.CompareTag("pushable") && !stateManager.rewind)
		{
			pushedByCrate = true;
		}
		else if (col.gameObject.CompareTag("player") && !stateManager.rewind)
		{
			pushedByPlayer = true;
		}
	}
	
	private void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.CompareTag("pushable") && !stateManager.rewind)
		{
			pushedByCrate = true;
		}
		else if (col.gameObject.CompareTag("player") && !stateManager.rewind)
		{
			pushedByPlayer = true;
		}
	}
	
	private void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.CompareTag("pushable") && !stateManager.rewind)
		{
			pushedByCrate = false;
		}
		else if (col.gameObject.CompareTag("player") && !stateManager.rewind)
		{
			pushedByPlayer = false;
		}
	}
}