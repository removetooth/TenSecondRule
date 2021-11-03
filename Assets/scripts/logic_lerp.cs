﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_lerp : MonoBehaviour
{
    public bool state;
	private bool lastState;
	public float travelTime = 25f;
	private float timer;
	private Vector3 startPos;
	public Vector3 endPos;
	
	// FOR REWIND: log the position, state, last state, and TIMER MOST OF ALL.
	
    // Start is called before the first frame update
    void Start()
    {
		timer = travelTime;
        state = false;
		startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(state){
			if(!lastState) {timer = 0f;}
			transform.position = Vector3.Lerp(startPos, startPos + endPos, timer/travelTime);
		}
		else{
			if(lastState) {timer = 0f;}
			transform.position = Vector3.Lerp(startPos + endPos, startPos, timer/travelTime);
		}
		if(timer <= travelTime) {timer++;}
		lastState = state;
    }
}