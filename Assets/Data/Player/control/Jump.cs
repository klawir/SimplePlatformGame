using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : Command
{
    protected Rigidbody rigidbody;
    protected Model model;
    protected float velocity;
    
    public Jump(GameObject modelObj)
    {
        velocity = 10;
        rigidbody = modelObj.GetComponent<Rigidbody>();
        model = modelObj.GetComponent<Model>();
    }
    public virtual void Execute()
    {
        if (model.IsGrounded)
            rigidbody.velocity = Vector3.up * velocity;
    }
}
