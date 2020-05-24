﻿using UnityEngine;
using UnityEngine.UI;

public class SESliderScript : MonoBehaviour
{
    Slider slider;

    //チャタリング防止
    bool LeftFlag = false;
    bool RightFlag = false;
    bool stick = false;

    void Start()
    {
        //slider = GameObject.Find("PauseUI/SoundPanel/SESlider").GetComponent<Slider>();

        //他シーンでの音量変更を反映
        //slider.value = SE.volume;
    }

    void Update()
    {
        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");

        //チャタリング防止
        if (Left == 1 && stick == false)
        {
            LeftFlag = true;
            stick = true;
        }
        if (Right == 1 && stick == false)
        {
            RightFlag = true;
            stick = true;
        }

        //BGMの音量調節
        if (PauseMenu.SoundControll == true)
        {
            slider = GameObject.Find("PauseUI/SoundPanel/SESlider").GetComponent<Slider>();

            //他シーンでの音量変更を反映
            slider.value = SE.volume;

            if (PauseMenu.SoundVolume == 1)
            {
                slider.Select();

                Debug.Log("さらにここに入った");
                if (RightFlag == true || Input.GetKeyDown("right"))
                {
                    if (slider.value < 1.0f)
                    {
                        Debug.Log("SE音量ア");
                        slider.value += 0.1f;
                        SE.volume = slider.value;
                    }
                    RightFlag = false;
                }
                if (LeftFlag == true || Input.GetKeyDown("left"))
                {
                    if (slider.value > 0.0f)
                    {
                        Debug.Log("SE音量ダ");
                        slider.value -= 0.1f;
                        SE.volume = slider.value;
                    }
                    LeftFlag = false;
                }
            }

            //チャタリング防止
            if (Left == 0)
            {
                stick = false;
            }
            if (Right == 0)
            {
                stick = false;
            }
        }
    }
}