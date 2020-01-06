using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Command
{
    private Rigidbody rigidbody;
    private Model model;
    private float velocity;
    private bool canDoubleAvailable;

    public Jump(GameObject modelObj)
    {
        velocity = 10;
        rigidbody = modelObj.GetComponent<Rigidbody>();
        model = modelObj.GetComponent<Model>();
        canDoubleAvailable = true;
    }
    public void Reset()
    {
        canDoubleAvailable = true;
    }
    public virtual void Execute()
    {
        if (model.IsGrounded || !model.IsGrounded && canDoubleAvailable)
        {
            rigidbody.velocity = Vector3.up * velocity;
            if(canDoubleAvailable)
                canDoubleAvailable = false;
        }
    }
}
