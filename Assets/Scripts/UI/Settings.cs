using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
     private GameObject settings;

    [SerializeField] private TMP_Text interactionKeyText;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    [SerializeField] private Slider mouseSlider;

    private bool keyBool = false;

    private void Awake()
    {
        settings = GetComponent<Settings>().gameObject;
    }

    private void Start()
    {
        Init();
        bgmSlider.onValueChanged.AddListener(SetValueBGM);
        seSlider.onValueChanged.AddListener(SetValueSE);
        mouseSlider.onValueChanged.AddListener(SetValueMouse);
    }

    private void SetValueBGM(float _value)
    {
        SettingManager.Instance.volumBGM = bgmSlider.value;
    }
    private void SetValueSE(float _value)
    {
        SettingManager.Instance.volumSE = seSlider.value;
    }
    private void SetValueMouse(float _value)
    {
        SettingManager.Instance.mouseSensitivity = mouseSlider.value;
    }

    public void OnClickExitButton()
    {
        keyBool = false;
        settings.SetActive(false);
    }

    public void OnClickChangeInteractionKey()
    {
        keyBool = true;
    }

    // OnGUI() = GUI, Ű �Է� ���� �̺�Ʈ�� �߻��� �� ȣ��Ǵ� �Լ�
    private void OnGUI()
    {
        Event keyEvent = Event.current;

        // Ű�� ������ ��, ��ư�� ���� �Ķ�� �۵�
        if (keyEvent.isKey && keyBool) 
        {
            keyBool = false; // Ű�� ������ �ٲ��� �ʵ��� �ʱ�ȭ
            SettingManager.Instance.interactionKey = keyEvent.keyCode; // ��ȣ�ۿ� Ű�� ��� �Է¹��� Ű�� ����
            ChangeInteractionText(keyEvent.keyCode); // �ؽ�Ʈ�� ����
        }
    }

    private void ChangeInteractionText(KeyCode keycode)
    {
        interactionKeyText.text = keycode.ToString();
    }

    private void Init()
    {
        bgmSlider.value = SettingManager.Instance.volumBGM;
        seSlider.value = SettingManager.Instance.volumSE;
        mouseSlider.value = SettingManager.Instance.mouseSensitivity;
        interactionKeyText.text = SettingManager.Instance.interactionKey.ToString();
    }
}
