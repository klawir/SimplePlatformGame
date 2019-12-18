using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public Vector3 rotate;

    private void FixedUpdate()
    {
        Rorate();
    }

    private void Rorate()
    {
        transform.eulerAngles += rotate;
    }
}
