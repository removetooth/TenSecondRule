using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_energy : MonoBehaviour
{
	private StateManager stateManager;
	public bool large;
	
    // Start is called before the first frame update
    void Start()
    {
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag("player")) {
			if(large || stateManager.ticks + stateManager.physicsRate*stateManager.secondsPerBar > stateManager.physicsRate*stateManager.secondsPerBar*stateManager.baseEnergy)
			{
				stateManager.ticks = (int)(stateManager.physicsRate*stateManager.secondsPerBar*stateManager.baseEnergy);
			}
			else {stateManager.ticks += (int)(stateManager.physicsRate*stateManager.secondsPerBar);}
			Destroy(gameObject);
		}
	}
}
