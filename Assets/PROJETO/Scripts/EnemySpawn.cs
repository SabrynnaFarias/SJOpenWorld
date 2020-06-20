using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    int TimeToSpawn;
    public int Waves;
    public GameObject win;

    void Start()
    {
        TimeToSpawn = Random.Range(10, 50);
        InvokeRepeating("Spawn", 0, TimeToSpawn);
    }

    
    void Spawn()
    {
        if(Waves <= 7)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            TimeToSpawn = Random.Range(10, 50);
            Waves++;
        }
        else
        {
            CancelInvoke("Spawn");
            win.SetActive(true);
            Invoke("CancelWin", 3);

        }
        
    }

    void CancelWin()
    {
        win.SetActive(false);
        
    }
}
