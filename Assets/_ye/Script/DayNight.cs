using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class DayAndNight : MonoBehaviour
{
    private float gameTime = 360f;
    private float gameTimeHour, gameTimeDay;

    [SerializeField] private float secondPerRealTimeSecond; // 게임 세계에서의 100초 = 현실 세계의 1초

    private bool isNight = false;

    [SerializeField] private float nightFogDensity; // 밤 상태의 Fog 밀도
    private float dayFogDensity; // 낮 상태의 Fog 밀도
    [SerializeField] private float fogDensityCalc; // 증감량 비율
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

        if (transform.eulerAngles.x >= 345 || transform.eulerAngles.x < 0) // x 축 회전값 170 이상이면 밤
            isNight = true;
        else if (transform.eulerAngles.x <= 180)  // x 축 회전값 10 이하면 낮
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
