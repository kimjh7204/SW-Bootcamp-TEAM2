using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gathering : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float range;

    private bool pickupActivated = false;

    private RaycastHit hitInfo;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private TextMeshProUGUI actionText;


    
    void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            CheckItem();
            CanPickUp();
            animator.SetTrigger("gathering");
        }
    }

    private void CheckItem()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if(hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else   
            ItemInfoDisappear();
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().items.itemName + " 획득 " + "<color=yellow>" + "(F)" + "</color";
    }

    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        //actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if(pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
