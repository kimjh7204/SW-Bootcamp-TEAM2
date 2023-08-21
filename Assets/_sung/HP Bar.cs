using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider hpbar;

    public float maxHp = 100;
    public static float curHp = 100;

    // Start is called before the first frame update
    void Start()
    {
        hpbar.value = curHp / maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (curHp > 0)
            {
                curHp -= 10;
            }
            else
            {
                curHp = 0;
            }
        }

        HandleHp();
    }

    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, curHp / maxHp, Time.deltaTime * 10);
    }
}