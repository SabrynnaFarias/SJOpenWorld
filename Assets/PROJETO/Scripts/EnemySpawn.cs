using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    int TimeToSpawn;
    void Start()
    {
        TimeToSpawn = Random.Range(10, 50);
        InvokeRepeating("Spawn", 0, TimeToSpawn);
    }

    
    void Spawn()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
        TimeToSpawn = Random.Range(10, 50);
    }
}
