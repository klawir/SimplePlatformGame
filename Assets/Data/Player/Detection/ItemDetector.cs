using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetector : MonoBehaviour
{
    public Model model;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("itemToTake"))
        {
            Destroy(other.gameObject);
            model.TakeKey();
        }
    }
}
