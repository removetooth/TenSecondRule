using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBG : MonoBehaviour
{
    public GameObject follow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y, 1);
    }

    void FixedUpdate()
    {
        transform.Rotate(-.1f, -.1f, 0);
    }
}
