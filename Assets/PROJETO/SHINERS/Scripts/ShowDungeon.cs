using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDungeon : MonoBehaviour
{
    public Animation Show;
    bool InProcess;

    public AudioSource Sound;
    public GameObject DisabledMission;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !InProcess)
        {
            InProcess = true;
            Show.Play();
            Sound.Play();

            DisabledMission.SetActive(false);
           
        }
    }
}
