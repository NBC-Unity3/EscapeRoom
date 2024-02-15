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
