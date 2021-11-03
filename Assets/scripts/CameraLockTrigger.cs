using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockTrigger : MonoBehaviour
{
	private StateManager stateManager;
	private CameraFocus focus;
	public Vector3 targetPos;
	public Vector3 offset;
	public bool changeOffset;
	public bool lockX;
	public bool lockY;
	public bool revertOnTriggerLeave;
	
    // Start is called before the first frame update
    void Start()
    {
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
        focus = GameObject.Find("CameraFocus").GetComponent<CameraFocus>();
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("player") && !stateManager.rewind)
		{
			if(changeOffset) {focus.offset = offset;}
			focus.lockPosition = targetPos;
			focus.lock_x = lockX;
			focus.lock_y = lockY;
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("player") && !stateManager.rewind)
		{
			if(revertOnTriggerLeave)
			{
				focus.lock_x = false;
				focus.lock_y = false;
			}
		}
	}
}