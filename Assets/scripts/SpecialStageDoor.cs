using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialStageDoor : MonoBehaviour
{
	private SpriteRenderer doorRenderer;
	private SpriteRenderer limiterRenderer;
	private SpriteRenderer interactRenderer;
	private SpriteRenderer portalRenderer;
	private StateManager stateManager;
	public Sprite[] doorFrames;
	public Sprite[] limiterFrames;
	
	public int current;
	public int required;
	public string map;
	
    // Start is called before the first frame update
    void Start()
    {
        doorRenderer = GetComponent<SpriteRenderer>();
		limiterRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
		interactRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
		portalRenderer = transform.GetChild(2).GetComponent<SpriteRenderer>();
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		
		interactRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        portalRenderer.color = new Color(-Mathf.Sin(Time.time) * 0.5f + 0.5f, Mathf.Cos(Time.time) * 0.5f + 0.5f, Mathf.Sin(Time.time) * 0.5f + 0.5f);
		doorRenderer.sprite = doorFrames[current];
		limiterRenderer.sprite = limiterFrames[required-1];
    }
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("player"))
		{
			interactRenderer.enabled = true;
			stateManager.changelevel(map);
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.CompareTag("player"))
		{
			interactRenderer.enabled = false;
			//stateManager.changelevel(map);
		}
	}
}
