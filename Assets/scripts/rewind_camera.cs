using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind_camera : MonoBehaviour
{
	
	public List<Vector3> rewind_pos = new List<Vector3>();
	private StateManager stateManager;
	
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		InvokeRepeating("DontDesync", 0f, 0.0166f); //possible workaround for desync in fixedupdate
    }

    // Update is called once per frame
    void DontDesync()//FixedUpdate()
    {
        if(!stateManager.rewind){
			rewind_pos.Add(transform.position);
			if(rewind_pos.Count > stateManager.ticks) {rewind_pos.RemoveAt(0);}
		}
		else
		{
			if(rewind_pos.Count > 0)
			{
				transform.position = rewind_pos[rewind_pos.Count-1];
				rewind_pos.RemoveAt(rewind_pos.Count-1);
			}
		}
    }

    public void PurgeRecords() {
        rewind_pos = new List<Vector3>();
    }
}
