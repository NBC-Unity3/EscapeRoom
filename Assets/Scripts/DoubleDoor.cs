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

    public AudioClip openClip;
    public AudioClip closeClip;
    public AudioClip unlockClip;

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
        if (unlockClip)
        {
            SettingManager.PlayClip(unlockClip);
        }
        doorLock.SetActive(false);
        PlayerController.instance.ToggleCursor(false);
        isLocked = false;
    }

    private void OpenClose()
    {
        if (IsOpen)
        {
            if (openClip)
            {
                SettingManager.PlayClip(openClip);
            }
            IsOpen = false;
            anim.SetBool("IsOpen", false);
        }
        else
        {
            if (closeClip)
            {
                SettingManager.PlayClip(closeClip);
            }
            IsOpen = true;
            anim.SetBool("IsOpen", true);
        }
    }
}
