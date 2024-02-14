using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject pivot;
    [SerializeField] private ParticleSystem fireParticle;

    private bool onAim = false;
    private float range = 50f;

    private Transform gameObj;

    private void Awake()
    {
        gameObj = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            onAim = true;
        }
        if (onAim)
        {
            OnAim();
        }
        // 마우스 좌클릭(0)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(player.transform.position, player.transform.forward, out hit, range))
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            CreateParticle();
        }
    }

    private void OnAim()
    {
        //gameObj.position = 
    }

    private void CreateParticle()
    {
        fireParticle.Play();
        fireParticle.Stop();
    }
}
