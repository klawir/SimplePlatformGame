using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : Jump
{
    private bool canDoubleAvailable;

    public DoubleJump(GameObject modelObj) : base(modelObj)
    {
        rigidbody = modelObj.GetComponent<Rigidbody>();
        canDoubleAvailable = true;
    }
    public void Reset()
    {
        canDoubleAvailable = true;
    }
    public override void Execute()
    {
        base.Execute();
        if (!model.IsGrounded && canDoubleAvailable)
        {
            rigidbody.velocity = Vector3.up * velocity;
            canDoubleAvailable = false;
        }
    }
}
