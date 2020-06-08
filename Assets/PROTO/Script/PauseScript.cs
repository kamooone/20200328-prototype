using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{
    public AudioClip DecidedSE;
    AudioSource aud;

    public int PauseMenuNo = 0;

    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    void Start()
    {
        this.aud = GetComponent<AudioSource>();
        PauseMenu.SoundControll = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown("p") || Input.GetKeyDown("joystick button 7")) && PauseMenu.SoundControll == false) 
        {
            this.aud.PlayOneShot(this.DecidedSE);

            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                //　ポーズUIが表示されてなければ通常通り進行
            }
            else
            {
                Time.timeScale = 1f;
                PauseMenuNo = 0;
            }
        }
    }
}