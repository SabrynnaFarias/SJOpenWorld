using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaAumentar : MonoBehaviour
{
    public float speed = 5f;
    public float SizeToBig = 0.5f;

    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obj")
        {
            Transform G = collision.transform;
            G.transform.localScale = new Vector3(G.transform.localScale.x + SizeToBig, G.transform.localScale.y + SizeToBig, G.transform.localScale.z + SizeToBig);
        }
    }
}
