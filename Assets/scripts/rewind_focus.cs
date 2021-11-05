using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind_focus : MonoBehaviour
{
    public List<Vector3> rewind_pos = new List<Vector3>();
	public List<Vector3> rewind_offset = new List<Vector3>();
	public List<bool> rewind_locked = new List<bool>();
	private StateManager stateManager;
	private CameraFocus focus;
	
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		focus = GetComponent<CameraFocus>();
		InvokeRepeating("DontDesync", 0f, 0.0166f); //possible workaround for desync in fixedupdate
    }

    // Update is called once per frame
    void DontDesync()//FixedUpdate()
    {
        if(!stateManager.rewind){
			rewind_pos.Add(focus.lockPosition);
			rewind_offset.Add(focus.offset);
			rewind_locked.Add(focus.locked);
			if(rewind_pos.Count > stateManager.ticks) {rewind_pos.RemoveAt(0);}
			if(rewind_offset.Count > stateManager.ticks) {rewind_offset.RemoveAt(0);}
			if(rewind_locked.Count > stateManager.ticks) {rewind_locked.RemoveAt(0);}
		}
		else
		{
			if(rewind_pos.Count > 0)
			{
				focus.lockPosition = rewind_pos[rewind_pos.Count-1];
				focus.offset = rewind_offset[rewind_offset.Count-1];
				focus.locked = rewind_locked[rewind_locked.Count-1];
				rewind_pos.RemoveAt(rewind_pos.Count-1);
				rewind_offset.RemoveAt(rewind_offset.Count-1);
				rewind_locked.RemoveAt(rewind_locked.Count-1);
			}
		}
    }

    public void PurgeRecords() {
	rewind_offset = new List<Vector3>();
	rewind_locked = new List<bool>();
    }
}
