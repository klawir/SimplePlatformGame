using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject playerTransf;
    public GameObject playersObj;
    
    private Command movement;
    private Command jump;

    private void Start()
    {
        movement = new Movement(playerTransf);
        jump = new Jump(playersObj);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            movement.Execute();
        if (Input.GetKeyDown(KeyCode.Space))
            jump.Execute();
    }
}