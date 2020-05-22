using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaCrescer : MonoBehaviour
{
    public float speed;
    public float Repeat;
    public int ScaleSizePerSecond;
    public float timeToDestroy;
    public GameObject BodyShot;

    void Start()
    {
        
        InvokeRepeating("Scale", 1, Repeat);
        Invoke("Cancel", timeToDestroy);

    }

    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    void Scale()
    {
        transform.localScale = new Vector3(transform.localScale.x + ScaleSizePerSecond, transform.localScale.y + ScaleSizePerSecond, transform.localScale.z + ScaleSizePerSecond);
    }

    void Cancel()
    {
        this.gameObject.SetActive(false);
    }
}
