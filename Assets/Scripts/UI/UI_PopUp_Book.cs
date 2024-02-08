using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PopUp_Book : MonoBehaviour,UI_PopUp_InterFace
{
    TMP_Text[] texts;

    private enum TextIndex
    {
        Title,
        content
    }

    private void Awake()
    {
        texts = GetComponentsInChildren<TMP_Text>(); 
    }

    public void Init(ItemData item)
    {
        gameObject.SetActive(true);

        texts[(int)TextIndex.Title].text = item.displayName;
        texts[(int)TextIndex.content].text = item.consumables[0].content;
    }
}
