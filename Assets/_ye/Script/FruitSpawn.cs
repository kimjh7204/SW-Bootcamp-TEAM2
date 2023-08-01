using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public GameObject fruit;
    public GameObject tree;

    void Start()
    {
        RandomSelectSpawnPoint();

    }

    public void RandomSelectSpawnPoint()
    {

        for (int i = 0; i < tree.transform.childCount; i++)
        {
            int randomSpwan = Random.Range(0, 2);
            if (randomSpwan == 1)
            {
                var point = tree.transform.GetChild(i).gameObject.transform.GetChild(0);
                Instantiate(fruit, point);
            }
        }
    }


}
