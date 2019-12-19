using UnityEngine;
using UnityEngine.UI;


public class DoorController : DetectorController
{
    private Model player;
    public Animation anim;
    private float doorAnimOpenHasOpened;
    private float doorAnimOpenHasClosed;
    public Items.ToUse.GUI gui;

    enum DoorState
    {
        Closed,
        Opened
    }

    DoorState doorState = new DoorState();

    void Start()
    {
        gui.DisableInfo();
        doorState = DoorState.Closed;
        doorAnimOpenHasOpened = (anim["Door_Open"].length / 100) * 95;
        doorAnimOpenHasClosed = (anim["Door_Close"].length / 100) * 95;
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("player"))
            player = other.GetComponent<Model>();
        if (doorState == DoorState.Opened)
            gui.RenderDefault();
        else if (doorState == DoorState.Closed)
        {
            gui.RenderOpen();
            if (!player.HasKey)
            {
                gui.EnableInfoState();
                gui.RenderState();
            }
        }
        gui.EnableInfo();
    }
    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        gui.DisableInfoState();
        gui.DisableInfo();
    }

    private void Update()
    {
        if (playerInZone)
        {
            if(player.HasKey)
            {
                if (anim["Door_Open"].time > doorAnimOpenHasOpened)
                    gui.RenderDefault();
                if (anim["Door_Close"].time > doorAnimOpenHasClosed)
                    gui.RenderOpen();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (doorState == DoorState.Closed && !anim.isPlaying)
                    {
                        anim.Play("Door_Open");
                        doorState = DoorState.Opened;
                    }

                    if (doorState == DoorState.Opened && !anim.isPlaying)
                    {
                        anim.Play("Door_Close");
                        doorState = DoorState.Closed;
                    }
                }
            }
        }
    }
}
