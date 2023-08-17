using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    private int hp; 

    [SerializeField]
    private int destroyTime; 

    [SerializeField]
    private SphereCollider col; 

    [SerializeField]
    private GameObject go_rock;  
    [SerializeField]
    private GameObject go_debris; 

    [SerializeField]
    private GameObject go_effect_prefabs; 


    [SerializeField]
    private string strike_Sound;
    [SerializeField]
    private string destroy_Sound;


    public void Mining()
    {
        SoundManager.instance.PlaySound(strike_Sound);

        GameObject clone = Instantiate(go_effect_prefabs, col.bounds.center, Quaternion.identity);
        Destroy(clone, destroyTime);

        hp--;
        if (hp <= 0)
            Destruction();
    }

    private void Destruction()
    {
        SoundManager.instance.PlaySound(destroy_Sound);


        col.enabled = false;
        Destroy(go_rock);

        go_debris.SetActive(true);
        Destroy(go_debris, destroyTime);
    }
}
