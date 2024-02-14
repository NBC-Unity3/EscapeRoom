using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

public class StepOnManager : MonoBehaviour
{   
    public static StepOnManager instance;
    GameObject padGroup;
    Pad[] pads;

    Queue<int> solutionKey;
    Queue<int> inputKey;

    private void Awake()
    {
        Init();

        Debug.Log(string.Join(", ", solutionKey.Select(item => item.ToString()).ToArray()));
    }

    void Init()
    {
        instance = this;
        padGroup = GameObject.Find("PadGroup");
        pads = padGroup.GetComponentsInChildren<Pad>();
        for(int i = 0; i < pads.Length; i++)
        {
            pads[i].index = i;
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

    bool CompareKey() // 여기서 정답 확인 후 열쇠같은거 지급하는 메소드 부르면 될듯
    {
        Queue<int> checkQueue = new Queue<int>(solutionKey);
        while (checkQueue.Count > 0)
        {
            if (!checkQueue.Dequeue().Equals(inputKey.Dequeue()))
            {
                Invoke(nameof(ResetPads), 1);
                Debug.Log("compare is false!!");
                return false;
            }
        }
        Debug.Log("compare is true!!");
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
}
