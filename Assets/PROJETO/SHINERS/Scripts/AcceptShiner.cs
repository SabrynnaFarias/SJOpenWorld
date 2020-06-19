using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceptShiner : MonoBehaviour
{
    public GameObject UI;
    bool ShowInfo;
    bool Enter;
    bool InTransition;
    public Transform PlayerPosition;
    public Transform SpawnToShiner;
    public Animation Fade;

    PlayerMovement PM;


    private void FixedUpdate()
    {
        if (Enter && !InTransition)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PM.Wait = true;

                InTransition = true;
                Fade.Play();

                Invoke("Transition",2);
            }
        }
    }

    void Transition()
    {
        PlayerPosition.position = new Vector3(SpawnToShiner.position.x, SpawnToShiner.position.y, SpawnToShiner.position.z);
        Debug.Log("Entrando na Dungeon!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !ShowInfo)
        {
            Enter = true;
            PlayerPosition = other.transform;
            PM = other.GetComponent<PlayerMovement>();

            UI.SetActive(true);
            ShowInfo = true;
            Invoke("Disabled", 3);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enter = false;
            UI.SetActive(false);
            ShowInfo = false;
        }
    }

    void Disabled()
    {
        UI.SetActive(false);
        ShowInfo = false;
    }
}
