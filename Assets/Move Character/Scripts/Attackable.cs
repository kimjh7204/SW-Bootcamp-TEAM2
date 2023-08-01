using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private Transform camArm;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
        }

        camArm = MoveManager.instance.camArm;

        camArm.position = transform.position;
    }

    
}
