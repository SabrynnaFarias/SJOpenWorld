using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaQuicar : MonoBehaviour
{
    public float force;
    public Rigidbody rb;

    void Update()
    {
        rb.AddForce(transform.forward * force);
    }
}
