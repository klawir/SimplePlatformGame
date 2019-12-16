using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, Command
{
    private Vector3 pos;
    private CharacterController characterController;
    private Player player;
    
    public Movement(GameObject playerObj)
    {
        player = playerObj.GetComponent<Player>();
        characterController = playerObj.GetComponent<CharacterController>();
    }
    public void Execute()
    {
        CalculateDirection();
        characterController.Move(pos * player.speed * Time.deltaTime);
    }

    private void CalculateDirection()
    {
        pos = player.transform.right * Input.GetAxis("Horizontal") + player.transform.forward * Input.GetAxis("Vertical");
    }
}
