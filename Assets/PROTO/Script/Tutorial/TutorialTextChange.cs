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
            text.text = "プレイヤーは、左右スティックを、使うと左右に移動することができます。";
        }

        if (No == 1)
        {
            text.text = "プレイヤーは、上下できるところでAボタンを押すと、上下に移動できる。";
        }

        if (No == 2)
        {
            text.text = "プレイヤーは、Xボタンを押すと、水を上下することができます。\n水を上下することで様々な変化があります。\n水があるときは敵の動きが遅くなったりと様々なものです…\nいろいろ試してみてください！";
        }

        if (No == 3)
        {
            text.text = "鍵を入手することで扉を開くことができます。";
        }

        if (No == 4)
        {
            text.text = "ゴールにたどり着くことで、クリアすることができます。";
        }
    }

    public void NunberTextChange()//番号変更
    {
        No++;//次のチュートリアルへ
    }
}
