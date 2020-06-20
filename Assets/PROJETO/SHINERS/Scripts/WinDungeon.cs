using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDungeon : MonoBehaviour
{
    public Transform SpawnReturn;
    public GameObject Dungeon;
    Transform PlayerPosition;

    public Animation Fade;

    public GameObject Level;
    public GameObject UILevel;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerPosition = other.gameObject.transform;
            
            Fade.Play();
            Invoke("Cancel", 1);
            Invoke("ReturnPlayer", 2);

        }
    }

    void Cancel()
    {
        Dungeon.SetActive(false);
    }

    void ReturnPlayer()
    {
        PlayerPosition.position = new Vector3(SpawnReturn.position.x, SpawnReturn.position.y, SpawnReturn.position.z);
        Level.SetActive(true);
        UILevel.SetActive(true);
        
    }
}
