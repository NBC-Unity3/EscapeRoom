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

    // OnGUI() = GUI, 키 입력 등의 이벤트가 발생할 때 호출되는 함수
    private void OnGUI()
    {
        Event keyEvent = Event.current;

        // 키가 눌렸을 때, 버튼을 누른 후라면 작동
        if (keyEvent.isKey && keyBool) 
        {
            keyBool = false; // 키가 여러번 바뀌지 않도록 초기화
            SettingManager.Instance.interactionKey = keyEvent.keyCode; // 상호작용 키를 방금 입력받은 키로 변경
            ChangeInteractionText(keyEvent.keyCode); // 텍스트도 변경
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
