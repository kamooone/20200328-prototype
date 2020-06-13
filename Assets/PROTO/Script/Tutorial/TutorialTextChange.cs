using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextChange : MonoBehaviour//チュートリアルチェンジ
{
    public Text text;//チュートリアル文

    int No;//現在のチュートリアル番号


    // Start is called before the first frame update
    void Start()
    {
        No = 0;//最初のチュートリアル
    }

    // Update is called once per frame
    void Update()
    {
        if (No == 0)
        {
            text.text = "左スティックで、左右に移動することができます。";
        }

        if (No == 1)
        {
            text.text = "はしごを利用することで、その先に移動することができます。";
        }

        if (No == 2)
        {
            text.text = "レバーを操作するとスプリンクラーが作動します。\n水を張る事で様々な変化が起きます。\n例えばこのステージの敵だと、姿が見えるようになり動きが鈍くなります。";
        }

        if (No == 3)
        {
            text.text = "鍵を入手することで扉を開くことができます。";
        }

        if (No == 4)
        {
            text.text = "";
        }
    }

    public void NunberTextChange()//番号変更
    {
        No++;//次のチュートリアルへ
    }
}
