using DG.Tweening;
using UnityEngine;

public class Pad : MonoBehaviour
{
    int playerLayer;

    float initPosY;
    float pressedPosY;
    public int index;
    bool isPressed = false;

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        playerLayer = LayerMask.NameToLayer("Player");
        initPosY = transform.position.y;
        pressedPosY = initPosY - .2f;

        Reset();
    }

    public void Reset()
    {
        transform.DOLocalMoveY(initPosY, 1);
        isPressed = false;
    }

    void Press()
    {
        transform.DOLocalMoveY(pressedPosY, 1);
        isPressed = true;

        StepOnManager.instance.AddIndex(index);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isPressed)
            return;

        if (other.gameObject.layer == playerLayer)
        {
            Press();
        }
    }
}
