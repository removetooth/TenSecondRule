using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hud_energy : MonoBehaviour
{
	
	private SpriteRenderer spriterenderer;
	
	public Sprite[] sprites;
	public int base_energy;
	public int energy;
	public int physics_rate = 50;
	public int ticks;
	
    // Start is called before the first frame update
    void Start()
    {
		spriterenderer = GetComponent<SpriteRenderer>();
        ticks = physics_rate;
		energy = base_energy;
    }

    // Update is called once per frame
    void Update()
    {
        spriterenderer.sprite = sprites[energy];
    }
}
