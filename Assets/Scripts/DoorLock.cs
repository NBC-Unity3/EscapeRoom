using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private string password;

    private Queue<int> queue;
    public DoubleDoor doubledoor;
    public TextMeshProUGUI text;

    void Awake()
    {
        int[] arr = { 0, 0, 0, 0 };
        queue = new Queue<int>(arr);
    }

    public void OnClick(int num)
    {
        queue.Dequeue();
        queue.Enqueue(num);
        text.text = string.Join("", queue.ToArray());

        if (text.text == password)
        {
            Destroy(this);
            doubledoor.UnLock();
        }
    }

    public void OnClose()
    {
        this.gameObject.SetActive(false);
        PlayerController.instance.ToggleCursor(false);
    }


}
