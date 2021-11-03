﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
	
	public int energy;
	public int baseEnergy = 5;
	public int ticks;
	public float secondsPerBar;
	public int physicsRate = 60;
	
	public int health;
	public int maxHealth = 6;
	
	public bool gameOver = false;
	public bool rewind = false;
	private bool rewindLastFrame = false;
	
	public SpriteRenderer icon_rewind;
	public SpriteRenderer icon_energy;
	public Sprite[] rw_energy_sprites;
	
	public KeyCode key_rewind;
	
    // Start is called before the first frame update
    void Start()
    {
        icon_rewind.enabled = false;
		ticks = (int)(physicsRate*baseEnergy*secondsPerBar);
		energy = baseEnergy;
		//SceneManager.UnloadSceneAsync("loading");
    }
	
    // Update is called once per frame
    void Update()
    {
		if(Input.GetKeyDown(key_rewind) && ticks > 0) {rewind = true;}
		else if (Input.GetKeyUp(key_rewind)) {rewind = false;}
		
		energy = (int)Mathf.Ceil((ticks/(physicsRate*(baseEnergy*secondsPerBar)))*baseEnergy); // control energy shown based on ticks
		icon_energy.sprite = rw_energy_sprites[energy];
		
		if(rewind && ticks == 0) {rewind = false;} // if you run out, don't let the player rewind
		
		if(rewind & !rewindLastFrame) {InvokeRepeating("ToggleRewindFlash", 0f, 0.25f);}
		else if (!rewind & rewindLastFrame) {CancelInvoke("ToggleRewindFlash");}
		if(!rewind) {icon_rewind.enabled = false;}
		rewindLastFrame = rewind;
    }
	
	void FixedUpdate()
	{
		// keep rewinding until energy runs out
		if(rewind){
			if(ticks <= 0) {rewind = false; return;}
			else {ticks--;}
		}
	}
	
	private void ToggleRewindFlash()
	{
		if(!icon_rewind.enabled) {icon_rewind.enabled = true;}
		else if(icon_rewind.enabled) {icon_rewind.enabled = false;}
	}
	
	private void ToggleEnergyFlash()
	{
		if(!icon_energy.enabled) {icon_energy.enabled = true;}
		else if(icon_energy.enabled) {icon_energy.enabled = false;}
	}
	
	/*
	public void changelevel(string map)
	{
		SceneManager.LoadSceneAsync("loading");
		SceneManager.LoadSceneAsync(map);
		SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
	}
	*/
	
	public void changelevel(string map)
	{
		SceneManager.LoadScene(map);
	}
}