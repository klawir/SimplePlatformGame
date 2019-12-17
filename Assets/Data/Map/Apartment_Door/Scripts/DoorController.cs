﻿using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public bool keyNeeded = false;              //Is key needed for the door
    public bool gotKey;                  //Has the player acquired key
    public GameObject keyGameObject;            //If player has Key,  assign it here
    public GameObject txtToDisplay;             //Display the information about how to close/open the door
    public GameObject txtToDisplayState;

    private Model player;

    private bool playerInZone;                  //Check if the player is in the zone
    private bool doorOpened;                    //Check if door is currently opened or not

    private Animation doorAnim;
    private BoxCollider doorCollider;           //To enable the player to go through the door if door is opened else block him
    private float doorAnimOpenHasOpened;
    private float doorAnimOpenHasClosed;

    enum DoorState
    {
        Closed,
        Opened,
        Jammed
    }

    DoorState doorState = new DoorState();      //To check the current state of the door

    /// <summary>
    /// Initial State of every variables
    /// </summary>
    private void Start()
    {
        gotKey = false;
        doorOpened = false;                     //Is the door currently opened
        playerInZone = false;                   //Player not in zone
        doorState = DoorState.Closed;           //Starting state is door closed

        txtToDisplay.SetActive(false);

        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
        doorAnimOpenHasOpened = (doorAnim["Door_Open"].length / 100) * 95;
        doorAnimOpenHasClosed = (doorAnim["Door_Close"].length / 100) * 95;
        //doorCollider = transform.parent.gameObject.GetComponent<BoxCollider>();

        //If Key is needed and the KeyGameObject is not assigned, stop playing and throw error
        if (keyNeeded && keyGameObject == null)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Debug.LogError("Assign Key GameObject");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<Model>();
        gotKey = player.IsGotKey;
        txtToDisplay.SetActive(true);

        if (doorState == DoorState.Opened)
        {
            txtToDisplay.GetComponent<Text>().text = "Press 'E' to close";
            
        }
        else if (doorState == DoorState.Closed)
        {
            txtToDisplay.GetComponent<Text>().text = "Press 'E' to open";
            if (!gotKey)
            {
                txtToDisplayState.SetActive(true);
                txtToDisplayState.GetComponent<Text>().text = "Need the key";
            }
            
        }
        playerInZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerInZone = false;
        txtToDisplay.SetActive(false);
        txtToDisplayState.SetActive(false);
    }

    private void Update()
    {
        if (playerInZone && gotKey)
        {
            if (doorAnim["Door_Open"].time > doorAnimOpenHasOpened)
                txtToDisplay.GetComponent<Text>().text = "Press 'E' to close";
            if (doorAnim["Door_Close"].time > doorAnimOpenHasClosed)
                txtToDisplay.GetComponent<Text>().text = "Press 'E' to open";

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
