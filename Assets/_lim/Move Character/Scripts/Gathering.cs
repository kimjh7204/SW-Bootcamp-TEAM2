using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Gathering : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public bool isGathering = false;
    public bool ingGathering = false;


    
    void Update()
    {
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.F) && isGathering)
        {
            animator.SetTrigger("gathering");
            ingGathering = true;
        }
        else ingGathering = false;
    }
}
