using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalDeath : MonoBehaviour
{
    [SerializeField] protected GameObject[] dropItem;
    [SerializeField] protected ParticleSystem ps;

    public void ItemDrop(Transform transform)
    {
        var randomDrop = Random.Range(0, 5);
        var dropItemNum = Random.Range(0, dropItem.Length);

        if (randomDrop > 0 && randomDrop < 4)
        {
            Instantiate(dropItem[dropItemNum], transform.position, transform.rotation);
        }
        else if (randomDrop > 3)
        {
            Instantiate(dropItem[dropItemNum], transform.position, transform.rotation);
            dropItemNum = Random.Range(0, dropItem.Length);
            Instantiate(dropItem[dropItemNum], transform.position, transform.rotation);
        }
    }


    public void DeathEffect()
    {
        ps.Play();
        ps.Stop();
        
    }

}

