using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class StepOnManager : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private GameObject dropPoint;

    public static StepOnManager instance;
    GameObject padGroup;
    ActionPad[] pads;

    Queue<int> solutionKey;
    Queue<int> inputKey;

    public AudioClip correctClip;
    public AudioClip wrongClip;

    bool isClear = false;

    private void Awake()
    {
        Init();

        Debug.Log(string.Join(", ", solutionKey.Select(item => item.ToString()).ToArray()));
    }

    void Init()
    {
        instance = this;
        padGroup = GameObject.Find("PadGroup");
        pads = padGroup.GetComponentsInChildren<ActionPad>();
        for(int i = 0; i < pads.Length; i++)
        {
            pads[i].index = i;
            // pad의 개수가 5개가 넘어가면 색상 추가해줘야함. 혹은 i % globalColors.Length 써서 5개 반복
            pads[i].color = StepOn_CommonData.globalColors[i]; 
        }
        solutionKey = Shuffle(pads.Length);

        if (inputKey == null)
            inputKey = new();
    }

    Queue<int> Shuffle(int length)
    {
        int[] array = new int[length];
        for (int i = 0; i < length; i++)
        {
            array[i] = i;
        }

        Random rand = new Random();
        array = array.OrderBy(x => rand.Next()).ToArray();

        return new Queue<int>(array);
    }

    public void AddIndex(int index)
    {
        inputKey.Enqueue(index); 
        Debug.Log($"EnQueue {index} ");

        if (CompareCount())
            CompareKey();
    }

    bool CompareCount()
    {
        return solutionKey.Count == inputKey.Count;
    }

    bool CompareKey()
    {
        Queue<int> checkQueue = new Queue<int>(solutionKey);
        while (checkQueue.Count > 0)
        {
            if (!checkQueue.Dequeue().Equals(inputKey.Dequeue()))
            {
                Invoke(nameof(ResetPads), 1);
                if (wrongClip)
                {
                    SettingManager.PlayClip(wrongClip);
                }
                return false;
            }
        }

        DropTargetKey();
        if (correctClip)
        {
            SettingManager.PlayClip(correctClip);
        }
        return true;
    }

    private void ResetPads()
    {
        foreach(var pad in pads)
        {
            pad.Reset();
        }

        inputKey.Clear();
    }

    public IEnumerator Hint()
    {
        Queue<int> q = new Queue<int>(solutionKey);
        WaitForSeconds delay = new WaitForSeconds(.3f);

        ResetPads();
        yield return new WaitForSeconds(1);

        while (q.Count > 0)
        {
            if (correctClip)
            {
                SettingManager.PlayClip(correctClip);
            }
            pads[q.Dequeue()].ShowColor();
            yield return delay;
        }
    }

    public void DropTargetKey()
    {
        Instantiate(keyPrefab, dropPoint.transform.position, Quaternion.Euler(Vector3.one * UnityEngine.Random.value * 360f));
    }
}
