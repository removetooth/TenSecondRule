using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewind_button : MonoBehaviour
{
    //public List<bool> rewind_state = new List<bool>();
	private List<bool> rewind_pushedbycrate = new List<bool>();
	private List<bool> rewind_pushedbyplayer = new List<bool>();
	private StateManager stateManager;
	private logic_button button;
	
    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		button = GetComponent<logic_button>();
		InvokeRepeating("DontDesync", 0f, 0.0166f); //possible workaround for desync in fixedupdate
    }

    // Update is called once per frame
    void DontDesync()//FixedUpdate()
    {
        if(!stateManager.rewind){
			rewind_pushedbycrate.Add(button.pushedByCrate);
			rewind_pushedbyplayer.Add(button.pushedByPlayer);
			if(rewind_pushedbycrate.Count > stateManager.ticks) {rewind_pushedbycrate.RemoveAt(0);}
			if(rewind_pushedbyplayer.Count > stateManager.ticks) {rewind_pushedbyplayer.RemoveAt(0);}
		}
		else
		{
			if(rewind_pushedbycrate.Count > 0)
			{
				button.pushedByCrate = rewind_pushedbycrate[rewind_pushedbycrate.Count-1];
				button.pushedByPlayer = rewind_pushedbyplayer[rewind_pushedbyplayer.Count-1];
				rewind_pushedbycrate.RemoveAt(rewind_pushedbycrate.Count-1);
				rewind_pushedbyplayer.RemoveAt(rewind_pushedbyplayer.Count-1);
			}
		}
    }
}
