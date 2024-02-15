using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
using static UnityEngine.ParticleSystem;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject pivot;
    [SerializeField] private ParticleSystem fireParticle;
    Camera camera;

    Target target;

    private float range = 50f;

    public AudioClip shootingClip;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        // 마우스 좌클릭(0)
        if (Input.GetMouseButtonDown(0))
        {
            if (shootingClip)
            {
                SettingManager.PlayClip(shootingClip);
            }

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                // 오브젝트 닿는 위치에 파티클
                if (hit.collider.gameObject != null)
                {
                    Vector3 pos = hit.point;
                    CreateImpactParticleAtPosition(pos);
                }
                // 과녁에 닿으면 열쇠 드랍
                if (hit.collider.gameObject.CompareTag("Target"))
                {
                    target = hit.collider.gameObject.GetComponent<Target>();
                    if (!target.isDropKey)
                    {
                        target.isDropKey = true;
                        target.DropTargetKey();
                    }
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
