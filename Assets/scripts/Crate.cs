using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private RewindHandler rewindHandler;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rewindHandler = GetComponent<RewindHandler>();
        rewindHandler.OnRewindStart = delegate () { rigidBody.simulated = false; };
        rewindHandler.OnRewindEnd = delegate () { rigidBody.simulated = true; };
        rewindHandler.RewindUpdate = RewindUpdate; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rewindHandler.InsertRecord(new List<object> {
            transform.position,
            rigidBody.velocity
        });
    }

    void RewindUpdate(List<object> r)
    {
        transform.position = (Vector3)r[0];
        rigidBody.velocity = (Vector2)r[1];
    }

}
