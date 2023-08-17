using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolUseEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject effect_prefabs;
    [SerializeField]
    private SphereCollider coll;
    
    private int destroyTime = 4;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Rock")
        {
            MiningEffect();
        }
    }
    
    public void MiningEffect()
    {
        GameObject clone = Instantiate(effect_prefabs, transform.position, Quaternion.identity);
        Destroy(clone, destroyTime);
    }
}
