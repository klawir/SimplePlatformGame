using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Vector3 movementVector;
    public static Vector3 movementRefFromWall;

    public static void Reset()
    {
        movementVector = Vector3.zero;
    }
    private static void PrepareForWallJump()
    {
        movementRefFromWall = movementVector;
    }
    public static void WallJump()
    {
        movementVector = movementRefFromWall * (-1);
    }
    private static void StopMovement()
    {
        movementVector = Vector3.zero;
    }
    public static void InitWallCollision()
    {
        PrepareForWallJump();
        StopMovement();
    }
}
