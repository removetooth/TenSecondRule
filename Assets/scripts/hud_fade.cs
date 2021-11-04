using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud_fade : MonoBehaviour
{

    public bool fadeIn;
    public Color fadeInFrom;
    public float fadetime;

    private SpriteRenderer spriteRenderer;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startTime = Time.time;
        if(!fadeIn) { enabled = false; }
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.color = new Color(fadeInFrom.r, fadeInFrom.g, fadeInFrom.b, Mathf.Lerp(1, 0, (Time.time - startTime) / fadetime));
        if(Time.time - startTime > fadetime)
        {
            enabled = false;
        }
    }
}
