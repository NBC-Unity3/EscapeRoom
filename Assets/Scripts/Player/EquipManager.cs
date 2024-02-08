using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipManager : MonoBehaviour
{
    public static EquipManager instance;

    // 원래는 타입이 Equip 원래는 아이템에 EquipTool이 들어가 있어서 GetComponent로 가져왔지만 지금은 따로 컴포넌트가 없음.
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

        //} // 추후 좌클릭을 사용 할 수 있어서 그냥 남겨둠.
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
