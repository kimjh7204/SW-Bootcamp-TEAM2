using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSlot : MonoBehaviour
{
    
    [SerializeField] private Slot[] quickSlots;
    [SerializeField] private Transform tf_parent;

    private int selectedSlot;
    [SerializeField] private GameObject go_SelectedImage;

    [SerializeField] private TPSCharaterController theWeaponManager;
    // private Attackable attackable;

    GameObject axe;
    
    [SerializeField] private string fireSound;
    [SerializeField] private string axeSound;
    [SerializeField] private string pickaxeSound;
    [SerializeField] private string torchSound;

    // Start is called before the first frame update
    void Start()
    {
        quickSlots = tf_parent.GetComponentsInChildren<Slot>();
        selectedSlot = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        TryInputNumber();
    }

    private void TryInputNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeSlot(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeSlot(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeSlot(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            ChangeSlot(3);
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            ChangeSlot(4);
    }

     private void ChangeSlot(int _num)
    {
        SelectedSlot(_num);
        Execute();
    }

    private void SelectedSlot(int _num)
    {
        selectedSlot = _num;
        go_SelectedImage.transform.position = quickSlots[selectedSlot].transform.position;
    }

    private void Execute()
    {
        if (quickSlots[selectedSlot].item != null)
        {
            if (quickSlots[selectedSlot].item.itemName == "AxeItem")
            {
                theWeaponManager.punchReady = false;
                theWeaponManager.axeReady = true;
                theWeaponManager.pickaxeReady = false;
                theWeaponManager.torchReady = false;
                theWeaponManager.animator.SetBool("isPickAxe", false);
                theWeaponManager.animator.SetBool("isAxe", true);
                theWeaponManager.animator.SetBool("isTorch", false);
                theWeaponManager.SetItem("pickaxe", false);
                theWeaponManager.SetItem("axe", true);
                theWeaponManager.SetItem("torch", false);
                SoundManager.instance.PlaySound(axeSound);
                Attackable.dmg = 20;
            }
            else if (quickSlots[selectedSlot].item.itemName == "PickAxeItem")
            {
                theWeaponManager.punchReady = false;
                theWeaponManager.axeReady = false;
                theWeaponManager.pickaxeReady = true;
                theWeaponManager.torchReady = false;
                theWeaponManager.animator.SetBool("isAxe", false);
                theWeaponManager.animator.SetBool("isPickAxe", true);
                theWeaponManager.animator.SetBool("isTorch", false);
                theWeaponManager.SetItem("axe", false);
                theWeaponManager.SetItem("pickaxe", true);
                theWeaponManager.SetItem("torch", false);
                SoundManager.instance.PlaySound(pickaxeSound);
                Attackable.dmg = 25;
            }
            else if (quickSlots[selectedSlot].item.itemName == "TorchItem")
            {
                theWeaponManager.punchReady = false;
                theWeaponManager.axeReady = false;
                theWeaponManager.pickaxeReady = false;
                theWeaponManager.torchReady = true;
                theWeaponManager.animator.SetBool("isAxe", false);
                theWeaponManager.animator.SetBool("isPickAxe", false);
                theWeaponManager.animator.SetBool("isTorch", true);
                theWeaponManager.SetItem("axe", false);
                theWeaponManager.SetItem("pickaxe", false);
                theWeaponManager.SetItem("torch", true);
                SoundManager.instance.PlaySound(fireSound);
                StartCoroutine(TorchSoundDelay());
                Attackable.dmg = 10;
            }
            else
            {
                theWeaponManager.animator.SetBool("isAxe", false);
                theWeaponManager.animator.SetBool("isPickAxe", false);
                theWeaponManager.animator.SetBool("isTorch", false);
                theWeaponManager.SetItem("axe", false);
                theWeaponManager.SetItem("pickaxe", false);
                theWeaponManager.SetItem("torch", false);
                theWeaponManager.punchReady = true;
                theWeaponManager.axeReady = false;
                theWeaponManager.pickaxeReady = false;
                theWeaponManager.torchReady = false;
                Attackable.dmg = 10;
            }
        }
        else 
        {
            theWeaponManager.animator.SetBool("isAxe", false);
            theWeaponManager.animator.SetBool("isPickAxe", false);
            theWeaponManager.animator.SetBool("isTorch", false);
            theWeaponManager.SetItem("axe", false);
            theWeaponManager.SetItem("pickaxe", false);
            theWeaponManager.SetItem("torch", false);
            theWeaponManager.punchReady = true;
            theWeaponManager.axeReady = false;
            theWeaponManager.pickaxeReady = false;
            theWeaponManager.torchReady = false;
            Attackable.dmg = 10;
        }
        
        IEnumerator TorchSoundDelay()
        {
            while (theWeaponManager.torchReady)
            {
                SoundManager.instance.PlaySound(torchSound);
                yield return new WaitForSeconds(3.3f);
            }
        }
    }

    // public void IsActivatedQuickSlot(int _num)
    // {
    //     if (selectedSlot == _num)
    //     {
    //         Execute();
    //         return;
    //     }
    //     if (DragSlot.instance != null)
    //     {
    //         if (DragSlot.instance.dragSlot != null)
    //         {
    //             if (DragSlot.instance.dragSlot.GetQuickSlotNumber() == selectedSlot)
    //             {
    //                 Execute();
    //                 return;
    //             }
    //         }
    //     }     
    // }
}
