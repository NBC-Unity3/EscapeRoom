using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    Animator ChestAnim;

    public bool ChestState = false;
    public bool ChestLock = true;

    private void Awake()
    {
        ChestAnim = GetComponent<Animator>();
    }

    public string GetInteractPrompt()
    {
        if (ChestLock == true)
            return $"���ڰ� ����ֽ��ϴ�";
        else
        {
            if (ChestState == false)
                return $"���� ����";
            else
                return null;
        }

    }

    public void OnInteract(int type)
    {
        if (type == 0) // ��� ��ȣ�ۿ�
        {
            InteractChest();
        }
        else if (type == 2) // ChestKey ��ȣ�ۿ�
        {
            if (ChestLock == true)
                UnLockChest();
            else
                InteractChest();
        }
    }

    public void InteractChest()
    {
        if (ChestLock == true)
        {
            return;
        }
        else
        {
            OpenChest();
        }
    }

    public void OpenChest()
    {
        ChestAnim.SetBool("ChestOpen", true);
        ChestState = true;
    }

    public void UnLockChest()
    {
        ChestLock = false;
    }
}
