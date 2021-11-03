﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{

	//FOR REWIND: log position, locked, lock position, offset.
	
	public GameObject player;
	public bool locked;
	public bool lock_x;
	public bool lock_y;
	public Vector3 lockPosition;
	public Vector3 offset;
	
	private Rigidbody2D playerRB;
	
    // Start is called before the first frame update
    void Start()
    {
		playerRB = player.GetComponent<Rigidbody2D>();
		//locked = false;
        transform.position = playerRB.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(!lock_x)
		{
			transform.position = new Vector3(playerRB.transform.position.x + offset.x, transform.position.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(lockPosition.x, transform.position.y, transform.position.z);
		}
		if(!lock_y)
		{
			transform.position = new Vector3( transform.position.x, playerRB.transform.position.y + offset.y, transform.position.z);
		}
		else
		{
			transform.position = new Vector3(transform.position.x, lockPosition.y, transform.position.z);
		}
    }
}