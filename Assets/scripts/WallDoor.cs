using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDoor : MonoBehaviour
{
	private GameObject player;
	private StateManager stateManager;
	private Camera camera;
	private CameraFocus cameraFocus;
	private hud_fade fadeout;

	private float lastInteract = -10;
	private bool warping = false;
	private float startingCameraSize;
	private KeyCode origRewKey;
	public bool changeLevel;
	public string map;
	public Color changeBgColorTo;
	public Vector3 destination;
	public GameObject sourceRoom;
	public GameObject destinationRoom;

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.Find("player");
		stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		cameraFocus = GameObject.Find("CameraFocus").GetComponent<CameraFocus>();
		fadeout = GameObject.Find("hud_fadeout").GetComponent<hud_fade>();
		startingCameraSize = camera.orthographicSize;
		origRewKey = stateManager.key_rewind;
	}

    // Update is called once per frame
    void Update()
    {
		if (warping)
		{
			camera.orthographicSize = Mathf.SmoothStep(startingCameraSize - 1, startingCameraSize, 1 - (Time.time - lastInteract));
			if (Time.time - lastInteract > 2)
			{
				if (changeLevel) { stateManager.changelevel(map); }
				else
				{
					player.SetActive(true);
					player.transform.position = destination;
					player.GetComponent<rewind_player>().PurgeRecords();
					camera.gameObject.GetComponent<rewind_camera>().PurgeRecords();
					cameraFocus.lock_x = false;
					cameraFocus.lock_y = false;
					camera.orthographicSize = startingCameraSize;
					camera.backgroundColor = changeBgColorTo;
					camera.gameObject.transform.position = destination + cameraFocus.offset;
					destinationRoom.SetActive(true);
					fadeout.fade(0, 0, 0, 0, 1, true);
					warping = false;
					stateManager.key_rewind = origRewKey;
					sourceRoom.SetActive(false);
				}
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		playercontroller pl = other.gameObject.GetComponent<playercontroller>();
		if (other.gameObject.CompareTag("player") && pl.onGround && (Input.GetKey(pl.jump) || Input.GetKey(pl.jumpAlt)))
		{
			lastInteract = Time.time;
				pl.gameObject.SetActive(false);
				warping = true;
				cameraFocus.lock_x = true;
				cameraFocus.lock_y = true;
				cameraFocus.lockPosition = transform.position;
				fadeout.fade(0, 0, 0, 0, 1, false);
				stateManager.key_rewind = KeyCode.None;
		}
	}
}
