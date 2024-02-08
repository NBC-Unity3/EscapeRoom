using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : SingletoneBase<UIManager>
{
    GameObject invenCanvas;
    public UI_PopUp_InterFace bookPopUpUI;

    public override void Init()
    {
        base.Init();
        invenCanvas = GameObject.Find("InventoryCanvas");
        bookPopUpUI = invenCanvas.transform.GetChild(3).GetComponent<UI_PopUp_InterFace>();
    }

    public void OpenPopUp_Book(ItemData item)
    {
        bookPopUpUI.Init(item);
    }

    public void CloseUI(GameObject go)
    {
        go.SetActive(false);
    }
}