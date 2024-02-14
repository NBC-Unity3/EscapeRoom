using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPoint : MonoBehaviour
{
    public float forceFactor = 500f;

    private List<Rigidbody> rbMagnets = new List<Rigidbody>();
    private Transform magnetPoint;

    // Start is called before the first frame update
    void Start()
    {
        magnetPoint = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        foreach (Rigidbody rbMagnet in rbMagnets)
        {
            if (rbMagnet != null)
            {
                rbMagnet.velocity = Vector3.zero;
                rbMagnet.AddForce((magnetPoint.position - rbMagnet.position) * forceFactor * Time.fixedDeltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            rbMagnets.Add(other.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            rbMagnets.Remove(other.GetComponent<Rigidbody>());
        }
    }
}
