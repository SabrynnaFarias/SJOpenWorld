using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDungeon : MonoBehaviour
{
    public Animation Show;
    bool InProcess;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !InProcess)
        {
            InProcess = true;
            Show.Play();
           
        }
    }
}
