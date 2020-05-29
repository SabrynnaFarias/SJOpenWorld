using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaRGB : MonoBehaviour
{
    public Material[] M;
    public MeshRenderer MR;
    public float TimeToRepeat = 1;
    public float speed = 5f;

    void Start()
    {
        InvokeRepeating("RGB", 0, TimeToRepeat);
    }

    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    void RGB()
    {
        int temp = Random.Range(0, 5);
        MR.material = M[temp];
    }

}
