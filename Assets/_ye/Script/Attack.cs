using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack: MonoBehaviour
{
    [SerializeField]
    private GameObject ToolUseEffect;

    private Collider attackCollider;
    private int dmg = 10;

    void Start()
    {
        attackCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {

            collider.transform.GetComponent<TPSCharaterController>();
        }

    }

}