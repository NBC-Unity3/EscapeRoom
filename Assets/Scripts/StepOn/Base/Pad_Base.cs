using DG.Tweening;
using UnityEngine;

public class Pad_Base : MonoBehaviour
{
    protected int playerLayer;

    protected Vector3 initScale;
    protected Vector3 pressed;
    protected bool isPressed = false;
    public Color color = Color.white;

    protected void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        initScale = transform.localScale;

        pressed = new Vector3(initScale.x, .01f, initScale.z);

        Reset();
    }

    public virtual void Reset()
    {
        transform.DOScale(initScale, 1);
        isPressed = false;
        ResetColor();
    }

    protected virtual void Press()
    {
        transform.DOScale(pressed, 1);
        isPressed = true;
        ChangeColor();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (isPressed)
            return;

        if (other.gameObject.layer == playerLayer)
        {
            Press();
        }
    }

    public void ChangeColor()
    {
        transform.GetComponent<MeshRenderer>().material.DOColor(color, .5f);
    }

    public void ResetColor()
    {
        transform.GetComponent<MeshRenderer>().material.DOColor(Color.white, .5f);
    }
}
