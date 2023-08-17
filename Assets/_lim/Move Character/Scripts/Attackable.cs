using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
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
        if (collider.tag == "Animal")
        {

            collider.transform.GetComponent<Animal>().Damage(dmg, transform.position);
        }

        else if (collider.tag == "Rock")
        {
            collider.transform.GetComponent<Rock>().Mining();
        }
    }
    
    // IEnumerator AttackDelay()
    // {
    //     yield return new WaitForSeconds(1f);
    //     
    // }
}
