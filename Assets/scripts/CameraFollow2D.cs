﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
	
	// FOR REWIND: log position.
	
    public float FollowSpeed = 2f;
    public Transform Target;
	
	private StateManager stateManager;
	
	private void Start() {stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();}

    private void Update()
    {
		if(!stateManager.rewind)
		{
			Vector3 newPosition = Target.position;
			//newPosition.y += 2;
			newPosition.z = -10;
			transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
                        /*transform.position = new Vector3(
                            Mathf.Round(newCameraPos.x * 1000.0f) / 1000B.0f,
                            Mathf.Round(newCameraPos.y * 1000.0f) / 1000.0f,
                            Mathf.Round(newCameraPos.z * 1000.0f) / 1000.0f
                            );*/
		}
    }
}
