using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logic_NOT : MonoBehaviour
{
    public logic_conduit input;
    public logic_conduit output;

    // Update is called once per frame
    void Update()
    {
        output.state = !input.state;
    }
}
