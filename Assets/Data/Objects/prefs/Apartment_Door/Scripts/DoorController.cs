using UnityEngine;
using UnityEngine.UI;


public class DoorController : DetectorController
{
    private Model player;
    public Animation anim;
    private float doorAnimOpenHasOpened;
    private float doorAnimOpenHasClosed;
    public Items.ToUse.GUI gui;
    private const int animEnd = 95;

    enum DoorState
    {
        Closed,
        Opened
    }

    DoorState doorState = new DoorState();
    
    void Start()
    {
        gui.DisableInfo();
        SetStateToClosed();
        CalculateStateOfAnimationsThatComingToEnd();
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
                if (IsAnimOpenComingToEnd)
                    gui.RenderDefault();
                if (IsAnimCloseComingToEnd)
                    gui.RenderOpen();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (AreClosed)
                    {
                        anim.Play("Door_Open");
                        SetStateToOpened();
                    }

                    if (AreOpened)
                    {
                        anim.Play("Door_Close");
                        SetStateToClosed();
                    }
                }
            }
        }
    }
    private bool IsAnimOpenComingToEnd
    {
        get { return anim["Door_Open"].time > doorAnimOpenHasOpened; }
    }
    private bool IsAnimCloseComingToEnd
    {
        get { return anim["Door_Close"].time > doorAnimOpenHasClosed; }
    }
    private void CalculateStateOfAnimationsThatComingToEnd()
    {
        doorAnimOpenHasOpened = (anim["Door_Open"].length / 100) * animEnd;
        doorAnimOpenHasClosed = (anim["Door_Close"].length / 100) * animEnd;
    }
    private void SetStateToOpened()
    {
        doorState = DoorState.Opened;
    }
    private void SetStateToClosed()
    {
        doorState = DoorState.Closed;
    }
    private bool AreClosed
    {
        get { return doorState == DoorState.Closed && !anim.isPlaying; }
    }
    private bool AreOpened
    {
        get { return doorState == DoorState.Opened && !anim.isPlaying; }
    }
}
