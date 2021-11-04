using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSDoor_sensebox : MonoBehaviour
{

    public Action<Collider2D> senseBoxEnter;
    public Action<Collider2D> senseBoxExit;

    void OnTriggerEnter2D(Collider2D other)
    {
        senseBoxEnter?.Invoke(other);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        senseBoxExit?.Invoke(other);
    }

}
