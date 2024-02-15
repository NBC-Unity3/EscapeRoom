using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoor : MonoBehaviour, IInteractable
{
    public GameObject doorLock;
    public GameObject player;
    private Animator anim;
    public bool isLocked = true;
    public bool IsOpen = false;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public string GetInteractPrompt()
    {
        if (isLocked) return "살펴보기";
        
        if (IsOpen) return "닫기";
        else return "열기";
    }

    public void OnInteract()
    {
        if (isLocked) PopDoorLock();
        else OpenClose();
    }

    private void PopDoorLock()
    {
        doorLock.SetActive(true);
        PlayerController.instance.ToggleCursor(true);
    }


    public void UnLock()
    {
        doorLock.SetActive(false);
        PlayerController.instance.ToggleCursor(false);
        isLocked = false;
    }

    private void OpenClose()
    {
        if (IsOpen)
        {
            IsOpen = false;
            anim.SetBool("IsOpen", false);
        }
        else
        {
            IsOpen = true;
            anim.SetBool("IsOpen", true);
        }
    }
}
