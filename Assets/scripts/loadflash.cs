using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadflash : MonoBehaviour
{
	private SpriteRenderer sprite;
	public float flashtime;
	public float delay;
	
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
		InvokeRepeating("ToggleRewindFlash", delay, flashtime);
    }

    private void ToggleRewindFlash()
	{
		if(!sprite.enabled) {sprite.enabled = true;}
		else if(sprite.enabled) {sprite.enabled = false;}
	}
}
