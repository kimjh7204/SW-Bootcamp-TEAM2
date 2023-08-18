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
            StartCoroutine(GatheringDelay());
        }
    }

    private IEnumerator GatheringDelay()
    {
        yield return new WaitForSeconds(1.95F);
        ingGathering = false;
    }
}
