using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && HPBar.curHp > 0)
        {
            animator.SetTrigger("attack");
        }
    }
}