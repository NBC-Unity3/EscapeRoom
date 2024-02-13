using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Door : MonoBehaviour , IInteractable
{
    Animator DoorAnim;

    public bool DoorState = false;
    public bool DoorLock = true;

    private void Awake()
    {
        DoorAnim = GetComponent<Animator>();
    }

    public string GetInteractPrompt()
    {
        if (DoorLock == true)
            return $"문이 잠겨있습니다";
        else
        {
            if(DoorState == true)
                return $"문 닫기";
            else
                return $"문 열기";
        }
    }

    public void OnInteract()
    {
        Debug.Log("누름");
        InteractDoor();
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
