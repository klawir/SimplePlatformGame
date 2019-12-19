using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Vector3 movementPos;
    public static Vector3 movementRefFromWall;
    public static void Reset()
    {
        movementPos = Vector3.zero;
    }
    private static void PrepareForWallJump()
    {
        movementRefFromWall = movementPos;
    }
    private static void StopMovement()
    {
        movementPos = Vector3.zero;
    }
    public static void InitWallCollision()
    {
        PrepareForWallJump();
        StopMovement();
    }
}
