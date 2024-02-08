using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipManager : MonoBehaviour
{
    public static EquipManager instance;

    // ������ Ÿ���� Equip ������ �����ۿ� EquipTool�� �� �־ GetComponent�� ���������� ������ ���� ������Ʈ�� ����.
    public GameObject curEquip; 
    public Transform equipParent;

    //PlayerController controller;
    //PlayerConditions conditions;

    private void Awake()
    {
        instance = this;
        //controller = GetComponent<PlayerController>();
        //conditions = GetComponent<PlayerConditions>();
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        //if (context.phase == InputActionPhase.Performed && curEquip != null && controller.canLook)
        //{
        //    curEquip.OnAttackInput(conditions);

        //} // ���� ��Ŭ���� ��� �� �� �־ �׳� ���ܵ�.
    }

    public void EquipNew(ItemData item)
    {
        UnEquip();
        curEquip = Instantiate(item.equipPrefab, equipParent); 
    }

    public void UnEquip()
    {
        if(curEquip != null)
        {
            Destroy(curEquip.gameObject);
            curEquip = null;
        }
    }

}
