using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletoneBase<UIManager>
{
    public GameObject UIObject;
    GameObject invenCanvas;
    public UI_PopUp_InterFace bookPopUpUI;

    public override void Init()
    {
        base.Init();
        
        UIObject = GameObject.Find("_UI");
        
        invenCanvas = UIObject.transform.GetChild(1).gameObject;
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