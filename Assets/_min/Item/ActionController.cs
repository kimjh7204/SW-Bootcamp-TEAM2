using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    private bool pickupActivated = false;

    public Gathering gathering;

    [SerializeField] private float radius;
    [SerializeField] private float dis;

    private RaycastHit hitInfo;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Text actionText;

    [SerializeField] private Inventory theinventory;


    
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
        }
    }

    private void CheckItem()
    {
        if(Physics.SphereCast(transform.position, radius, transform.TransformDirection(Vector3.forward), out hitInfo, dis, layerMask))
        //if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hitInfo, range, layerMask))
        {
            if(hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
                GetComponent<Gathering>().isGathering = true;
            }
        }
        else
        {
            ItemInfoDisappear();
            GetComponent<Gathering>().isGathering = false;
        }
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().items.itemName + " 획득 " + "<color=yellow>" + "(F)" + "</color>";
    }

    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }

    private void CanPickUp()
    {
        if(pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().items.itemName + " 획득했습니다. ");
                theinventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().items);
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
