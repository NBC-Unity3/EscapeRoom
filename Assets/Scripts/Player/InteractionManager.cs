using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionManager : MonoBehaviour
{
    EquipManager equipManager;

    public float checkRate = .05f;
    float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    GameObject curInteractGameobject;
    IInteractable curInteractable;

    public TextMeshProUGUI prompText;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        equipManager = GetComponent<EquipManager>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2)); // ȭ���� �߾�
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if(hit.collider.gameObject != curInteractGameobject)
                {
                    curInteractGameobject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                curInteractGameobject = null;
                curInteractable = null;
                prompText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        prompText.gameObject.SetActive(true);
        prompText.text = $"<b>[E]</b> {curInteractable.GetInteractPrompt()}";
    }

    public void OnInteractInput(InputAction.CallbackContext callbaackContext)
    {
        if(callbaackContext.phase == InputActionPhase.Started && curInteractable != null)
        {
            if (equipManager.curEquip == null)
            {
                curInteractable.OnInteract(0);
            }
            else if (equipManager.curEquip.tag == "DoorKey")
            {
                curInteractable.OnInteract(1);
            }

            curInteractable = null;
            curInteractGameobject = null;
            prompText.gameObject.SetActive(false);
        }
    }
}
