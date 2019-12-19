using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Model model;
    private bool detectedItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("itemToTake"))
            detectedItem =true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("itemToTake"))
            detectedItem = false;
    }
    private void Update()
    {
        if(detectedItem)
            if (Input.GetKeyDown(KeyCode.E))
                model.TakeKey();
    }
}
