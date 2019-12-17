using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    private void Update()
    {
        if(transform.rotation.x!=0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
