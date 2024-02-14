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
            return $"상자가 잠겨있습니다";
        else
        {
            if (ChestState == false)
                return $"상자 열기";
            else
                return null;
        }

    }

    public void OnInteract(int type)
    {
        if (type == 0) // 빈손 상호작용
        {
            InteractChest();
        }
        else if (type == 2) // ChestKey 상호작용
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
