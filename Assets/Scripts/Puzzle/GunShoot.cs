using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject pivot;
    [SerializeField] private ParticleSystem fireParticle;
    Camera camera;

    private float range = 50f;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        // 마우스 좌클릭(0)
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                if (hit.collider.gameObject != null)
                {
                    Vector3 pos = hit.point;
                    Debug.Log(hit.collider.gameObject);
                    CreateImpactParticleAtPosition(pos);
                }
                if (hit.collider.gameObject.CompareTag("Target"))
                {
                    Debug.Log("target");
                }
            }

        }
    }

    void CreateImpactParticleAtPosition(Vector3 position)
    {
        var setParticle = fireParticle.emission;
        fireParticle.transform.position = position;
        ParticleSystem.EmissionModule em = fireParticle.emission;
        em.SetBurst(0, new ParticleSystem.Burst(0.0f, 1, 1, 0.01f));
        fireParticle.Play();
    }

}
