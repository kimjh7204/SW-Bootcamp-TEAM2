using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thirst : MonoBehaviour
{
    [SerializeField]
    private Slider thirstSlider; // Slider 변수의 이름 변경

    private float maxThirst = 100f;
    private float curThirst = 100f;

    // Start is called before the first frame update
    void Start()
    {
        thirstSlider.value = curThirst / maxThirst;
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
        thirstSlider.value = Mathf.Lerp(thirstSlider.value, curThirst / maxThirst, Time.deltaTime * 10f);
    }
}
