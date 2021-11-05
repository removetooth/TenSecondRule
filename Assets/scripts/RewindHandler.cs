using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewindHandler : MonoBehaviour
{
    private List<List<object>> records = new List<List<object>> { };
    private bool rewindLastFrame;
    private StateManager stateManager;

    public Action OnRewindStart = delegate () { };
    public Action OnRewindEnd = delegate () { };
    public Action<List<object>> RewindUpdate = delegate (List<object> record) { };

    public bool IsRewindable = true;

    // Start is called before the first frame update
    void Start()
    {
        stateManager = GameObject.Find("StateManager").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsRewindable)
        {
            if (stateManager.rewind && !rewindLastFrame)
            {
                OnRewindStart?.Invoke();
                rewindLastFrame = true;
            }
            else if (!stateManager.rewind && rewindLastFrame)
            {
                OnRewindEnd?.Invoke();
                rewindLastFrame = false;
            }

            if (stateManager.rewind)
            {
                RewindUpdate?.Invoke(records[records.Count - 1]);
                records.RemoveAt(records.Count - 1);
            }
        }
    }

    public void PurgeRecords()
    {
        records = new List<List<object>> { };
    }

    public void InsertRecord(List<object> r)
    {
        if(!stateManager.rewind && IsRewindable)
        {
            records.Add(r);
            if(records.Count > stateManager.ticks) { records.RemoveAt(0); }
        }
    }
}
