using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private GameObject settings;

    private void Awake()
    {
        settings = GetComponent<Settings>().gameObject;
    }

    public void OnClickExitButton()
    {
        settings.SetActive(false);
    }

    public void OnClickChangeInteractionKey()
    {

    }
}
