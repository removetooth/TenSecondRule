using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_door : MonoBehaviour
{
	public bool open;
	private bool lastState;
	public float open_time = 25f;
	private float timer;
	private Vector3 open_pos;
	private Vector3 closed_pos;
	
    // Start is called before the first frame update
    void Start()
    {
		timer = open_time;
        open = false;
		closed_pos = transform.position;
		open_pos = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(open){
			if(!lastState) {timer = 0f;}
			transform.position = Vector3.Lerp(closed_pos, open_pos, timer/open_time);
		}
		else{
			if(lastState) {timer = 0f;}
			transform.position = Vector3.Lerp(open_pos, closed_pos, timer/open_time);
		}
		if(timer <= open_time) {timer++;}
		lastState = open;
    }
}
