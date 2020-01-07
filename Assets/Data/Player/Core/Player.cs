using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed;

    public void UpdatePos()
    {
        transform.Translate(Move.movementVector);
    }
}
