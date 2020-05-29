using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScale : MonoBehaviour
{
    public Vector3 scaleChange;
    public Transform fxPrefab;
    public int countStop;
    public int stopNumber;
    public float frameRate;
    void Start()
    {
        fxPrefab = GetComponent<Transform>();
        InvokeRepeating("Scale", 1f, frameRate);
    }
    void Scale()
    {
        if (countStop <= stopNumber)
        {
            countStop++;
            fxPrefab.transform.localScale += scaleChange;
        }
        else
        {
            CancelInvoke("Scale");
        }
    }
}
