using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DayAndNight : MonoBehaviour
{
    private float gameTime = 360f;
    private float gameTimeHour, gameTimeDay;

    [SerializeField] private float secondPerRealTimeSecond; // ���� ���迡���� 100�� = ���� ������ 1��

    private bool isNight = false;

    [SerializeField] private float nightFogDensity; // �� ������ Fog �е�
    private float dayFogDensity; // �� ������ Fog �е�
    [SerializeField] private float fogDensityCalc; // ������ ����
    private float currentFogDensity;

    [SerializeField] private TextMeshProUGUI dayTimeText;
    [SerializeField] private TextMeshProUGUI dayText;
    private string ampm, h, m;
    
    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;

    }

    void Update()
    {
        gameTime += Time.deltaTime;

        gameTimeHour = gameTime / 60f;

        if (gameTimeHour > 24f)
        {
            gameTime = 0f; 
            gameTimeDay += 1f;
        }

        var lightrotate = -0.25f;
        //if (lightrotate < 0)
        //{
         //   lightrotate += 360f;
        //}


        int mm = (int)gameTime % 60;
        int hh = (int)gameTimeHour;

        if (hh > 12)
        {
            hh -= 12;
            ampm = "PM";
        }
        else
        {
            ampm = "AM";
        }
        h = hh.ToString("D2");
        m = mm.ToString("D2");

        dayTimeText.text = ampm + h + " : " + m;
        dayText.text = "Day " + gameTimeDay.ToString();



        transform.Rotate(lightrotate * Time.deltaTime  , 0, 0);

        if (transform.eulerAngles.x >= 345 || transform.eulerAngles.x < 0) // x �� ȸ���� 170 �̻��̸� ��
            isNight = true;
        else if (transform.eulerAngles.x <= 180)  // x �� ȸ���� 10 ���ϸ� ��
            isNight = false;

        


        if (isNight)
        {
            if (currentFogDensity <= nightFogDensity)
            {
                currentFogDensity += 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
        else
        {
            if (currentFogDensity >= dayFogDensity)
            {
                currentFogDensity -= 0.1f * fogDensityCalc * Time.deltaTime;
                RenderSettings.fogDensity = currentFogDensity;
            }
        }
    }

}
