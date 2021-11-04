using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialStageDoor : MonoBehaviour
{
	private SpriteRenderer doorRenderer;
	private SpriteRenderer limiterRenderer;
	private SpriteRenderer interactRenderer;
	private SpriteRenderer portalRenderer;
	private SSDoor_sensebox senseBox;
	private StateManager stateManager;
	private Camera camera;
	private CameraFocus cameraFocus;
	private SpriteRenderer fadeout;
	public ParticleSystem warpParticle;
	public Sprite[] doorFrames;
	public Sprite[] limiterFrames;

	private float lastSense = -10;
	private float lastInteract = -10;
	private bool entering;
	private bool warping = false;
	private float startingCameraSize;
	private int current;
	private int barFillSpeed = 6;
	public int required;
	public string map;

	// Start is called before the first frame update
	void Start()
	{
		doorRenderer = GetComponent<SpriteRenderer>();
		limiterRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
		interactRenderer = transform.GetChild(1).GetComponent<SpriteRenderer>();
		portalRenderer = transform.GetChild(2).GetComponent<SpriteRenderer>();
		senseBox = transform.GetChild(3).GetComponent<SSDoor_sensebox>();
		senseBox.senseBoxEnter = senseBoxEnter;
		senseBox.senseBoxExit = senseBoxExit;
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		cameraFocus = GameObject.Find("CameraFocus").GetComponent<CameraFocus>();
		fadeout = GameObject.Find("hud_fadeout").GetComponent<SpriteRenderer>();
		startingCameraSize = camera.orthographicSize;

		interactRenderer.enabled = false;
	}

	// Update is called once per frame
	void Update()
	{
		float fillTo = Mathf.Clamp(stateManager.energy, 0, required);
		if (entering)
		{
			current = (int)Mathf.Clamp(Time.time * barFillSpeed - lastSense * barFillSpeed + 1, 0.0f, fillTo);
			if (stateManager.energy >= required) {
				portalRenderer.gameObject.transform.localScale = new Vector3(
					5 - 4 * Mathf.Clamp(Time.time * 8 - lastSense * 8 - 8 * fillTo / barFillSpeed, 0, 1),
					Mathf.SmoothStep(0, 1, Time.time * 8 - lastSense * 8 - 8 * fillTo / barFillSpeed),
					1
					);
			}
		}
		else
		{
			current = (int)Mathf.Clamp(fillTo - (Time.time * barFillSpeed * 2 - lastSense * barFillSpeed * 2), 0.0f, fillTo);
			if (stateManager.energy >= required)
			{
				portalRenderer.gameObject.transform.localScale = new Vector3(
					(1 - Mathf.Clamp(Time.time * 8 - lastSense * 8 - 8 * fillTo / (barFillSpeed * 2), 0, 1)),
					(1 - Mathf.Clamp(Time.time * 8 - lastSense * 8 - 8 * fillTo / (barFillSpeed * 2), 0, 1)),
					1
					);
			}
		}

		if (warping)
		{
			camera.orthographicSize = Mathf.SmoothStep(startingCameraSize-1, startingCameraSize, 1 - (Time.time - lastInteract));
			fadeout.color = new Color(1,1,1,Mathf.Lerp(0, 1, Time.time - lastInteract));
			if (Time.time - lastInteract > 2) { stateManager.changelevel(map); }
		}
		
		//portalRenderer.color = new Color(-Mathf.Sin(Time.time) * 0.5f + 0.5f, Mathf.Cos(Time.time) * 0.5f + 0.5f, Mathf.Sin(Time.time) * 0.5f + 0.5f);
		doorRenderer.sprite = doorFrames[current];
		limiterRenderer.sprite = limiterFrames[Mathf.Max(0, required - 1)];
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("player") && stateManager.energy >= required)
		{
			interactRenderer.enabled = true;
			//stateManager.changelevel(map);
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("player"))
		{
			interactRenderer.enabled = false;
			//stateManager.changelevel(map);
		}
	}

	void OnTriggerStay2D(Collider2D other)
    {
		playercontroller pl = other.gameObject.GetComponent<playercontroller>();
		if (other.gameObject.CompareTag("player") && (Input.GetKey(pl.jump) || Input.GetKey(pl.jumpAlt)))
		{
			lastInteract = Time.time;
			if (stateManager.energy >= required)
			{
				pl.gameObject.GetComponent<Rigidbody2D>().simulated = false;
				pl.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				pl.enabled = false;
				warping = true;
				cameraFocus.lock_x = true;
				cameraFocus.lock_y = true;
				cameraFocus.lockPosition = transform.position;
				fadeout.color = new Color(1, 1, 1, 0);
				stateManager.key_rewind = KeyCode.None; // point of no return
				warpParticle.gameObject.transform.position = pl.gameObject.transform.position;
				warpParticle.gameObject.transform.Translate(0,0,1);
				warpParticle.Play();
			}
        }
    }

	void senseBoxEnter(Collider2D other)
    {
		if (other.gameObject.CompareTag("player"))
		{
			lastSense = Time.time;
			entering = true;
		}
    }

	void senseBoxExit(Collider2D other)
    {
		if (other.gameObject.CompareTag("player"))
		{
			lastSense = Time.time;
			entering = false;
		}
    }

}
