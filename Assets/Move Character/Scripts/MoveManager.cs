using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveManager : MonoBehaviour
{
    public static MoveManager instance;

    public Transform camArm;
    void Awake()
    {
        instance = this;
        camArm = gameObject.GetComponent<Transform>();
    }
    
    // public void OnOffCam(bool on)
    // {
    //     camArm.GetComponent<Camera>().enabled = on;
    // }
}
