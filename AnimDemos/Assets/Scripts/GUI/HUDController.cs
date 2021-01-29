using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // NEEDED WHEN WORKING WITH UI ELEMENTS
using TMPro; // NEEDED IF USING TEXT MESH PRO

public class HUDController : MonoBehaviour
{
    public TMP_Text textTimeScale;
    public static float timeScale = 1;
    public Slider sliderLerp;

    public LerpDemo lerper;

    void Start()
    {
        SliderTimeUpdated(1); // Sets slider text to 1 at start
    }

    void Update()
    {
        float p = lerper.getCurrentPercent;
        sliderLerp.SetValueWithoutNotify(p);
    }

    public void SliderTimeUpdated(float amt)
    {
        timeScale = amt; // Allows to dynamically scale time
        textTimeScale.text = System.Math.Round(timeScale, 2).ToString(); 
    }

    public void SliderLerpUpdated(float amt)
    {
        lerper.DoTheLerp(amt);
    }
}
