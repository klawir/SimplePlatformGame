using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public GameObject playerTransf;
    public GameObject playerModel;
    public CharacterController characterController;

    private Vector3 rotate;

    private Command movement;

    private void Start()
    {
        movement = new Movement(playerTransf);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            movement.Execute();
    }
}