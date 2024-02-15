using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    LayerMask playerLayer;

    public AudioClip endingClip;

    private void Awake()
    {
        playerLayer = LayerMask.NameToLayer("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            if (endingClip)
            {
                SettingManager.PlayClip(endingClip);
            }
            GameManager.Instance.Ending();
        }
    }
}
