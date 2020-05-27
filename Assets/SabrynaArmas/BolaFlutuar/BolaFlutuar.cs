using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFlutuar : MonoBehaviour
{
    public float speed = 5f;
    public float force = 12f;

    public Rigidbody BodyRb;

    void Update()
    {
        BodyRb.AddForce(transform.forward * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            rb.useGravity = false;
            rb.AddForce(rb.transform.up * force);

        }
    }
}
