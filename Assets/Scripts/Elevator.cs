using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    Animator ElevatorAnim;

    public bool ElevatorDoorState = true;
    public int ElevatorFloor = 1;

    public AudioClip elevatorClip;
    public AudioClip elevatorCloseClip;
    public AudioClip elevatorOpenClip;

    private void Awake()
    {
        ElevatorAnim = GetComponent<Animator>();
    }

    public string GetInteractPrompt()
    {
        if (ElevatorFloor == 1)
            return $"2Ãþ °¡±â";
        else
            return $"1Ãþ °¡±â";

    }

    public void OnInteract()
    {
        InteractElevator();
    }

    public void InteractElevator()
    {
        if (ElevatorFloor == 1)
        {
            ElevatorAnim.SetBool("DoorOpen", false);
            ElevatorDoorState = false;

            Invoke("Moving2F", 1f);
            Invoke("OpenDoor", 1f);
        }
        else
        {
            ElevatorAnim.SetBool("DoorOpen", false);
            ElevatorDoorState = false;

            Invoke("Moving1F", 1f);
            Invoke("OpenDoor", 1f);
        }
    }

    public void OpenDoor()
    {
        if (elevatorOpenClip)
        {
            SettingManager.PlayClip(elevatorOpenClip);
        }
        ElevatorAnim.SetBool("DoorOpen", true);
        ElevatorDoorState = true;
    }

    public void CloseDoor()
    {
        if (elevatorCloseClip)
        {
            SettingManager.PlayClip(elevatorCloseClip);
        }
        ElevatorAnim.SetBool("DoorOpen", false);
        ElevatorDoorState = false;
    }

    public void Moving1F()
    {
        if (elevatorClip)
        {
            SettingManager.PlayClip(elevatorClip);
        }
        ElevatorAnim.SetBool("Move1F", true);
        ElevatorFloor = 1;
    }

    public void Moving2F()
    {
        if (elevatorClip)
        {
            SettingManager.PlayClip(elevatorClip);
        }
        ElevatorAnim.SetBool("Move2F", true);
        ElevatorFloor = 2;
    }
}
