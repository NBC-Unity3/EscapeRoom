using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, IInteractable
{
    public EquipManager equipmanager;

    Animator ChestAnim;

    public bool ChestState = false;
    public bool ChestLock = true;

    public AudioClip openClip;
    public AudioClip lockedClip;
    public AudioClip unlockClip;

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
        {
            if (lockedClip)
            {
                SettingManager.PlayClip(lockedClip);
            }
            return;
        }
            
        else
            OpenChest();
    }

    public void OpenChest()
    {
        if (openClip)
        {
            SettingManager.PlayClip(openClip);
        }
        ChestAnim.SetBool("ChestOpen", true);
        ChestState = true;
    }

    public void UnLockChest()
    {
        if (unlockClip)
        {
            SettingManager.PlayClip(unlockClip);
        }
        ChestLock = false;
    }
}
