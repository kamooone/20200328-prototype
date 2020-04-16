﻿using UnityEngine;
using UnityEngine.UI;

public class BGMSliderScript : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        //slider = GameObject.Find("PauseUI/SoundPanel/BGMSlider").GetComponent<Slider>();
        
        //他シーンでの音量変更を反映
        //slider.value = BGM.volume;
    }

    void Update()
    {
        //Debug.Log(BGM.volume);
        
        //BGMの音量調節
        if (PauseMenu.SoundControll == true)
        {
            slider = GameObject.Find("PauseUI/SoundPanel/BGMSlider").GetComponent<Slider>();

            //他シーンでの音量変更を反映
            slider.value = BGM.volume;

            if (PauseMenu.SoundVolume == 0)
            {
                slider.Select();

                Debug.Log("ここに入った");
                if (Input.GetKeyDown("right"))
                {
                    if (slider.value < 1.0f)
                    {
                        Debug.Log("音量ア");
                        slider.value += 0.1f;
                        BGM.volume = slider.value;
                    }
                }
                if (Input.GetKeyDown("left"))
                {
                    if (slider.value > 0.0f)
                    {
                        Debug.Log("音量ダ");
                        slider.value -= 0.1f;
                        BGM.volume = slider.value;
                    }
                }
            }
        }
    }
}