using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �� ��ȯ �ı� x, ȯ�漳�� �����ϵ��� ����
public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance;

    public float volumBGM = 0.5f;
    public float volumSE = 0.5f;

    public float mouseSensitivity = 0.5f;

    public KeyCode interactionKey = KeyCode.E;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyUp(interactionKey))
        {
            Debug.Log(interactionKey);
        }
    }

}
