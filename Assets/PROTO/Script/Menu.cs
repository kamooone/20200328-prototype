using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Button stage1;
    Button stage2;
    Button stage3;

    int StageNo = 1;

    public AudioClip CursorSE;
    public AudioClip DecidedSE;
    AudioSource aud;

    void Start()
    {
        // ボタンコンポーネントの取得
        stage1 = GameObject.Find("/StageSelectCanvas/stage/stage1").GetComponent<Button>();
        stage2 = GameObject.Find("/StageSelectCanvas/stage/stage2").GetComponent<Button>();
        stage3 = GameObject.Find("/StageSelectCanvas/stage/stage3").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        stage1.Select();

        this.aud = GetComponent<AudioSource>();
    }


    void Update()
    {
        //ステージを選択
        if (Input.GetKeyDown("right"))
        {
            if(StageNo < 3)
            {
                StageNo++;
                this.aud.PlayOneShot(this.CursorSE);
            }
        }
        if (Input.GetKeyDown("left"))
        {
            if (StageNo > 1)
            {
                StageNo--;
                this.aud.PlayOneShot(this.CursorSE);
            }
        }

        //シーン遷移
        if(Input.GetKeyDown(KeyCode.Space) && StageNo == 1)
        {
            this.aud.PlayOneShot(this.DecidedSE);
            SceneManager.LoadScene("GameScene1");
        }
        //if (Input.GetKeyDown(KeyCode.Space) && StageNo == 2)
        //{
        //    SceneManager.LoadScene("GameScene2");
        //}
        //if (Input.GetKeyDown(KeyCode.Space) && StageNo == 3)
        //{
        //    SceneManager.LoadScene("GameScene3");
        //}



        //選んでいるやつを赤く表示する
        if (StageNo == 1)
        {
            stage1.Select();
        }
        if (StageNo == 2)
        {
            stage2.Select();
        }
        if (StageNo == 3)
        {
            stage3.Select();
        }
    }
}