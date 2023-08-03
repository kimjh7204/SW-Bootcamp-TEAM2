using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    private Collider attackCollider;
    
    void Start()
    {
        attackCollider = GetComponent<Collider>();
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        // enemy = GetComponent<Enemy>();
        // if(enemy != null) enemy._hp -= 10;
        attackCollider.enabled = false;
    }

    // IEnumerator AttackDelay()
    // {
    //     
    // }
}
