using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDungeon : MonoBehaviour
{
    public Transform SpawnReturn;
    Transform PlayerPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerPosition = other.gameObject.transform;
            ReturnPlayer();
        }
    }


    void ReturnPlayer()
    {
        PlayerPosition.position = new Vector3(SpawnReturn.position.x, SpawnReturn.position.y, SpawnReturn.position.z);
    }
}
