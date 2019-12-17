using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Command
{
    Rigidbody rigidbody;

    public Jump(GameObject modelObj)
    {
        rigidbody = modelObj.GetComponent<Rigidbody>();
    }
    public void Execute()
    {
        rigidbody.AddForce(Vector3.up * 7, ForceMode.Impulse);
    }
}
