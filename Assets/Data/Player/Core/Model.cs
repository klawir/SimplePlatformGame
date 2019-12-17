using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
    public Transform hand;
    public GameObject key;

    private void Update()
    {
        if(transform.rotation.x!=0)
            transform.eulerAngles = new Vector3(0, 180, 0);
    }

    public void TakeKey()
    {
        Instantiate(key, hand);
    }
    public bool IsGotKey
    {
        get { return hand.childCount > 0; }
    }
}