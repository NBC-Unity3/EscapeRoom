using DG.Tweening;
using UnityEngine;

public class Pad_Base : MonoBehaviour
{
    protected int playerLayer;

    protected Vector3 initPos;
    protected Vector3 pressedPos;
    protected bool isPressed = false;
    public Color color = Color.white;

    public MoveType moveType = MoveType.Y;
    public MoveDirection moveDirecion = MoveDirection.minus;

    protected void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        initPos = transform.position;

        int dir = (int)moveDirecion;
        switch (moveType)
        {
            case MoveType.X:
                pressedPos = new Vector3(.2f * dir, 0, 0);
                break;
            case MoveType.Y:
                pressedPos = new Vector3(0, .2f * dir, 0);
                break;
            case MoveType.Z:
                pressedPos = new Vector3(0, 0, .2f * dir);
                break;
        }
        pressedPos = initPos + pressedPos;

        Reset();
    }

    public virtual void Reset()
    {
        transform.DOLocalMove(initPos, 1);
        isPressed = false;
        ResetColor();
    }

    protected virtual void Press()
    {
        transform.DOLocalMove(pressedPos, 1);
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
