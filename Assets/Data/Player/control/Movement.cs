using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: Command
{
    private Player player;
    private Model model;
    private float xAxis;
    private float zAxis;

    public Movement(GameObject playerObj, Model model)
    {
        player = playerObj.GetComponent<Player>();
        this.model = model;
    }
    public void Execute()
    {
        xAxis = Input.GetAxis("Horizontal") * player.speed * Time.deltaTime;
        zAxis = Input.GetAxis("Vertical") * player.speed * Time.deltaTime;
        Move.movementVector = new Vector3(xAxis, 0, zAxis);
        player.UpdatePos();
        model.UpdateRotation();
        model.PlayMoveAnim();
    }
}
