using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleBallls : MonoBehaviour
{
    public GameObject BigShoot;
    public GameObject MultiplePrefab;
    public Transform RoomSize;
    Vector3 center;
    Vector3 size;

    public int Qtd = 100;

    void Start()
    {
        center.x = RoomSize.transform.position.x;
        center.y = RoomSize.transform.position.y;
        center.z = RoomSize.transform.position.z;

        size.x = RoomSize.transform.localScale.x;
        size.z = RoomSize.transform.localScale.z;
        size.y = RoomSize.transform.localScale.y;


        Invoke("Destroy", 3f);
    }
    void Destroy()
    {
        BigShoot.SetActive(false);
        Spawn();
    }
    void Spawn()
    {

        for (int i = 0; i <= Qtd; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

            GameObject SpawnP = Instantiate(MultiplePrefab, pos, Quaternion.identity);
        }

    }
}