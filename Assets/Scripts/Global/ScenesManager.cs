using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.Init();
    }
}
