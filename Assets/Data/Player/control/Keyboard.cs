using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject playerTransf;
    public Model playersObj;
    
    private Command movement;
    private Command jump;
    private DoubleJump doubleJump;

    private void Start()
    {
        movement = new Movement(playerTransf);
        jump = new Jump(playersObj.gameObject);
        doubleJump = new DoubleJump(playersObj.gameObject);
    }
    void Update()
    {
        if (playersObj.IsGrounded)
        {
            if (Input.GetKey(KeyCode.W)
            || Input.GetKey(KeyCode.A)
            || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.D))
                movement.Execute();
            doubleJump.Reset();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump.Execute();
            doubleJump.Execute();
            if (playersObj.HasTouchedWall)
                playersObj.WallJump();
        }
    }
}