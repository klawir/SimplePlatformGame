using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysController : DetectorController
{
    public Items.ToTake.GUI gui;

    void Start()
    {
        gui.DisableInfo();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        gui.EnableInfo();
        gui.RenderDefault();
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        gui.DisableInfo();
    }
    private void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Destroy(gameObject);
                gui.DisableInfo();
            }
        }
    }
}
