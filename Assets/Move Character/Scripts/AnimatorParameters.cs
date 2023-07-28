using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetFloat("New Float", 3.1f);
        }
        
        if (Input.GetKeyUp(KeyCode.F))
        {
            animator.SetFloat("New Float", 2.9f);
        }
    }
}
