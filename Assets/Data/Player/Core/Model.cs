using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public Transform hand;
    public GameObject key;
    public Rigidbody rigidbody;
    public float gravity;
    
    private void Update()
    {
        if(transform.rotation.x!=0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
    void FixedUpdate()
    {
        rigidbody.AddForce(Vector3.down * gravity * rigidbody.mass);
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
        get { return transform.position.y == 0; }
    }
}