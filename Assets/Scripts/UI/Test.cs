using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private Rigidbody _rigidbody;

    float _mass;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mass = _rigidbody.mass;
    }

    private void Start()
    {
        StartCoroutine("TestMethod");
    }

    IEnumerator TestMethod()
    {
        while (true)
        {
            Debug.Log(_mass);

            yield return new WaitForSeconds(5);
        }
    }

    public void OnClickButton()
    {
        Instantiate(prefab);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _mass += collision.rigidbody.mass;
    }

    private void OnCollisionExit(Collision collision)
    {
        _mass -= collision.rigidbody.mass;
    }
}
