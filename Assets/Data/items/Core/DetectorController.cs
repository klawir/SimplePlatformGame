using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DetectorController : MonoBehaviour
{
    protected bool playerInZone;
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        playerInZone = true;
    }
    protected virtual void OnTriggerExit(Collider other)
    {
        playerInZone = false;
    }
}
