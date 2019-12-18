using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public Transform hand;
    public GameObject key;
    public Rigidbody rigidbody;
    public float gravity;
    private bool isgrounded;
    private bool hasTouchedWall;
    
    private void Update()
    {
        if(transform.rotation.x!=0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        if (!IsGrounded)
            transform.Translate(-Move.pos);
    }
    void FixedUpdate()
    {
        rigidbody.AddForce(Vector3.down * gravity * rigidbody.mass);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
            isgrounded = true;
        if (col.gameObject.name == "wall")
            hasTouchedWall = true;
    }
    
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Terrain")
            isgrounded = false;
        if (col.gameObject.name == "wall")
            hasTouchedWall = false;
    }
    public void WallJump()
    {
        Move.pos = Move.pos * (- 1) ;
    }
    public void TakeKey()
    {
        Instantiate(key, hand);
    }
    public bool HasKey
    {
        get { return hand.childCount > 0; }
    }
    public bool IsGrounded
    {
        get { return isgrounded; }
    }
    public bool HasTouchedWall
    {
        get { return hasTouchedWall; }
    }
}