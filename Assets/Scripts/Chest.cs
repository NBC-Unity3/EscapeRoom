using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public EquipManager equipmanager;

    Animator ChestAnim;

    public bool ChestState = false;
    public bool ChestLock = true;

    private void Awake()
    {
        equipmanager = GameObject.Find("Player").GetComponent<EquipManager>();
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
                return "??";
        }

    }

    public void OnInteract()
    {
        if (equipmanager.curEquip == null)
        {
            InteractChest();
        }
        else if (equipmanager.curEquip.tag == "ChestKey") // ChestKey ��ȣ�ۿ�
        {
            if (ChestLock == true)
                UnLockChest();
            else
                InteractChest();
        }
        else
            InteractChest();
    }

    public void InteractChest()
    {
        if (ChestLock == true)
            return;
        else
            OpenChest();
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
