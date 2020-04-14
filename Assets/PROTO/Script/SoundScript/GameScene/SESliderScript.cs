using UnityEngine;
using UnityEngine.UI;

public class SESliderScript : MonoBehaviour
{
    Slider slider;

    void Start()
    {
        //slider = GameObject.Find("PauseUI/SoundPanel/SESlider").GetComponent<Slider>();

        //他シーンでの音量変更を反映
        //slider.value = SE.volume;
    }

    void Update()
    {
        //BGMの音量調節
        if (PauseMenu.SoundControll == true && PauseMenu.SoundVolume == 1)
        {
            slider = GameObject.Find("PauseUI/SoundPanel/SESlider").GetComponent<Slider>();

            //他シーンでの音量変更を反映
            slider.value = SE.volume;

            slider.Select();
           
            Debug.Log("さらにここに入った");
            if (Input.GetKeyDown("right"))
            {
                if (slider.value < 1.0f)
                {
                    Debug.Log("SE音量ア");
                    slider.value += 0.1f;
                    SE.volume = slider.value;
                }
            }
            if (Input.GetKeyDown("left"))
            {
                if (slider.value > 0.0f)
                {
                    Debug.Log("SE音量ダ");
                    slider.value -= 0.1f;
                    SE.volume = slider.value;
                }
            }
        }
    }
}