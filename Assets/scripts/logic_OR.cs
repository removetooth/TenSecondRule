using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_OR : MonoBehaviour
{
    public logic_conduit[] inputs;
    public logic_conduit output;

    // Update is called once per frame
    void Update()
    {
        bool result = true;
        for (int i = 0; i < inputs.Length; i++)
        {
            if (!inputs[i].state) { result = false; }
        }
        output.state = result;
    }
}
