using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPad : Pad_Base
{
    protected override void Press()
    {
        base.Press();

        Invoke(nameof(Reset), 5f);
        StartCoroutine(StepOnManager.instance.Hint());
    }
}
