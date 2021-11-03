using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_clockblock : MonoBehaviour
{
	
	public logic_lerp target;
	public Sprite[] clockSprites;
	public SpriteRenderer p_clock;
	private SpriteRenderer b_clock;
	public int pclockstate;
	public int bclockstate;
	public float clockSpeed;
	public int lenience;
	private StateManager stateManager;
	
    // Start is called before the first frame update
    void Start()
    {
		b_clock = GetComponent<SpriteRenderer>();
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		InvokeRepeating("Step", 0f, clockSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        p_clock.sprite = clockSprites[pclockstate % clockSprites.Length];
		b_clock.sprite = clockSprites[bclockstate % clockSprites.Length];
		target.state = (Mathf.Abs(pclockstate - bclockstate) % clockSprites.Length < lenience || Mathf.Abs(pclockstate - bclockstate) % clockSprites.Length > clockSprites.Length - lenience);
		//Debug.Log(Mathf.Abs(pclockstate - bclockstate) % clockSprites.Length);
    }
	
	private void Step()
	{
		if(!stateManager.rewind) {bclockstate++;}
		else if(bclockstate > 0){bclockstate--;}
		pclockstate++;
	}
	
	
	
	
}
