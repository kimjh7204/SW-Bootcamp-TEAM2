using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gathering : MonoBehaviour
{
    [SerializeField] private Animator animator;

    


    
    void Update()
    {
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("gathering");
        }
    }
}
