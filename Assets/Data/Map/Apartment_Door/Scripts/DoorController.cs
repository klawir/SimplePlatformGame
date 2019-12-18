using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Text txtToDisplay;
    public Text txtToDisplayState;

    private Model player;
    private bool playerInZone;
    private Animation doorAnim;
    private float doorAnimOpenHasOpened;
    private float doorAnimOpenHasClosed;

    enum DoorState
    {
        Closed,
        Opened
    }

    DoorState doorState = new DoorState();

    private void Start()
    {
        playerInZone = false;
        doorState = DoorState.Closed;

        txtToDisplay.gameObject.SetActive(false);

        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
        doorAnimOpenHasOpened = (doorAnim["Door_Open"].length / 100) * 95;
        doorAnimOpenHasClosed = (doorAnim["Door_Close"].length / 100) * 95;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
        {
            player = other.GetComponent<Model>();
        }

        txtToDisplay.gameObject.SetActive(true);

        if (doorState == DoorState.Opened)
        {
            txtToDisplay.text = "Press 'E' to close";
            
        }
        else if (doorState == DoorState.Closed)
        {
            txtToDisplay.text = "Press 'E' to open";
            if (!player.HasKey)
            {
                txtToDisplayState.gameObject.SetActive(true);
                txtToDisplayState.text = "Need the key";
            }
            
        }
        playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.gameObject.SetActive(false);
        txtToDisplayState.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && player.HasKey)
        {
            if (doorAnim["Door_Open"].time > doorAnimOpenHasOpened)
                txtToDisplay.text = "Press 'E' to close";
            if (doorAnim["Door_Close"].time > doorAnimOpenHasClosed)
                txtToDisplay.text = "Press 'E' to open";

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (doorState == DoorState.Closed && !doorAnim.isPlaying)
                {
                    doorAnim.Play("Door_Open");
                    doorState = DoorState.Opened;
                }

                if (doorState == DoorState.Opened && !doorAnim.isPlaying)
                {
                    doorAnim.Play("Door_Close");
                    doorState = DoorState.Closed;
                }
            }
        }
    }
}
