﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundDetect : MonoBehaviour
{
	
	public bool onGround;
	public bool jumping;
	public float coyoteTime;
	
    void Start()
    {
        onGround = false;
		coyoteTime = 0f;
    }
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if(!other.isTrigger && !jumping) {onGround = true;}
    }
	void OnTriggerStay2D(Collider2D other)
    {
        if(!other.isTrigger && !jumping) {onGround = true;}
    }
	void OnTriggerExit2D(Collider2D other)
    {
        if(!other.isTrigger) {onGround = false;}
		coyoteTime = Time.time;
    }
}