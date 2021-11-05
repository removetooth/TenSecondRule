using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud_fade : MonoBehaviour
{
    public bool fadeOnStart;
    public bool fadeIn;
    public Color fadeInFrom;
    public float fadetime;

    private SpriteRenderer spriteRenderer;
    private float startTime;

    private const float rDefault = 0.0f;
    private const float gDefault = 0.0f;
    private const float bDefault = 0.0f;
    private const float aDefault = 1.0f;
    private const float tDefault = 1.0f;
    private const bool fDefault = true;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(fadeOnStart) { fade(fadeInFrom.r, fadeInFrom.g, fadeInFrom.b, fadeInFrom.a, fadetime, fadeIn); }
        //if(!fadeIn) { enabled = false; }
    }

    // Update is called once per frame
    void Update()
    {
	if(fadeIn) {
        	spriteRenderer.color = new Color(fadeInFrom.r, fadeInFrom.g, fadeInFrom.b, Mathf.Lerp(1, 0, (Time.time - startTime) / fadetime));
	}
	else {
		spriteRenderer.color = new Color(fadeInFrom.r, fadeInFrom.g, fadeInFrom.b, Mathf.Lerp(1, 0, 1-(Time.time - startTime) / fadetime));
	}
        if(Time.time - startTime > fadetime)
        {
            //enabled = false;
        }
    }

    public void fade(float r = rDefault, float g = gDefault, float b = bDefault, float a = aDefault, float ft = tDefault, bool fi = fDefault)
    {
	fadetime = ft;
	fadeIn = fi;
	fadeInFrom = new Color(r,g,b,a);
        startTime = Time.time;
    }
}
