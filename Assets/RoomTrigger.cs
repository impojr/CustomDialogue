using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : Singleton<RoomTrigger>
{
    private bool canEnterRoom = false;
    private Transform locationToWarpTo;
    private CharacterController characterController;

    void Awake()
    {
        characterController = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canEnterRoom && Input.GetKeyDown(KeyCode.Space))
        {
            characterController.enabled = false;
            characterController.transform.position = locationToWarpTo.position;
            characterController.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Room")
        {
            canEnterRoom = true;
            locationToWarpTo = other.transform.GetChild(0).transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Room")
        {
            canEnterRoom = false;
            locationToWarpTo = null;
        }
    }
}
