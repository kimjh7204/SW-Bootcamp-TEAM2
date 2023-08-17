using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlot : MonoBehaviour
{

    // [SerializeField] private Slot[] quickSlots;
    // [SerializeField] private Transform tf_parent;

    // private int selectedSlot;
    // [SerializeField] private GameObject go_SelectedImage;

    // [SerializeField] private TPSCharaterController theWeaponManager;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     quickSlots = tf_parent.GetComponentsInChildren<Slot>();
    //     selectedSlot = 0;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     TryInputNumber();
    // }

    // private void TryInputNumber()
    // {
    //     if (Input.GetKeyDown(KeyCode.Alpha1))
    //         ChangeSlot(0);
    //     else if (Input.GetKeyDown(KeyCode.Alpha2))
    //         ChangeSlot(1);
    //     else if (Input.GetKeyDown(KeyCode.Alpha3))
    //         ChangeSlot(2);
    //     else if (Input.GetKeyDown(KeyCode.Alpha4))
    //         ChangeSlot(3);
    //     else if (Input.GetKeyDown(KeyCode.Alpha5))
    //         ChangeSlot(4);
    // }

    //  private void ChangeSlot(int _num)
    // {
    //     SelectedSlot(_num);
    //     Execute();
    // }

    // private void SelectedSlot(int _num)
    // {
    //     selectedSlot = _num;
    //     go_SelectedImage.transform.position = quickSlots[selectedSlot].transform.position;
    // }

    // private void Execute()
    // {
    //     if (quickSlots[selectedSlot].item != null)
    //     {
    //         if (quickSlots[selectedSlot].item.itemType == Items.ItemType.Equipment)
    //             isHit = true;
    //             animator.SetTrigger("toolAT");
    //             StartCoroutine(AttackDelay());
    //         else
    //             StartCoroutine(theWeaponManager.ChangeWeaponCoroutine("HAND", "맨손"));
    //     }
    //     else
    //     {
    //         StartCoroutine(theWeaponManager.ChangeWeaponCoroutine("HAND", "맨손"));
    //     }
    // }
}
