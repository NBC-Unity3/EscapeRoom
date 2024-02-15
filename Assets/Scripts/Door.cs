using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Door : MonoBehaviour , IInteractable
{
    public EquipManager equipmanager;

    Animator DoorAnim;

    public bool DoorState = false;
    public bool DoorLock = true;

    public AudioClip openClip;
    public AudioClip closeClip;
    public AudioClip lockedClip;
    public AudioClip unlockClip;

    private void Awake()
    {
        equipmanager = GameObject.Find("Player").GetComponent<EquipManager>();
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
        if (equipmanager.curEquip == null)
        {
            InteractDoor();
        }
        else if (equipmanager.curEquip.tag == "DoorKey") // DoorKey 상호작용
        {
            if (DoorLock == true)
                UnLockDoor();
            else
                InteractDoor();
        }
        else
            InteractDoor();
    }

    public void InteractDoor()
    {
        if(DoorLock == true)
        {
            if (lockedClip)
            {
                SettingManager.PlayClip(lockedClip);
            }
            return;
        }
        else
            if(DoorState == true)
                CloseDoor();
            else
                OpenDoor();
    }

    public void OpenDoor()
    {
        if (openClip)
        {
            SettingManager.PlayClip(openClip);
        }
        DoorAnim.SetBool("IsOpen", true);
        DoorState = true;
    }

    public void CloseDoor()
    {
        if (closeClip)
        {
            SettingManager.PlayClip(closeClip);
        }
        DoorAnim.SetBool("IsOpen", false);
        DoorState = false;
    }

    public void UnLockDoor()
    {
        if (unlockClip)
        {
            SettingManager.PlayClip(unlockClip);
        }
        DoorLock = false;
    }
}
