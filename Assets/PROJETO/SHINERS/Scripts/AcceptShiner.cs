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

    public GameObject ThisDungeon;
    public GameObject Info;

    

    private void FixedUpdate()
    {
        if (Enter && !InTransition)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PM.Wait = true;

                InTransition = true;
                Fade.Play();

                Invoke("Transition",3);
                Invoke("ShowDungeon", 2);



            }
        }
    }

    void ShowDungeon()
    {
        PM.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        PM.pos = SpawnToShiner;
        ThisDungeon.SetActive(true);
    }

    void Transition()
    {
        Info.SetActive(true);
        PlayerPosition.position = new Vector3(SpawnToShiner.position.x, SpawnToShiner.position.y, SpawnToShiner.position.z);
        PM.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        Debug.Log("Entrando na Dungeon!");

        Invoke("CancelInfo", 3);
    }

    void CancelInfo()
    {
        Info.SetActive(false);
        PM.Wait = false;
        PM.jumpSpeed = 30;
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
