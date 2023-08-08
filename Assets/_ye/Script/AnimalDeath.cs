using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDeath : MonoBehaviour
{
    [SerializeField] GameObject[] dropItem;


    public void ItemDrop()
    {
        var randomDrop = Random.Range(0, 5);
        var dropItemNum = Random.Range(0, dropItem.Length);

        if (randomDrop > 0 && randomDrop < 4)
        {
            Instantiate(dropItem[dropItemNum]);
        }
        else if (randomDrop > 3)
        {
            Instantiate(dropItem[dropItemNum]);
            dropItemNum = Random.Range(0, dropItem.Length);
            Instantiate(dropItem[dropItemNum]);
        }
    }

}
