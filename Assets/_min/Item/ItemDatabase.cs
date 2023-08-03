using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Items> itemDB = new List<Items>();

    public GameObject fielditemPrefab;
    public Vector3[] pos;

    private void Start()
    {
        for(int i=0; i<5; i++)
        {
            //GameObject go = Instantiate(fielditemPrefab, pos[i], Quaternion.identity);
            //go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }
    }
}
