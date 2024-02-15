using UnityEngine;

public class HintPad : Pad_Base
{
    public AudioClip hintClip;

    protected override void Press()
    {
        base.Press();

        Invoke(nameof(Reset), 5f);
        StartCoroutine(StepOnManager.instance.Hint());
        if (hintClip)
        {
            SettingManager.PlayClip(hintClip);
        }
    }
}
