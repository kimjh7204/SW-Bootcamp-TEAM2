using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    private Collider attackCollider;
    private int dmg = 10;
    
    void Start()
    {
        attackCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider != null)
        {
            var enemy = collider.transform.GetComponent<Animal>();
            enemy.Damage(dmg, transform.position);
        }
        
        attackCollider.enabled = false;
    }
    
    // IEnumerator AttackDelay()
    // {
    //     yield return new WaitForSeconds(1f);
    //     
    // }
}
