using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : MonoBehaviour
{
    public GameObject[] fruit;

    void Start()
    {
        RandomSelectSpawnPoint();

    }

    public void RandomSelectSpawnPoint()
    {

        for (int i = 0; i < this.transform.childCount; i++)
        {
            int randomSpwan = Random.Range(0, 2);
            if (randomSpwan == 1)
            {
                int fruits = Random.Range(0, fruit.Length);
                var point = this.transform.GetChild(i);
                Instantiate(fruit[fruits], point);
            }
        }
    }


}
