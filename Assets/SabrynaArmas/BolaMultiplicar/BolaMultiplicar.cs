using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMultiplicar : MonoBehaviour
{
    public float speed = 5f;
    public GameObject OtherThis;
    public Transform[] Spawn;
    public float TimeToRepeat;
    

    private void Start()
    {
        Invoke("Multi",TimeToRepeat);
    }

    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    void Multi()
    {
        int count = Random.Range(0, 2);
        Instantiate(OtherThis, Spawn[count].transform.position, Spawn[count].transform.rotation);
    }
}
