using DG.Tweening;
using UnityEngine;

public class ActionPad : Pad_Base
{
    public int index;

    protected override void Press()
    {
        base.Press();

        StepOnManager.instance.AddIndex(index);
    }

    public void ShowColor()
    {
        transform.GetComponent<MeshRenderer>().material.DOColor(color, .5f).OnComplete(ResetColor);
    }
}
