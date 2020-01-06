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
    private bool keyJumpWall;

    private void Update()
    {
        if (IsAskew)
            ResetRotate();
        if (IsInTheAir || keyJumpWall)
            transform.Translate(Move.movementPos);
        if(isgrounded)
            RotateCalc();
    }
    void FixedUpdate()
    {
        rigidbody.AddForce(Vector3.down * gravity * rigidbody.mass);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            isgrounded = true;
            Move.Reset();
        }
        if (col.gameObject.name == "wall")
        {
            hasTouchedWall = true;
            Move.InitWallCollision();
        }
    }
    
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "Terrain")
            isgrounded = false;
        if (col.gameObject.name == "wall")
            hasTouchedWall = false;
    }
    private void RotateCalc()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.rotation = Quaternion.LookRotation(movement);

        transform.Translate(movement * 5 * Time.deltaTime, Space.World);
    }
    public bool IsInTheAir
    {
        get { return !isgrounded && !hasTouchedWall; }
    }
    private bool IsAskew
    {
        get { return transform.rotation.x != 0; }
    }
    private void ResetRotate()
    {
        transform.eulerAngles = Vector3.zero;
    }
    public void WallJump()
    {
        Move.movementPos = Move.movementRefFromWall * (- 1);
        keyJumpWall = true;
    }
    public void TakeKey()
    {
        Instantiate(key, hand);
    }
    public void KeyJumpWallFaded()
    {
        keyJumpWall=false;
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