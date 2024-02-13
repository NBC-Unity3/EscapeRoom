using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Animator DoorAnim;

    public bool DoorState = false;
    public bool DoorLock = true;

    private void Awake()
    {
        DoorAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        
    }

    public void InteractDoor()
    {
        if(DoorLock == true)
        {
            return;
        }
        else
        {
            if(DoorState == true)
            {
                CloseDoor();
            }
            else
            {
                OpenDoor();
            }
        }
    }

    public void OpenDoor()
    {
        DoorAnim.SetBool("IsOpen", true);
        DoorState = true;
    }

    public void CloseDoor()
    {
        DoorAnim.SetBool("IsOpen", false);
        DoorState = false;
    }
}
