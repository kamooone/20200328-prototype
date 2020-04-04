using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    Button PauseMenu1;
    Button PauseMenu2;

    int PauseMenuNo = 1;

    void Start()
    {
        // ボタンコンポーネントの取得
        PauseMenu1 = GameObject.Find("PauseUI/retry").GetComponent<Button>();
        PauseMenu2 = GameObject.Find("PauseUI/select").GetComponent<Button>();

        // 最初に選択状態にしたいボタンの設定
        PauseMenu1.Select();
    }


    void Update()
    {


        //ステージを選択
        if (Input.GetKeyDown("right"))
        {
            if (PauseMenuNo < 2)
            {
                PauseMenuNo++;
            }
        }
        if (Input.GetKeyDown("left"))
        {
            if (PauseMenuNo > 1)
            {
                PauseMenuNo--;
            }
        }

        //シーン遷移
        if (Input.GetKeyDown(KeyCode.Space) && PauseMenuNo == 1)
        {
            //ポーズ解除
            Time.timeScale = 1f;

            SceneManager.LoadScene("GameScene1");
        }
        if (Input.GetKeyDown(KeyCode.Space) && PauseMenuNo == 2)
        {
            //ポーズ解除
            Time.timeScale = 1f;

            SceneManager.LoadScene("SelectScene");
        }


        //選んでいるやつを赤く表示する
        if (PauseMenuNo == 1)
        {
            Debug.Log("1");
            PauseMenu1.Select();
        }
        if (PauseMenuNo == 2)
        {
            Debug.Log("2");
            PauseMenu2.Select();
        }
    }
}