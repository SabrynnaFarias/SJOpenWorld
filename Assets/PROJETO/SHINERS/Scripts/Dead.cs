using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public Transform pos;
    public Transform player;

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           
            ResetPosition();

        }
    }

    void ResetPosition()
    {
        player.position = new Vector3(pos.position.x, pos.position.y, pos.position.z); 
    }
}
