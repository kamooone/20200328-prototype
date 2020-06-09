using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class SelectFade : MonoBehaviour
{
    GameObject TitleObj;

    float speed = 0.01f;//透明化の速さ
    float alfa = 0;//A値を操作するための変数(スクリプトでは0～1の範囲)
    float red = 0.0f, green = 0.0f, blue = 0.0f;//RGBを操作するための変数

    // Start is called before the first frame update
    void Start()
    {
        TitleObj = GameObject.Find("SoundObject");

        red = 0.0f;
        green = 0.0f;
        blue = 0.0f;
        alfa = 0.0f;
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        
    }

    void Update()
    {
        if (Menu.FadeFlag == true)
        {
            if (alfa <= 1.0f)
            {
                //red -= speed;
                //green -= speed;
                //blue -= speed;
                alfa += speed;
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
            }
            if (alfa >= 1.0f)
            {
                Menu.FadeFlag = false;


                // Titleのオブジェクトを消す(BGMを消すため)
                Destroy(TitleObj);

                if(Menu.StageNo==0)
                {
                    SceneManager.LoadScene("Tutorial1");
                    Menu.NowStageNo = 0;
                }

                //ステージ移動
                if (Menu.StageNo == 5)
                {
                    SceneManager.LoadScene("GameScene1_1");
                    Menu.NowStageNo = 1;
                }
                if (Menu.StageNo == 6)
                {
                    SceneManager.LoadScene("GameScene1_2");
                    Menu.NowStageNo = 2;
                }
                if (Menu.StageNo == 7)
                {
                    SceneManager.LoadScene("GameScene1_3");
                    Menu.NowStageNo = 3;
                }
                if (Menu.StageNo == 8)
                {
                    SceneManager.LoadScene("GameScene1_4");
                    Menu.NowStageNo = 4;
                }
                if (Menu.StageNo == 9)
                {
                    SceneManager.LoadScene("GameScene1_5");
                    Menu.NowStageNo = 5;
                }
                if (Menu.StageNo == 10)
                {
                    SceneManager.LoadScene("GameScene2_1");
                    Menu.NowStageNo = 6;
                }
                if (Menu.StageNo == 11)
                {
                    SceneManager.LoadScene("GameScene2_2");
                    Menu.NowStageNo = 7;
                }
                if (Menu.StageNo == 12)
                {
                    SceneManager.LoadScene("GameScene2_3");
                    Menu.NowStageNo = 8;
                }
                if (Menu.StageNo == 13)
                {
                    SceneManager.LoadScene("GameScene2_4");
                    Menu.NowStageNo = 9;
                }
                if (Menu.StageNo == 14)
                {
                    SceneManager.LoadScene("GameScene2_5");
                    Menu.NowStageNo = 10;
                }

                if (Menu.StageNo == 15)
                {
                    SceneManager.LoadScene("GameScene3_1");
                    Menu.NowStageNo = 11;
                }
                if (Menu.StageNo == 16)
                {
                    SceneManager.LoadScene("GameScene3_2");
                    Menu.NowStageNo = 12;
                }
                if (Menu.StageNo == 17)
                {
                    SceneManager.LoadScene("GameScene3_3");
                    Menu.NowStageNo = 13;
                }
                if (Menu.StageNo == 18)
                {
                    SceneManager.LoadScene("GameScene3_4");
                    Menu.NowStageNo = 14;
                }
                if (Menu.StageNo == 19)
                {
                    SceneManager.LoadScene("GameScene3_5");
                    Menu.NowStageNo = 15;
                }

                if (Menu.StageNo == 20)
                {
                    SceneManager.LoadScene("GameScene4_1");
                    Menu.NowStageNo = 16;
                }
                if (Menu.StageNo == 21) 
                {
                    SceneManager.LoadScene("GameScene4_2");
                    Menu.NowStageNo = 17;
                }
                if (Menu.StageNo == 22)
                {
                    SceneManager.LoadScene("GameScene4_3");
                    Menu.NowStageNo = 18;
                }
                if (Menu.StageNo == 23)
                {
                    SceneManager.LoadScene("GameScene4_4");
                    Menu.NowStageNo = 19;
                }
                if (Menu.StageNo == 24)
                {
                    SceneManager.LoadScene("GameScene4_5");
                    Menu.NowStageNo = 20;
                }
            }
        }
    }
}
