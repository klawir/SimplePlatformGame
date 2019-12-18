using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: Command
{
    private Player player;
    private float xAxis;
    private float zAxis;

    public Movement(GameObject playerObj)
    {
        player = playerObj.GetComponent<Player>();
    }
    public void Execute()
    {
        xAxis = Input.GetAxis("Horizontal") * player.speed * Time.deltaTime;
        zAxis = Input.GetAxis("Vertical") * player.speed * Time.deltaTime;
        Move.pos = new Vector3(xAxis, 0, zAxis);
        player.transform.Translate(Move.pos);
    }
}
