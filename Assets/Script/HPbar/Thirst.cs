using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thirst : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float maxThirst = 100;
    private float curThirst = 100;

    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = curThirst / maxThirst;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (curThirst > 0)
            {
                curThirst -= 10;
            }
            else
            {
                curThirst = 0;
            }
        }

        HandleThirst();
    }

    private void HandleThirst()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, curThirst / maxThirst, Time.deltaTime * 10);
    }
}