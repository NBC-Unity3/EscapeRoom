using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab;
    [SerializeField] private GameObject dropPoint;
    public bool isDropKey = false;

    public void DropTargetKey()
    {
        Instantiate(keyPrefab, dropPoint.transform.position, Quaternion.Euler(Vector3.one * Random.value * 360f));
    }
}
