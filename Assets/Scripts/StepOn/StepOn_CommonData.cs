using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType
{
    X, Y, Z
}
public enum MoveDirection
{
    minus = -1,
    plus = +1
}

public struct StepOn_CommonData
{
    public static readonly Color[] globalColors = new Color[]
    {
        Color.red,
        Color.green,
        Color.blue,
        Color.cyan,
        Color.magenta,
    };
}
