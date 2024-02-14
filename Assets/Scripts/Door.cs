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

    private void Awake()
    {
        equipmanager = GameObject.Find("Player").GetComponent<EquipManager>();
        DoorAnim = GetComponent<Animator>();
    }

    public string GetInteractPrompt()
    {
        if (DoorLock == true)
            return $"���� ����ֽ��ϴ�";
        else
        {
            if(DoorState == true)
                return $"�� �ݱ�";
            else
                return $"�� ����";
        }
    }

    public void OnInteract()
    {
        if (equipmanager.curEquip == null)
        {
            InteractDoor();
        }
        else if (equipmanager.curEquip.tag == "DoorKey") // DoorKey ��ȣ�ۿ�
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
            return;
        else
            if(DoorState == true)
                CloseDoor();
            else
                OpenDoor();
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

    public void UnLockDoor()
    {
        DoorLock = false;
    }
}
