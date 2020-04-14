using UnityEngine;
using UnityEngine.UI;

public class BGM : MonoBehaviour
{
    Slider slider;

    GameObject PauseObject;
    Menu Pause;

    //BGM音量
    public static float volume = 0.5f; 

    void Start()
    {
        slider = GameObject.Find("StageSelectCanvas/stage/SoundPanel/BGMSlider").GetComponent<Slider>();

        PauseObject = GameObject.Find("MainCamera");
        Pause = PauseObject.GetComponent<Menu>();

        //他シーンでの音量変更を反映
        slider.value = volume;
    }

    void Update()
    {
        //BGMの音量調節
        if (Pause.SoundControll == true && Pause.SoundVolume == 0)
        {
            slider.Select();

            Debug.Log("BGM音量アップ");
            if (Input.GetKeyDown("right"))
            {
                if (slider.value < 1.0f)
                {
                    Debug.Log("BGM音量アップ");
                    slider.value += 0.1f;
                }
            }
            if (Input.GetKeyDown("left"))
            {
                if (slider.value > 0.0f)
                {
                    Debug.Log("BGM音量ダウン");
                    slider.value -= 0.1f;
                }
            }
        }
        
        //他シーンで共有用の変数に代入
        volume = slider.value;
    }
}